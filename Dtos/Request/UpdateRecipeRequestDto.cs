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

        public string Difficulty { get; set; }

        public string ImageUrl { get; set; }
    }
}