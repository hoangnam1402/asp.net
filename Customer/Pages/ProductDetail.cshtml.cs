using BackEnd.DTO.ProductDTO;
using BackEnd.Model;
using ClassLibrary;
using Customer.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Customer.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IProductClass productClass;

        public ProductDetailModel(ILogger<PrivacyModel> logger, IProductClass productClass)
        {
            _logger = logger;
            this.productClass = productClass;
        }

        [BindProperty]
        public List<Product> products { get; set; }

        public Product productDetail { get; set; }

        public List<ProductCartDto> Cart { get; set; }

        public void OnGet(Guid id)
        {
            products = productClass.GetProduct();
            productDetail = products.FirstOrDefault(x => x.Id == id);
        }

        public int ProductQty { get; set; } = 1;

        public ActionResult OnPostBuyNow(Guid id, int ProductQty)
        {

            products = productClass.GetProduct();
            productDetail = products.FirstOrDefault(x => x.Id == id);

            if (productDetail != null)
            {
                Cart = SessionHelper.GetObjectFromJson<List<ProductCartDto>>(HttpContext.Session, "cart");
                if (Cart == null)
                {
                    Cart = new List<ProductCartDto>
                    {
                        new ProductCartDto
                        {
                            Product = productDetail,
                            Quantity = ProductQty
                        }
                    };
                }
                else
                {
                    int index = Exists(Cart, productDetail.Id);
                    if (index == -1)
                    {
                        Cart.Add(new ProductCartDto
                        {
                            Product = productDetail,
                            Quantity = ProductQty
                        });
                    }
                    else
                    {
                        Cart[index].Quantity += ProductQty;
                    }
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
                return RedirectToPage($"/ProductDetail");
            }
            return NotFound();
        }
        private static int Exists(List<ProductCartDto> cart, Guid productId)
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
