using demo_3layer1.Models;
using System;
using System.Linq;

namespace demo_3layer1.DataAccess
{
    public class UserDataAccess
    {
        private readonly AppDbContext _context = new AppDbContext();

        public User GetUser(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        public void SeedDefaultUsers()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User {Id=1, Username = "admin1", Password = "123456", Role = "Admin" });
                _context.Users.Add(new User { Id = 2, Username = "teacher1", Password = "123456", Role = "Teacher" });
                _context.Users.Add(new User { Id = 3, Username = "student1", Password = "123456", Role = "Student" });
                _context.SaveChanges();
            }
        }
    }
}
