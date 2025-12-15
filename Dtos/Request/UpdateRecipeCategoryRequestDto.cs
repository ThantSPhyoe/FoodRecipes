using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class UpdateRecipeCategoryRequestDto
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int NewCategoryId { get; set; }
    }
}