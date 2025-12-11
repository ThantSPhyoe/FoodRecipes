using FoodRecipe.Controllers.BaseController;
using FoodRecipe.Dtos;
using FoodRecipe.Dtos.Request;
using FoodRecipe.Models;
using FoodRecipe.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipe.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        private readonly UserService userService;


        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<UserDto> users = userService.GetAllUsers();
                return Sucess(users);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult FindUserById(int id)
        {
            try
            {
                UserDto user = userService.FindUserById(id);
                return Sucess(user);
            }
            catch (InvalidOperationException Ioe)
            {
                return NotFound(Ioe.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteUserById(int Id)
        {
            try
            {
                string message = userService.DeleteUserById(Id);
                return Sucess(message);
            }
            catch(InvalidOperationException Ioe)
            {
                return NotFound(Ioe.Message);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserRequestDto userDto)
        {
            try
            {
                var result = userService.CreateUser(userDto);
                if (result == null) return UnprocessableEntity();
                return Sucess(new UserDto
                {
                    Id = result.Id,
                    UserName = result.Username,
                    Email = result.Email
                });
            }catch(InvalidOperationException Ioe)
            {
                return Conflict(Ioe.Message);
            }
            catch(Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}
