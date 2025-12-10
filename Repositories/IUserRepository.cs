using FoodRecipe.Models;
using FoodRecipe.Dtos;

namespace FoodRecipe.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User FindUserById(int Id);

        bool DeleteUserById(int id);

        User CreateUser(User userDto);

        User UpdateUser(int id, User userDto);
    }
}
