using FoodRecipe.Repositories;
using FoodRecipe.Models;
using FoodRecipe.Dtos;
using FoodRecipe.Utils;
using Bedrock.Shared.Configuration;

namespace FoodRecipe.Service
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        HashData Hash = new HashData();

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserDto> GetAllUsers()
        {
            try
            {
                List<User> users = userRepository.GetAllUsers();
                return users.Select(user => new UserDto
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Email = user.Email
                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserDto FindUserById(int id)
        {
            try
            {
                User user = userRepository.FindUserById(id);
                if (user == null)
                {
                    throw new InvalidOperationException($"ユーザーが見つかりません。ID: {id}");
                }
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string DeleteUserById(int Id)
        {
            try
            {
                bool isDelete = userRepository.DeleteUserById(Id);
                if (!isDelete)
                {
                    throw new InvalidOperationException($"ユーザーの削除に失敗しました。ID: {Id}");
                }

                return "ユーザーの削除に成功しました。";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User CreateUser(User user)
        {
            try
            {
                bool isExist = userRepository.FindUserById(user.Id) != null;
                if (isExist)
                {
                    throw new InvalidOperationException($"ユーザーは既に存在します。ID: {user.Id}");
                }
                string hashedPassword = Hash.HashPassword(user.Password);
                User newUser = userRepository.CreateUser(new User
                {
                    Password = hashedPassword,
                    Email = user.Email,
                    Username = user.Username,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                return newUser;
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
