using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IUserService
    {
        User? Login(string username, string password);
        bool ChangePassword(int id, string oldPassword, string newPassword);
    }
}
