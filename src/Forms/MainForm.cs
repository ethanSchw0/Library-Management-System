using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;

        public MainForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            this.Text = $"Library – {_currentUser.FullName} [{_currentUser.Role}]";

            // If not admin, hide Admin tab
            if (!string.Equals(_currentUser.Role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                tabMain.TabPages.Remove(tabAdmin);
            }

            // Right-click delete on Admin book list
            var ctx = new ContextMenuStrip();
            var miDelete = new ToolStripMenuItem("Delete Book", null, (_, __) => DeleteSelectedBook());
            ctx.Items.Add(miDelete);
            lvBooks.ContextMenuStrip = ctx;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await RefreshBooksAsync();
            await RefreshLoansAsync();
        }

        // --- Search tab ---
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var q = txtQuery.Text.Trim();
            if (q.Length < 2) { MessageBox.Show("Type at least 2 characters."); return; }

            btnSearch.Enabled = false;
            lvResults.Items.Clear();

            try
            {
                var results = await GoogleBooksService.SearchAsync(q);
                foreach (var r in results)
                {
                    var item = new ListViewItem(new[] { r.Title, r.Author, r.Isbn }) { Tag = r };
                    lvResults.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message);
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private async void btnBorrow_Click(object sender, EventArgs e)
        {
            if (lvResults.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a book from results.");
                return;
            }

            var r = (GoogleBooksService.GoogleBook)lvResults.SelectedItems[0].Tag;

            using var db = new LibraryContext();
            // Ensure the book exists (by ISBN if possible; otherwise title/author)
            Book? book = null;

            if (!string.IsNullOrWhiteSpace(r.Isbn))
                book = db.Books.FirstOrDefault(b => b.Isbn == r.Isbn);

            if (book == null)
                book = db.Books.FirstOrDefault(b => b.Title == r.Title && b.Author == r.Author);

            if (book == null)
            {
                book = new Book { Title = r.Title, Author = r.Author, Isbn = r.Isbn ?? "" };
                db.Books.Add(book);
                await db.SaveChangesAsync();
            }

            // Create a loan
            var loan = new Loan
            {
                UserId = _currentUser.Id,
                BookId = book.Id,
                BorrowedAt = DateTime.Now,
                DueAt = DateTime.Now.AddDays(14)
            };
            db.Loans.Add(loan);
            await db.SaveChangesAsync();

            MessageBox.Show($"Borrowed: {book.Title}\nDue: {loan.DueAt:d}");
            await RefreshLoansAsync();
        }

        // --- Loans tab ---
        private async Task RefreshLoansAsync()
        {
            lvLoans.Items.Clear();
            using var db = new LibraryContext();

            var loans = db.Loans
                .Where(l => l.UserId == _currentUser.Id)
                .Select(l => new
                {
                    l.Id,
                    Title = l.Book!.Title,
                    l.DueAt,
                    l.ReturnedAt
                })
                .ToList();

            foreach (var l in loans)
            {
                var item = new ListViewItem(new[]
                {
                    l.Title,
                    l.DueAt.ToShortDateString(),
                    l.ReturnedAt?.ToShortDateString() ?? "-"
                })
                { Tag = l.Id };
                lvLoans.Items.Add(item);
            }
            await Task.CompletedTask;
        }

        private async void btnReturn_Click(object sender, EventArgs e)
        {
            if (lvLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a loan to return.");
                return;
            }

            var loanId = (int)lvLoans.SelectedItems[0].Tag;
            using var db = new LibraryContext();
            var loan = db.Loans.FirstOrDefault(x => x.Id == loanId);
            if (loan == null) return;

            if (loan.ReturnedAt != null)
            {
                MessageBox.Show("Already returned.");
                return;
            }

            loan.ReturnedAt = DateTime.Now;
            await db.SaveChangesAsync();
            await RefreshLoansAsync();
        }

        // --- Admin tab ---
        private async Task RefreshBooksAsync()
        {
            lvBooks.Items.Clear();
            using var db = new LibraryContext();
            var books = db.Books
                .Select(b => new { b.Id, b.Title, b.Author, b.Isbn })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                var item = new ListViewItem(new[] { b.Title, b.Author, b.Isbn }) { Tag = b.Id };
                lvBooks.Items.Add(item);
            }
            await Task.CompletedTask;
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            if (!IsAdmin()) return;

            var title = txtTitle.Text.Trim();
            var author = txtAuthor.Text.Trim();
            var isbn = txtIsbn.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Title is required."); return;
            }

            using var db = new LibraryContext();
            db.Books.Add(new Book { Title = title, Author = author, Isbn = isbn });
            await db.SaveChangesAsync();

            txtTitle.Text = txtAuthor.Text = txtIsbn.Text = "";
            await RefreshBooksAsync();
        }

        private async void DeleteSelectedBook()
        {
            if (!IsAdmin()) return;
            if (lvBooks.SelectedItems.Count == 0) return;

            var id = (int)lvBooks.SelectedItems[0].Tag;
            using var db = new LibraryContext();

            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return;

            // Prevent deleting if there are active loans
            var hasActiveLoans = db.Loans.Any(l => l.BookId == id && l.ReturnedAt == null);
            if (hasActiveLoans)
            {
                MessageBox.Show("Cannot delete: book has active loans.");
                return;
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();
            await RefreshBooksAsync();
        }

        private bool IsAdmin()
            => string.Equals(_currentUser.Role, "Admin", StringComparison.OrdinalIgnoreCase);
    }
}



