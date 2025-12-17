using FoodRecipe.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class UpdateRecipeRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DifficultyLevel Difficulty { get; set; }

        public string ImageUrl { get; set; }

        public string ServeSize { get; set; }

        public string VideoUrl { get; set; }

        public string TimeRequired { get; set; }

        [Required]
        public required int UserId { get; set; }
    }
}