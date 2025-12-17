using FoodRecipe.Models;
using System.Collections.Generic;

namespace FoodRecipe.Repositories
{
    public interface IRecipeCategoryRepository
    {
        RecipeCategories Find(int recipeId, int categoryId);
        RecipeCategories Create(RecipeCategories entity);
        RecipeCategories Update(RecipeCategories entity);
        bool Delete(int recipeId, int categoryId);
        List<RecipeCategories> SearchByRecipe(int recipeId);

        int CreateWithValidation(int recipeId, IEnumerable<int> categoryIds);
    }
}