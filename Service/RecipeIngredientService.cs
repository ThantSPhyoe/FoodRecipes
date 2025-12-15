using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Repositories;
using FoodRecipe.Dtos;

namespace FoodRecipe.Service
{
    public class RecipeIngredientService
    {
        private readonly IRecipeIngredientRepository recipeIngredientRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
            this.recipeIngredientRepository = recipeIngredientRepository;
        }

        public RecipeIngredientDto CreateRecipeIngredient(CreateRecipeIngredientRequestDto dto)
        {
            try
            {
                var exists = recipeIngredientRepository.FindRecipeIngredient(dto.RecipeId, dto.IngredientId);
                if (exists != null) throw new InvalidOperationException("Recipe ingredient already exists.");

                var now = DateTime.UtcNow;
                var model = new RecipeIngredients
                {
                    RecipeId = dto.RecipeId,
                    IngredientId = dto.IngredientId,
                    Quantity = dto.Quantity.ToString(),
                    Unit = dto.Unit,
                    //CreatedAt = now,
                    //UpdatedAt = now
                };

                var created = recipeIngredientRepository.CreateRecipeIngredient(model);
                return new RecipeIngredientDto
                {
                    RecipeId = created.RecipeId,
                    IngredientId = created.IngredientId,
                    Quantity = created.Quantity,
                    Unit = created.Unit,
                    //CreatedAt = created.CreatedAt,
                    //UpdatedAt = created.UpdatedAt
                };
            }
            catch
            {
                throw;
            }
        }

        public RecipeIngredientDto UpdateRecipeIngredient(UpdateRecipeIngredientRequestDto dto)
        {
            try
            {
                var existing = recipeIngredientRepository.FindRecipeIngredient(dto.RecipeId, dto.IngredientId);
                if (existing == null) throw new InvalidOperationException($"Recipe ingredient not found. RecipeId: {dto.RecipeId}, IngredientId: {dto.IngredientId}");

                existing.Quantity = dto.Quantity;
                existing.Unit = dto.Unit;
                //existing.UpdatedAt = DateTime.UtcNow;

                var updated = recipeIngredientRepository.UpdateRecipeIngredient(existing);

                return new RecipeIngredientDto
                {
                    RecipeId = updated.RecipeId,
                    IngredientId = updated.IngredientId,
                    Quantity = updated.Quantity,
                    Unit = updated.Unit,
                    //CreatedAt = updated.CreatedAt,
                    //UpdatedAt = updated.UpdatedAt
                };
            }
            catch
            {
                throw;
            }
        }

        public string DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            try
            {
                var deleted = recipeIngredientRepository.DeleteRecipeIngredient(recipeId, ingredientId);
                if (!deleted) throw new InvalidOperationException("Recipe ingredient not found.");
                return "Deleted successfully.";
            }
            catch
            {
                throw;
            }
        }
    }
}
