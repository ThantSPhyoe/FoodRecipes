using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class Categories
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<RecipeCategories> RecipeCategories { get; set; }
    }
}
