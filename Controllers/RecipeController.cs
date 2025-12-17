using FoodRecipe.Controllers.BaseController;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FoodRecipe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecipeController : ApiBaseController
    {
        private readonly RecipeService recipeService;

        public RecipeController(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody] CreateRecipeRequestDto createDto)
        {
            try
            {
                var result = recipeService.CreateRecipe(createDto);
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
        public IActionResult UpdateRecipe([FromBody] UpdateRecipeRequestDto updateDto)
        {
            try
            {
                var result = recipeService.UpdateRecipe(updateDto);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            try
            {
                var message = recipeService.DeleteRecipe(id);
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

        [HttpGet]
        public IActionResult SearchRecipes([FromQuery] string? q)
        {
            try
            {
                var results = recipeService.SearchRecipes(q);
                return Sucess(results);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            try
            {
                var result = recipeService.GetRecipeById(id);
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

        [HttpGet("HomePageInfo")]
        public IActionResult GetAllInformationForHomePage()
        {
            try
            {
                var result = recipeService.GetAllDataForHomePage();
                return Sucess(result);
            }catch(Exception ex)
            {
                return Error(ex.Message);
            }
        }

        public IActionResult GetAllRecipes()
        {
            try
            {

                return Sucess("OK");
            }catch(Exception ex)
            {
                return Error(ex.Message);
            }
        }

        public IActionResult AddRecipe([FromBody] CreateAddRecipesRequestDto dto)
        {
            try
            {
                return Sucess('OK');
            }catch(Exception ex)
            {
                return Error(ex.Message);
            }
        } 
    }
}