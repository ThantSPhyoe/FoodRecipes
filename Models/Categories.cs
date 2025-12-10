using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RecipeCategories> RecipeCategories { get; set; }
    }
}
