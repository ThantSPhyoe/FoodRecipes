namespace FoodRecipe.Models
{
    public class RecipeIngredients
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredients Ingredient { get; set; }

        public string Quantity { get; set; }
        public string Unit { get; set; }

        
        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

    }
}
