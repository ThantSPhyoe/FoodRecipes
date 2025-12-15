using FoodRecipe.Models;

namespace FoodRecipe.Repositories
{
    public interface IRecipeIngredientRepository
    {
        RecipeIngredients FindRecipeIngredient(int recipeId, int ingredientId);
        RecipeIngredients CreateRecipeIngredient(RecipeIngredients recipeIngredient);
        RecipeIngredients UpdateRecipeIngredient(RecipeIngredients recipeIngredient);
        bool DeleteRecipeIngredient(int recipeId, int ingredientId);
    }
}
