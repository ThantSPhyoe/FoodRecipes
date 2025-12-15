using FoodRecipe.Models;

namespace FoodRecipe.Dtos.Response
{
    public class RecipeDataForHomePageResponse
    {
        public int RecipesCount { get; set; }

        public List<CategoryDto> Categories { get; set; }

        public List<RecipeDto> LatestRecipes { get; set; }
    }
}
