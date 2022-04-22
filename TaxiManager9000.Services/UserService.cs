using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public User? Login(string username, string password)
        {
            return Db?.GetAll().SingleOrDefault(user =>
                user.Username == username && user.Password == password);
        }

        public bool ChangePassword(int id, string oldPassword, string newPassword)
        {
            User user = Db.GetById(id);

            if (user != null)
            {
                if (user.Password != oldPassword || oldPassword == newPassword)
                {
                    return false;
                }

                user.Password = newPassword;
                return true;
            }

            return false;
        }
    }
}
