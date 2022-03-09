﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ICategoryClass categoryClass;

        public PrivacyModel(ILogger<PrivacyModel> logger, IProductClass productClass, ICategoryClass categoryClass)
        {
            _logger = logger;
            this.productClass = productClass;
            this.categoryClass = categoryClass;
        }

        [BindProperty]
        public List<Product> products { get; set; }

        [BindProperty]
        public List<Category> categories { get; set; }

        public void OnGet()
        {
            products = productClass.GetProduct();
            categories = categoryClass.GetCategories();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.name.Contains(searchString)).ToList();
            }
            productNumber = products.Where(x => x.stopped == true).Count();
            pageCount = (int)Math.Ceiling(productNumber / pageSize);
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(x => x.CategoryId.ToString().Contains(category)).ToList();
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

        [BindProperty(SupportsGet = true)]
        public string category { get; set; }
    }
}