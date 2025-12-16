using FoodRecipe.Models;
using System.Collections.Generic;

namespace FoodRecipe.Repositories
{
    public interface IRecipeRepository
    {
        Recipe FindById(int id);
        List<Recipe> Search(string query);
        Recipe Create(Recipe recipe);
        Recipe Update(Recipe recipe);
        bool Delete(int id);

        int GetTotalRecipesCount();

        List<Recipe> GetOnlyThreeRecipes();

        List<Recipe> GetAllRecipes();
    }
}