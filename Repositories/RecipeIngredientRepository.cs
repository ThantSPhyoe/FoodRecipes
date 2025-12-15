using FoodRecipe.Data;
using FoodRecipe.Models;
using System.Linq;

namespace FoodRecipe.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeIngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RecipeIngredients FindRecipeIngredient(int recipeId, int ingredientId)
        {
            return _context.RecipeIngredients
                    .FirstOrDefault(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);
        }

        public RecipeIngredients CreateRecipeIngredient(RecipeIngredients recipeIngredient)
        {
            _context.Add(recipeIngredient);
            _context.SaveChanges();
            return recipeIngredient;
        }

        public RecipeIngredients UpdateRecipeIngredient(RecipeIngredients recipeIngredient)
        {
            _context.RecipeIngredients.Update(recipeIngredient);
            _context.SaveChanges();
            return recipeIngredient;
        }

        public bool DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            var existing = FindRecipeIngredient(recipeId, ingredientId);
            if (existing == null) return false;
            _context.RecipeIngredients.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}
