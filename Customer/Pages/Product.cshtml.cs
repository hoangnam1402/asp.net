using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
            productNumber = products.Where(x => x.stopped == true).Count();
            pageCount = (int)Math.Ceiling(productNumber / pageSize);

            if (!string.IsNullOrEmpty(searchString))
            {
                products = (List<Product>)products.Where(x => x.name.Contains(searchString));
            }
        }

        [BindProperty(SupportsGet = true)]
        public int currentPage { get; set; } = 1;

        public float pageSize { get; set; } = 3;

        [BindProperty]
        public int pageCount { get; set; }

        public int productNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }

        public SelectList categoryName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string chooseCategory { get; set; }
    }
}