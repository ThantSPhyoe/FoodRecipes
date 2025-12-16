using FoodRecipe.Models;

namespace FoodRecipe.Dtos
{
    public class HomePageDto
    {
        public int Count { get; set; }

        public List<CategoryDto> Category { get; set; }

        public List<RecipeDto> Recipes { get; set; }
    }
}
