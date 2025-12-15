using FoodRecipe.Data;
using FoodRecipe.Models;

namespace FoodRecipe.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Categories> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Categories FindCategoryById(int Id)
        {
            Categories category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            return category;
        }

        public Categories CreateCategory(Categories category)
        { 
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Categories UpdateCategory(Categories category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }

        public bool DeleteCategoryById(int Id)
        {
            Categories category = _context.Categories.FirstOrDefault(c => c.Id == Id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
