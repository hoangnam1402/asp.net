using BackEnd.Model;
using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public List<Product> productDetail { get; set; }

        public void OnGet(Guid id)
        {
            products = productClass.GetProduct();
            productDetail = products.Where(x => x.Id == id).ToList();
        }
    }
}
