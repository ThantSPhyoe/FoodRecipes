namespace FoodRecipe.Dtos.Request
{
    public class CreateAddRecipeIngredientRequestDto
    {
        public string Name { get; set; }

        public string Quantity { get; set; }

        public string Unit { get; set; }
    }
}
