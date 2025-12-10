using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
