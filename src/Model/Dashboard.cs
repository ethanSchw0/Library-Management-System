using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.src.Model
{
    public class AdminDashboard
    {
        public void Show()
        {
            Console.WriteLine("\n[Admin Dashboard]");
            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Users");
        }
    }

    public class UserDashboard
    {
        public void Show(User user)
        {
            Console.WriteLine($"\n[User Dashboard for {user.Username}]");
            Console.WriteLine("1. Search Books");
            Console.WriteLine("2. Borrow/Return Books");
        }
    }

}
