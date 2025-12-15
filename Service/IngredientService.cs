using FoodRecipe.Dtos;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Repositories;

namespace FoodRecipe.Service
{
    public class IngredientService
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public List<Ingredients> GetAllIngredients()
        {
            return ingredientRepository.GetAllIngredient();
        }

        public Ingredients GetIngredientById(int Id)
        {
            try
            {
                Ingredients ingredients = ingredientRepository.FindIngredientById(Id);
                if (ingredients == null) throw new InvalidOperationException($"Ingredient not found. ID: {Id}");
                return ingredients;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IngredientDto CreateIngredient(CreateIngredientRequestDto dto)
        {
            try
            {
                Ingredients ingredient = ingredientRepository.CreateIngredient(new Ingredients
                {
                    Name = dto.Name,
                });
                if (ingredient == null) throw new InvalidOperationException("Failed to create ingredient.");
                return new IngredientDto
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IngredientDto UpdateIngredient(UpdateIngredientRequestDto dto)
        {
            try
            {
                Ingredients ingredient = ingredientRepository.FindIngredientById(dto.Id);
                if (ingredient == null) throw new InvalidOperationException($"Ingredient not found. ID: {dto.Id}");
                ingredient.Name = dto.Name;
                var updatedIngredient = ingredientRepository.UpdateIngredient(ingredient);
                return new IngredientDto
                {
                    Id = updatedIngredient.Id,
                    Name = updatedIngredient.Name
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
