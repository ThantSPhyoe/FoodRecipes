using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos.Request
{
    public class UpdateUserRequestDto
    {
        [Required(ErrorMessage = "User ID is required.")]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
