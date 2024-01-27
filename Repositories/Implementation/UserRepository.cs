using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;

namespace CodePulse.API.Repositories.Implementation
{
    // UserRepository.cs
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void AddRoleToUser(int userId, string roleName)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                var userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id.ToString(),
                    RoleId = roleName
                };


                _context.SaveChanges();
            }
        }
    }

}
