using FoodRecipe.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateAddRecipesRequestDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DifficultyLevel Difficulty { get; set; }

        [Required]
        public string TimeRequired { get; set; }

        [Required]
        public string ServeSize { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one ingredient is required.")]
        public List<CreateAddRecipeIngredientRequestDto> Ingredients { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one step is required.")]
        public List<CreateAddStepRequestDto> steps { get; set; }
    }
}
