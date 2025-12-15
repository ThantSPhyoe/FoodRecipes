using FoodRecipe.Controllers.BaseController;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipe.Controllers
{
    [Route("api/v1/recipeIngredient")]
    [ApiController]
    public class RecipeIngredientController : ApiBaseController
    {
        private readonly RecipeIngredientService recipeIngredientService;

        public RecipeIngredientController(RecipeIngredientService recipeIngredientService)
        {
            this.recipeIngredientService = recipeIngredientService;
        }

        [HttpPost]
        public IActionResult CreateRecipeIngredient([FromBody] CreateRecipeIngredientRequestDto createDto)
        {
            try
            {
                var result = recipeIngredientService.CreateRecipeIngredient(createDto);
                return Sucess(result);
            }
            catch (InvalidOperationException ioe)
            {
                return UnprocessableEntity(ioe.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateRecipeIngredient([FromBody] UpdateRecipeIngredientRequestDto updateDto)
        {
            try
            {
                var result = recipeIngredientService.UpdateRecipeIngredient(updateDto);
                return Sucess(result);
            }
            catch (InvalidOperationException ioe)
            {
                return NotFound(ioe.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpDelete("{recipeId}/{ingredientId}")]
        public IActionResult DeleteRecipeIngredient(int recipeId, int ingredientId)
        {
            try
            {
                var message = recipeIngredientService.DeleteRecipeIngredient(recipeId, ingredientId);
                return Sucess(message);
            }
            catch (InvalidOperationException ioe)
            {
                return NotFound(ioe.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}
