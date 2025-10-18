using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LibraryManagementSystem.src.Model
{
    public class LoginService
    {
        private readonly LibraryContext _context;

        public LoginService(LibraryContext context)
        {
            _context = context;
        }

        public User? AuthenticateUser(string username, string password)
        {
            // Hash password to match with stored hash
            string hashed = HashPassword(password);

            // LINQ query to find a matching user
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == hashed);

            return user; // returns null if invalid login
        }

        private string HashPassword(string password)
        {
            // Simple SHA256 hash for demo (replace with BCrypt for real projects)
            using (SHA256 sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
