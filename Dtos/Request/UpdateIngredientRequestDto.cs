using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class UpdateIngredientRequestDto
    {
        [Required(ErrorMessage = "Ingredient ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingredient name is required.")]
        public string Name { get; set; }
    }
}
