using BackEnd.Model;
using BackEnd.Data;

namespace ClassLibrary
{
    public class ClassProduct : IProductClass
    {
        public ClassProduct(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Product> products;
        private readonly ApplicationDbContext dbContext;

        public List<Product> GetProduct()
        {
            products = dbContext.products.ToList();

            return products;
        }
    }
}