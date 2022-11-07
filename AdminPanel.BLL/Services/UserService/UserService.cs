using AdminPanel.DAL;
using AdminPanel.Entities;
using AdminPanel.Models;

namespace AdminPanel.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        // Dependency injection here.
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            var userEntity = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userEntity == null)
            {
                throw new Exception("User with given id not found. ");
            }

            var user = new User
            {
                Id = userEntity.Id,
                Username = userEntity.Username
            };

            return user;
        }

        public List<User> GetUsers()
        {
            var users = _context.Users.Select(
                x => new User
                {
                    Id = x.Id,
                    Username = x.Username
                }
                ).ToList();

            return users;
        }

        public void SaveUser(UserEntity userEntity)
        {
            if (userEntity.Username == null)
            {
                throw new Exception("Can not add empty user. ");
            }

            var newUser = new UserEntity
            {
                Id = userEntity.Id,
                Username = userEntity.Username
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void UpdateUser(UserEntity userEntity)
        {
            if (!_context.Users.Any(x => x.Id == userEntity.Id))
            {
                throw new Exception($"User with id {userEntity.Id} - not found. ");
            }

            _context.Users.Update(userEntity);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found. ");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

        }
    }
}
