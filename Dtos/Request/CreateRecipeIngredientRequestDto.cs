using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateRecipeIngredientRequestDto
    {
        [Required(ErrorMessage = "Recipe ID is required.")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Ingredient ID is required.")]
        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public string Quantity { get; set; }

        public string Unit { get; set; }


    }
}
