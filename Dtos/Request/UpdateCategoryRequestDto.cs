using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class UpdateCategoryRequestDto
    {
        [Required(ErrorMessage = "Category ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }
    }
}
