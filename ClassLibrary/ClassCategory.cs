using BackEnd.Data;
using BackEnd.Model;

namespace ClassLibrary
{
    public class ClassCategory : ICategoryClass
    {
        public ClassCategory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Category> categories;
        private readonly ApplicationDbContext dbContext;

        public List<Category> GetCategories()
        {
            categories = dbContext.categories.ToList();

            return categories;
        }
    }
}
