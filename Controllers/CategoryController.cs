using FoodRecipe.Controllers.BaseController;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ApiBaseController
    {
        private readonly CategoryService categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
        {

            try
            {
                var result = categoryService.CreateCategory(createCategoryRequestDto);
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
        public IActionResult UpdateCategory([FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            try
            {
                var result = categoryService.UpdateCategory(updateCategoryRequestDto);
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
        public IActionResult GetAllCategories()
        {
            try
            {
                var result = categoryService.GetAllCategories();
                return Sucess(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetCategoryById(int Id)
        {
            try
            {
                var result = categoryService.GetCategoryById(Id);
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
