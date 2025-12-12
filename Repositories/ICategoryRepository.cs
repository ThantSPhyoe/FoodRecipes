using FoodRecipe.Models;

namespace FoodRecipe.Repositories
{
    public interface ICategoryRepository
    {
        List<Categories> GetAllCategories();
        Categories FindCategoryById(int Id);
        Categories CreateCategory(Categories category);
        Categories UpdateCategory(Categories category);
        bool DeleteCategoryById(int Id);
    }
}
