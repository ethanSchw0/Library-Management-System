using LibraryManagementSystem.src.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main()
        {
            using var context = new LibraryContext();
            context.Database.EnsureCreated();

            // Create default admin if none exists
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = new LoginService(context)
                        .GetType()
                        .GetMethod("HashPassword", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                        .Invoke(new LoginService(context), new object[] { "admin123" })!.ToString(),
                    Role = "Admin"
                });
                context.SaveChanges();
            }

            var loginService = new LoginService(context);
            var loginUI = new LoginUI(loginService);
            loginUI.DisplayLogin();
        }
    }

}
