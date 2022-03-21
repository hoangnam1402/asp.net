using BackEnd.DTO.CustomerDTO;
using BackEnd.DTO.ProductDTO;
using Customer.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Interface;
using BackEnd.DTO.OrderDTO;
using BackEnd.DTO.ProductRatingDTO;
using System.Security.Claims;
using BackEnd.Model;

namespace Customer.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly ICustomerClass _customerClass;
        private readonly IOrderClass _orderClass;
        private readonly IOrderItemClass _orderItemClass;
        private readonly IProductRatingClass _productRatingClass;

        public CheckoutModel(ICustomerClass customerClass, IOrderClass orderClass,
            IOrderItemClass orderItemClass, IProductRatingClass productRatingClass)
        {
            _customerClass = customerClass;
            _orderClass = orderClass;
            _orderItemClass = orderItemClass;
            _productRatingClass = productRatingClass;
        }

        public List<ProductCartDto> Cart { get; set; }
        public User CurrentUser { get; set; }

        [BindProperty]
        public CreateOrderDto CreateOrder { get; set; }
        public int TotalMoney { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Login");

            Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
            CurrentUser = await _customerClass.GetById(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value);
            CreateOrder = new CreateOrderDto
            {
                Name = CurrentUser.Name,
                Address = CurrentUser.Address,
                PhoneNumber = CurrentUser.PhoneNumber
            };
            if (Cart == null)
                return RedirectToPage("/Product");
            TotalMoney = Cart.Sum(p => p.Quantity * p.Product.cost);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");

                if (Cart != null)
                {
                    Guid userId = Guid.Parse(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value);
                    CreateOrder.TotalPrice = Cart.Sum(p => p.Quantity * p.Product.cost);
                    CreateOrder.Status = "Success";
                    //CreateOrder.CreatedBy = CreateOrder.UpdatedBy = userId;
                    ReadOrderDto order = await _orderClass.CreateOrder(CreateOrder);
                    List<CreateOrderItemDto> createOrderItemDtos = new List<CreateOrderItemDto>();
                    List<CreateProductRatingDto> createProductRatingDtos = new List<CreateProductRatingDto>();
                    foreach (var item in Cart)
                    {
                        createOrderItemDtos.Add(new CreateOrderItemDto
                        {
                            OrderId = order.Id,
                            Price = item.Product.cost,
                            Quantity = item.Quantity,
                            ProductId = item.Product.Id
                        });

                        // init temporary
                        createProductRatingDtos.Add(new CreateProductRatingDto
                        {
                            ProductId = item.Product.Id,
                            OrderItemId = order.Id,
                            IsRated = false,
                            Comment = "",
                            Rating = 5
                        });
                    }

                    List<ReadOrderItemDto> orderItemDtos = await _orderItemClass.AddRangeOrderItemsAsync(createOrderItemDtos);

                    for (int i = 0; i < orderItemDtos.Count; i++)
                    {
                        createProductRatingDtos[i].OrderItemId = orderItemDtos[i].Id;
                    }

                    await _productRatingClass.AddRangeProductRatingAsync(createProductRatingDtos);
                    SessionHelper.Remove(HttpContext.Session, "cart");
                    Cart = null;
                }
            }

            return Page();
        }
    }
}
