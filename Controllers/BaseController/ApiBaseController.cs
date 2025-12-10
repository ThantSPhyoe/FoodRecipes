using FoodRecipe.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipe.Controllers.BaseController
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {

        protected IActionResult Sucess<T>(T data, string message = "success")
        {
            return base.Ok(new ApiResponse<T>(true, message, data));
        }

        protected IActionResult Accepted<T>(T data, string message = "accpeted")
        {
            return base.Accepted(new ApiResponse<T>(true, message, data));
        }

        protected IActionResult SuccessNoContent(string message = "no content")
        {
            return base.NoContent();
        }

        protected IActionResult Fail(string message = "request fail")
        {
            return base.BadRequest(new ApiResponse<object>(false, message));
        }

        protected IActionResult Error(string message = "internal server error")
        {
            return base.StatusCode(500, new ApiResponse<object>(false, message));
        }

        protected IActionResult NotFound(string message = "resource not found")
        {
            return base.NotFound(new ApiResponse<object>(false, message));
        }

        protected IActionResult Unauthorized(string message = "unauthorized")
        {
            return base.Unauthorized(new ApiResponse<object>(false, message));
        }

        protected IActionResult Forbidden(string message = "forbidden")
        {
            return base.StatusCode(403, new ApiResponse<object>(false, message));
        }

        protected IActionResult Conflict(string message = "conflict")
        {
            return base.Conflict(new ApiResponse<object>(false, message));
        }

        protected IActionResult UnprocessableEntity(string message = "unprocessable entity")
        {
            return base.UnprocessableEntity(new ApiResponse<object>(false, message));
        }

    }
}