using demo_3layer1.Models;
using System;
using System.Linq;
using demo_3layer1.Security;

namespace demo_3layer1.DataAccess
{
    public class UserDataAccess
    {
        private readonly AppDbContext _context = new AppDbContext();

        public User GetUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return null;

            string stored = user.Password ?? string.Empty;

            if (PasswordHasher.IsHashed(stored))
            {
                return PasswordHasher.Verify(stored, password) ? user : null;
            }

            // Legacy plaintext support: compare then upgrade on success
            if (string.Equals(stored, password, StringComparison.Ordinal))
            {
                user.Password = PasswordHasher.HashPassword(password);
                _context.SaveChanges();
                return user;
            }

            return null;
        }
        public void SeedDefaultUsers()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User { Id = 1, Username = "admin1", Password = PasswordHasher.HashPassword("123456"), Role = "Admin" });
                _context.Users.Add(new User { Id = 2, Username = "teacher1", Password = PasswordHasher.HashPassword("123456"), Role = "Teacher" });
                _context.Users.Add(new User { Id = 3, Username = "student1", Password = PasswordHasher.HashPassword("123456"), Role = "Student" });
                _context.SaveChanges();
            }
        }
    }
}
