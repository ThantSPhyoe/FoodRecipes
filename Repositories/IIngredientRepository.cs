using FoodRecipe.Models;

namespace FoodRecipe.Repositories
{
    public interface IIngredientRepository
    {
        List<Ingredients> GetAllIngredient();
        Ingredients FindIngredientById(int Id);
        Ingredients CreateIngredient(Ingredients category);
        Ingredients UpdateIngredient(Ingredients category);
        bool DeleteIngredientById(int Id);
    }
}
