using demo_3layer1.DataAccess;
using demo_3layer1.Models;

namespace demo_3layer1.Business
{
    public class UserBusiness
    {
        private readonly UserDataAccess _userDataAccess = new UserDataAccess();

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            // Gọi xuống DAL kiểm tra user
            var user = _userDataAccess.GetUser(username, password);
            return user;
        }
        public void SeedDefaultUsers()
        {
            _userDataAccess.SeedDefaultUsers();
        }
    }
}
