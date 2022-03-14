using BackEnd.DTO.ProductDTO;
using Customer.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Customer.Pages
{
    public class CartModel : PageModel
    {
        public List<ProductCartDto> Cart { get; set; }
        public int Total { get; set; }
        public void OnGet()
        {
            Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
            if (Cart != null)
                Total = Cart.Sum(i => i.Product.cost * i.Quantity);
            else
                Total = 0;
        }
        public IActionResult OnGetDelete(Guid productId)
        {
            Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
            int index = Exists(Cart, productId);
            if (index != -1)
                Cart.RemoveAt(index);

            if (Cart.Count > 0)
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            else
                SessionHelper.Remove(HttpContext.Session, "cart");
            return Page();
        }

        public IActionResult OnPostUpdateCart(int[] quantities)
        {
            Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
            if (Cart != null)
            {
                for (var i = 0; i < Cart.Count; i++)
                {
                    Cart[i].Quantity = quantities[i];
                }
                if (Cart != null)
                    Total = Cart.Sum(i => i.Product.cost * i.Quantity);
                else
                {
                    Total = 0;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
            }
            return Page();
        }

        private int Exists(List<ProductCartDto> cart, Guid productId)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == productId)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
