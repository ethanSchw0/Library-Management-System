using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Ensure DB exists + seed a demo user/admin
            using (var db = new LibraryContext())
            {
                db.Database.EnsureCreated();

                if (!db.Users.Any())
                {
                    db.Users.Add(new User
                    {
                        Email = "member@lib.com",
                        Password = "password",
                        FullName = "Member One",
                        Role = "Member"
                    });
                    db.Users.Add(new User
                    {
                        Email = "admin@lib.com",
                        Password = "admin",
                        FullName = "Admin User",
                        Role = "Admin"
                    });
                    db.SaveChanges();
                }
            }

            Application.Run(new LoginForm());
        }
    }
}
