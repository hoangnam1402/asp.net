using BackEnd.DTO.CustomerDTO;
using BackEnd.DTO.ProductDTO;
using Customer.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;

namespace Customer.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly ICustomerClass _ICustomerClass;

        public CheckoutModel(ICustomerClass ICustomerClass)
        {
            _ICustomerClass = ICustomerClass;
        }

        public List<ProductCartDto> Cart { get; set; }
        public ReadCustomerDto CurrentUser { get; set; }

        public int TotalMoney { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
            CurrentUser = await _ICustomerClass.GetById(User.Claims.FirstOrDefault(u => u.Type == "sub").Value);
            
            if (Cart == null)
                return RedirectToPage("/Home/Index");
            TotalMoney = Cart.Sum(p => p.Quantity * p.Product.cost);

            return Page();
        }
    }
}
