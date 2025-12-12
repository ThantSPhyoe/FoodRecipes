using FoodRecipe.Data;
using FoodRecipe.Models;
using FoodRecipe.Utils;

namespace FoodRecipe.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User FindUserById(int Id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == Id);
            return user;
        }

        public User FindUserByEmail(string Email)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == Email);
            return user;
        }

        public bool DeleteUserById(int Id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == Id);
            if (user == null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User UpdateUser(User User)
        {
            _context.Users.Update(User);
            _context.SaveChanges();
            return User;
        }

        public User CreateUser(User user)
        {
            User _user = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Add(_user);
            _context.SaveChanges();
            return _user;
        }

    }
}
