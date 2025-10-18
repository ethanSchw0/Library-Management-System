using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.src.Model
{
    public class LoginUI
    {
        private readonly LoginService _loginService;

        public LoginUI(LoginService loginService)
        {
            _loginService = loginService;
        }

        public void DisplayLogin()
        {
            Console.Clear();
            Console.WriteLine("=== Digital Library Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine()!;
            Console.Write("Password: ");
            string password = ReadPassword();

            var user = _loginService.AuthenticateUser(username, password);

            if (user != null)
            {
                Console.WriteLine($"\n✅ Welcome, {user.Username}! Role: {user.Role}");
                if (user.Role == "Admin")
                {
                    new AdminDashboard().Show();
                }
                else
                {
                    new UserDashboard().Show(user);
                }
            }
            else
            {
                Console.WriteLine("\n❌ Invalid username or password. Try again.");
            }
        }

        private string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass[0..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            return pass;
        }
    }

}
