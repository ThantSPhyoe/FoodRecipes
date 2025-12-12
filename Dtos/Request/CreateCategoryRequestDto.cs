using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class CreateCategoryRequestDto
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }
    }
}
