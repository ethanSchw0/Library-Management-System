using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Email { get; set; } = "";

        [MaxLength(80)]
        public string Password { get; set; } = "";

        [MaxLength(120)]
        public string FullName { get; set; } = "";

        // "Member" or "Admin"
        [MaxLength(20)]
        public string Role { get; set; } = "Member";

        public override string ToString() => $"{FullName} ({Email}) - {Role}";
    }

    public class Book
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; } = "";

        [MaxLength(200)]
        public string Author { get; set; } = "";

        [MaxLength(40)]
        public string Isbn { get; set; } = "";

        public override string ToString() => $"{Title} — {Author}";
    }

    public class Loan
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime BorrowedAt { get; set; } = DateTime.Now;
        public DateTime DueAt { get; set; } = DateTime.Now.AddDays(14);
        public DateTime? ReturnedAt { get; set; }

        public bool IsReturned => ReturnedAt != null;
    }
}


