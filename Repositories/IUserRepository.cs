using FoodRecipe.Models;
using FoodRecipe.Dtos;

namespace FoodRecipe.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User FindUserById(int Id);

        User FindUserByEmail(string email);

        bool DeleteUserById(int id);

        User CreateUser(User userDto);

        User UpdateUser(User userDto);
    }
}
