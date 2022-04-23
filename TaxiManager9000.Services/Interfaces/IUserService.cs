using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IUserService
    {
        User? Login();
        void ChangePassword(User user);
    }
}
