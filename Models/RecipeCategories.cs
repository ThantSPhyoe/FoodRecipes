using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class RecipeCategories
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}
