using FoodRecipe.Service;

namespace FoodRecipe.Utils.CustomExeptionHandling
{
    public class MinioException　: Exception
    {
        public MinioException(string message, Exception? inner = null) : base(message, inner) { }
    }
}
