using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateIngredientRequestDto
    {
        [Required(ErrorMessage = "Ingredient name is required.")]
        public string Name { get; set; }
    }
}
