using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackEnd.Controllers;
using ClassLibrary;
using BackEnd.DTO.ProductDTO;
using BackEnd.Model;

namespace Customer.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IProductClass productClass;

        public PrivacyModel(ILogger<PrivacyModel> logger, IProductClass productClass)
        {
            _logger = logger;
            this.productClass = productClass;
        }

        [BindProperty]
        public List<Product> products { get; set; }

        public void OnGet()
        {
            products = productClass.GetProduct();
            pageCount = (int)Math.Ceiling(products.Where(x => x.stopped == true).Count() / pageSize);
        }

        [BindProperty(SupportsGet = true)]
        public int currentPage { get; set; } = 1;

        public float pageSize { get; set; } = 3;

        [BindProperty]
        public int pageCount { get; set; }
    }
}