﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using BackEnd.DTO.ProductDTO;
using BackEnd.DTO.CategoryDTO;
using ClassLibrary.Interface;
using BackEnd.DTO.ProductRatingDTO;

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

        public List<Product> products { get; set; }
        public Product product { get; set; }

        [BindProperty]
        public List<Category> categories { get; set; }

        public List<ProductRating> ratings { get; set; }

        public void OnGet()
        {
            products = productClass.GetProduct();
            categories = categoryClass.GetCategories();
            ratings = productClass.GetAllRating();
            if (category != null)
            {
                products = products.Where(x => x.CategoryId.ToString() == category).ToList();
            }
            if(!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Name.Contains(searchString)).ToList();
            }
            productNumber = products.Count();
            pageCount = (int)Math.Ceiling(productNumber / pageSize);
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