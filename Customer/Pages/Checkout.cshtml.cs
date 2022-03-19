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
using Microsoft.AspNetCore.Identity;

namespace Customer.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly UserManager<User> _metaIdentityUserService;
        private readonly IOrderClass _orderService;
        private readonly IOrderItemClass _orderItemService;
        private readonly IProductRatingClass _productRatingService;

        public CheckoutModel(UserManager<User> metaIdentityUserService, IOrderClass orderService,
            IOrderItemClass orderItemService, IProductRatingClass productRatingService)
        {
            _metaIdentityUserService = metaIdentityUserService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productRatingService = productRatingService;
        }

        public List<ProductCartDto> Cart { get; set; }
        public ReadUserDto CurrentUser { get; set; }

        [BindProperty]
        public CreateOrderDto CreateOrder { get; set; }
        public decimal TotalMoney { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Login");

            Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
            CurrentUser = await _metaIdentityUserService.GetById(User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value);
            CreateOrder = new CreateOrderDto
            {
                Name = CurrentUser.Name,
                Address = CurrentUser.Address,
                PhoneNumber = CurrentUser.PhoneNumber
            };
            if (Cart == null)
                return RedirectToPage("/");
            TotalMoney = Cart.Sum(p => p.Quantity * p.Product.cost);

            return Page();
        }

        /* 
                1. Create Order
                2. Create List Order Item 
                3. Create List Rating
        */
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");

                if (Cart != null)
                {
                    Guid userId = Guid.Parse(User.Claims.FirstOrDefault(u => u.Type == "sub").Value);
                    CreateOrder.TotalPrice = Cart.Sum(p => p.Quantity * p.Product.cost);
                    CreateOrder.Status = "Success";
                    //CreateOrder.CreatedBy = CreateOrder.UpdatedBy = userId;
                    ReadOrderDto order = await _orderService.CreateOrder(CreateOrder);
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

                    List<ReadOrderItemDto> orderItemDtos = await _orderItemService.AddRangeOrderItemsAsync(createOrderItemDtos);

                    for (int i = 0; i < orderItemDtos.Count; i++)
                    {
                        createProductRatingDtos[i].OrderItemId = orderItemDtos[i].Id;
                    }

                    await _productRatingService.AddRangeProductRatingAsync(createProductRatingDtos);
                    TempData["AlertMessage"] = "Order Product Successfully!";
                    SessionHelper.Remove(HttpContext.Session, "cart");
                    Cart = null;
                }
            }

            return Page();
        }
    }
}
