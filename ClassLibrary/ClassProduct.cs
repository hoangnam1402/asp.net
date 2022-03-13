using BackEnd.Model;
using BackEnd.Data;
using BackEnd.DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ClassProduct : IProductClass
    {
        private readonly ApplicationDbContext _context;

        public ClassProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProduct()
        {
            //var product = _context.products.Where(x => x.stopped == false).ToList();
            var product = _context.products.ToList();

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public Product GetProductDetail(Guid id)
        {
            var product = _context.products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}