using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string ImageUrl { get; set; }

        public string ServeSize { get; set; }

        public string VideoUrl { get; set; }

        public string TimeRequired { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        public ICollection<Steps> Steps { get; set; }
        public ICollection<RecipeCategories> RecipeCategories { get; set; }
    }
}
