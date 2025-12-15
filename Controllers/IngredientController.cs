using FoodRecipe.Controllers.BaseController;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IngredientController : ApiBaseController
    {
        private readonly IngredientService ingredientService;
        public IngredientController(IngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [HttpPost]
        public IActionResult CreateIngredient([FromBody] CreateIngredientRequestDto createIngredientRequestDto)
        {

            try
            {
                var result = ingredientService.CreateIngredient(createIngredientRequestDto);
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
        public IActionResult UpdateIngredient([FromBody] UpdateIngredientRequestDto updateIngredientRequestDto)
        {
            try
            {
                var result = ingredientService.UpdateIngredient(updateIngredientRequestDto);
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

        //[HttpDelete("{Id}")] will work soon
        //public IActionResult DeleteCategory(int Id)
        //{
        //    try
        //    {
        //        var result = categoryService.(Id);
        //        return Sucess(result);
        //    }
        //    catch (InvalidOperationException ioe)
        //    {
        //        return NotFound(ioe.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Error(ex.Message);
        //    }
        //}

        [HttpGet]
        public IActionResult GetAllIngredients()
        {
            try
            {
                var result = ingredientService.GetAllIngredients();
                return Sucess(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetIngredientById(int Id)
        {
            try
            {
                var result = ingredientService.GetIngredientById(Id);
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
    }
}
