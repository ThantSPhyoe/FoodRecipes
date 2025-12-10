using FoodRecipe.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
