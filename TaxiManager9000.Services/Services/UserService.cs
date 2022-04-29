using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Services.Helpers;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public User? Login()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Taxi Manager 9000\nLogin: ");
                Console.Write("Username: ");
                string usernameInput = Console.ReadLine();
                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                User? user = Db?.GetAll().SingleOrDefault(user =>
                        user.Username == usernameInput && user.Password == passwordInput);

                if (user == null)
                {
                    Console.Clear();
                    StringFormatter.Colorize("Login failed, please try again", ConsoleColor.Red);
                    continue;
                }

                Console.Clear();
                StringFormatter.Colorize($"Successfully logged in, welcome {user.Username}!", ConsoleColor.Green);
                return user;
            }
        }

        public void ChangePassword(User user)
        {
            Console.Clear();
            Console.WriteLine("Change password: ");
            while (true)
            {
                Console.Write("Enter old password: ");
                string oldPassword = Console.ReadLine();

                Console.Write("Enter new password: ");
                string newPassword = Console.ReadLine();

                if (user != null)
                {

                    if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                    {
                        Console.Clear();
                        StringFormatter.Colorize("Neither of the inputs can be empty, try again", ConsoleColor.Red);
                        continue;
                    }

                    if (user.Password != oldPassword || oldPassword == newPassword)
                    {
                        Console.Clear();
                        StringFormatter.Colorize("Invalid old password", ConsoleColor.Red);
                        continue;
                    }

                    user.Password = newPassword;
                    return;
                }
            }
        }

        public void AddUser()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("New user registration: ");

                Console.Write("Enter username: ");
                string usernameInput = Console.ReadLine();

                List<User> users = Db.GetAll();

                if (users.Any(x => x.Username == usernameInput))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Username already exists", ConsoleColor.Red);
                    continue;
                }

                if (string.IsNullOrEmpty(usernameInput))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Invalid username input, try again", ConsoleColor.Red);
                    continue;
                }

                Console.Write("Enter password: ");
                string passwordInput = Console.ReadLine();

                if (string.IsNullOrEmpty(passwordInput))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Invalid password input, try again", ConsoleColor.Red);
                    continue;
                }

                Console.WriteLine("User role:\n1. Administrator\n2. Maintanance\n3. Manager");
                string roleInput = Console.ReadLine();

                Roles role;
                switch (roleInput)
                {
                    case "1":
                        role = Roles.Administrator;
                        break;
                    case "2":
                        role = Roles.Maintenance;
                        break;
                    case "3":
                        role = Roles.Manager;
                        break;
                    default:
                        StringFormatter.Colorize("Invalid role option, try again", ConsoleColor.Red);
                        continue;
                }

                bool userAdded = Db.Add(new User(usernameInput, passwordInput, role));

                if(userAdded)
                {
                    return;
                }
            }
        }

        public void RemoveUser(User user)
        {
            Console.WriteLine("Terminate user: ");

            List<User> users = Db.GetAll();
            int id;

            foreach (User u in users)
            {
                Console.WriteLine(u.Print());
            }           

            while (true)
            {
                Console.Write("Enter user id: ");
                string idInput = Console.ReadLine();

                if (!int.TryParse(idInput, out id))
                {
                    Console.Clear();
                    StringFormatter.Colorize("Enter a valid id", ConsoleColor.Red);
                    continue;
                }
             
                if (user.Id == id)
                {
                    StringFormatter.Colorize("You can't remove yourself", ConsoleColor.Red);
                    continue;
                }

                bool userRemoved = Db.RemoveById(id);

                if (userRemoved)
                {
                    return;
                }
            }
        }
    }
}
