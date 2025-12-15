using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateRecipeCategoryRequestDto
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}