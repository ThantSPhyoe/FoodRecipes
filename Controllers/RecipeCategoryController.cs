using FoodRecipe.Controllers.BaseController;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FoodRecipe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecipeCategoryController : ApiBaseController
    {
        private readonly RecipeCategoryService recipeCategoryService;

        public RecipeCategoryController(RecipeCategoryService recipeCategoryService)
        {
            this.recipeCategoryService = recipeCategoryService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRecipeCategoryRequestDto dto)
        {
            try
            {
                var result = recipeCategoryService.Create(dto);
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
        public IActionResult Update([FromBody] UpdateRecipeCategoryRequestDto dto)
        {
            try
            {
                var result = recipeCategoryService.Update(dto);
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

        [HttpDelete("{recipeId}/{categoryId}")]
        public IActionResult Delete(int recipeId, int categoryId)
        {
            try
            {
                var msg = recipeCategoryService.Delete(recipeId, categoryId);
                return Sucess(msg);
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

        [HttpGet("{recipeId}")]
        public IActionResult GetByRecipe(int recipeId)
        {
            try
            {
                var result = recipeCategoryService.SearchByRecipe(recipeId);
                return Sucess(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}