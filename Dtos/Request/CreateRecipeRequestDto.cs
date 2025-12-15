using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateRecipeRequestDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Difficulty { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public  required int UserId { get; set; }
    }
}