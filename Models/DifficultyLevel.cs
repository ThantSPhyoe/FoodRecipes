using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Models
{
    public enum DifficultyLevel
    {
        [Display(Name = "Easy")]
        Easy = 0,

        [Display(Name = "Medium")]
        Medium = 1,

        [Display(Name = "Hard")]
        Hard = 2
    }
}
