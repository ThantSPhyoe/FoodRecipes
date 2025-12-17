using FoodRecipe.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateRecipeRequestDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DifficultyLevel Difficulty { get; set; }

        public string ImageUrl { get; set; }

        public string ServeSize { get; set; }

        public string VideoUrl { get; set; }

        public string TimeRequired { get; set; }

        [Required(ErrorMessage = "At least one category is required")]
        public List<int> CategoryId { get; set; }


        [Required]
        public  required int UserId { get; set; }
    }
}