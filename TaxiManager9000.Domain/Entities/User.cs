using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public User(string username, string password, Roles role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public override string Print()
        {
            return $"Id: {Id} Username: {Username} Role: {Role}";
        }
    }
}
