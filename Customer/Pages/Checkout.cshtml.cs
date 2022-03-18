using BackEnd.DTO.CustomerDTO;
using BackEnd.DTO.ProductDTO;
using Customer.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Interface;

namespace Customer.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly ICustomerClass _metaIdentityUserService;
        private readonly IOrderClass _orderService;
        private readonly IOrderItemClass _orderItemService;
        private readonly IProductRatingClass _productRatingService;

        public CheckoutModel(IMetaIdentityUserService metaIdentityUserService, IOrderService orderService,
            IOrderItemService orderItemService, IProductRatingService productRatingService)
        {
            _metaIdentityUserService = metaIdentityUserService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productRatingService = productRatingService;
        }

        public List<ProductItemCartDto> Cart { get; set; }
        public MetaIdentityUserDto CurrentUser { get; set; }

        [BindProperty]
        public CreateOrderDto CreateOrder { get; set; }
        public decimal TotalMoney { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Home/Login");

            Cart = SessionHelper.GetObjectFromJson<List<ProductItemCartDto>>(HttpContext.Session, "cart");
            CurrentUser = await _metaIdentityUserService.GetById(User.Claims.FirstOrDefault(u => u.Type == "sub").Value);
            CreateOrder = new CreateOrderDto
            {
                FirstName = CurrentUser.FirstName,
                LastName = CurrentUser.LastName,
                Country = CurrentUser.Country,
                Line1 = CurrentUser.Line1,
                Line2 = CurrentUser.Line2,
                PhoneNumber = CurrentUser.PhoneNumber,
                Province = CurrentUser.Province
            };
            if (Cart == null)
                return RedirectToPage("/Home/Index");
            TotalMoney = Cart.Sum(p => p.Quantity * p.Product.Price);

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

                Cart = SessionHelper.GetObjectFromJson<List<ProductItemCartDto>>(HttpContext.Session, "cart");

                if (Cart != null)
                {
                    Guid userId = Guid.Parse(User.Claims.FirstOrDefault(u => u.Type == "sub").Value);
                    CreateOrder.TotalPrice = Cart.Sum(p => p.Quantity * p.Product.Price);
                    CreateOrder.Status = "Success";
                    CreateOrder.CreatedBy = CreateOrder.UpdatedBy = userId;
                    OrderDto order = await _orderService.CreateOrder(CreateOrder);
                    List<CreateOrderItemDto> createOrderItemDtos = new List<CreateOrderItemDto>();
                    List<CreateProductRatingDto> createProductRatingDtos = new List<CreateProductRatingDto>();
                    foreach (var item in Cart)
                    {
                        createOrderItemDtos.Add(new CreateOrderItemDto
                        {
                            OrderId = order.Id,
                            Price = item.Product.Price,
                            Quantity = item.Quantity,
                            ProductId = item.Product.Id,
                            CreatedBy = userId,
                            UpdatedBy = userId
                        });

                        // init temporary
                        createProductRatingDtos.Add(new CreateProductRatingDto
                        {
                            ProductId = item.Product.Id,
                            OrderItemId = order.Id,
                            IsRated = false,
                            Comment = "",
                            Rating = 5,
                            CreatedBy = userId,
                            UpdatedBy = userId
                        });
                    }

                    List<OrderItemDto> orderItemDtos = await _orderItemService.AddRangeOrderItemsAsync(createOrderItemDtos);

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
