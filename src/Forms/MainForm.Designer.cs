namespace LibraryManagementSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabLoans;
        private System.Windows.Forms.TabPage tabAdmin;

        // Search
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.ColumnHeader colResTitle;
        private System.Windows.Forms.ColumnHeader colResAuthor;
        private System.Windows.Forms.ColumnHeader colResIsbn;

        // Loans
        private System.Windows.Forms.ListView lvLoans;
        private System.Windows.Forms.ColumnHeader colLoanTitle;
        private System.Windows.Forms.ColumnHeader colLoanDue;
        private System.Windows.Forms.ColumnHeader colLoanReturned;
        private System.Windows.Forms.Button btnReturn;

        // Admin
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.ListView lvBooks;
        private System.Windows.Forms.ColumnHeader colBookTitle;
        private System.Windows.Forms.ColumnHeader colBookAuthor;
        private System.Windows.Forms.ColumnHeader colBookIsbn;
        private System.Windows.Forms.Button btnDeleteBook;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.lvResults = new System.Windows.Forms.ListView();
            this.colResTitle = new System.Windows.Forms.ColumnHeader();
            this.colResAuthor = new System.Windows.Forms.ColumnHeader();
            this.colResIsbn = new System.Windows.Forms.ColumnHeader();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.tabLoans = new System.Windows.Forms.TabPage();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lvLoans = new System.Windows.Forms.ListView();
            this.colLoanTitle = new System.Windows.Forms.ColumnHeader();
            this.colLoanDue = new System.Windows.Forms.ColumnHeader();
            this.colLoanReturned = new System.Windows.Forms.ColumnHeader();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.lvBooks = new System.Windows.Forms.ListView();
            this.colBookTitle = new System.Windows.Forms.ColumnHeader();
            this.colBookAuthor = new System.Windows.Forms.ColumnHeader();
            this.colBookIsbn = new System.Windows.Forms.ColumnHeader();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabLoans.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSearch);
            this.tabMain.Controls.Add(this.tabLoans);
            this.tabMain.Controls.Add(this.tabAdmin);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(884, 561);
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.btnBorrow);
            this.tabSearch.Controls.Add(this.lvResults);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Controls.Add(this.txtQuery);
            this.tabSearch.Location = new System.Drawing.Point(4, 29);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(876, 528);
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(18, 18);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.PlaceholderText = "Search title/author/ISBN...";
            this.txtQuery.Size = new System.Drawing.Size(640, 27);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(674, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvResults
            // 
            this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResTitle, this.colResAuthor, this.colResIsbn});
            this.lvResults.FullRowSelect = true;
            this.lvResults.GridLines = true;
            this.lvResults.Location = new System.Drawing.Point(18, 63);
            this.lvResults.MultiSelect = false;
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(840, 409);
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // colResTitle
            // 
            this.colResTitle.Text = "Title";
            this.colResTitle.Width = 400;
            // 
            // colResAuthor
            // 
            this.colResAuthor.Text = "Author";
            this.colResAuthor.Width = 220;
            // 
            // colResIsbn
            // 
            this.colResIsbn.Text = "ISBN";
            this.colResIsbn.Width = 160;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrow.Location = new System.Drawing.Point(764, 486);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(94, 29);
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // tabLoans
            // 
            this.tabLoans.Controls.Add(this.btnReturn);
            this.tabLoans.Controls.Add(this.lvLoans);
            this.tabLoans.Location = new System.Drawing.Point(4, 29);
            this.tabLoans.Name = "tabLoans";
            this.tabLoans.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoans.Size = new System.Drawing.Size(876, 528);
            this.tabLoans.Text = "My Loans";
            this.tabLoans.UseVisualStyleBackColor = true;
            // 
            // lvLoans
            // 
            this.lvLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLoans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLoanTitle, this.colLoanDue, this.colLoanReturned});
            this.lvLoans.FullRowSelect = true;
            this.lvLoans.GridLines = true;
            this.lvLoans.Location = new System.Drawing.Point(18, 18);
            this.lvLoans.MultiSelect = false;
            this.lvLoans.Name = "lvLoans";
            this.lvLoans.Size = new System.Drawing.Size(840, 477);
            this.lvLoans.View = System.Windows.Forms.View.Details;
            // 
            // colLoanTitle
            // 
            this.colLoanTitle.Text = "Title";
            this.colLoanTitle.Width = 420;
            // 
            // colLoanDue
            // 
            this.colLoanDue.Text = "Due";
            this.colLoanDue.Width = 160;
            // 
            // colLoanReturned
            // 
            this.colLoanReturned.Text = "Returned";
            this.colLoanReturned.Width = 160;
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(764, 501);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(94, 29);
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.btnDeleteBook);
            this.tabAdmin.Controls.Add(this.lvBooks);
            this.tabAdmin.Controls.Add(this.btnAddBook);
            this.tabAdmin.Controls.Add(this.txtIsbn);
            this.tabAdmin.Controls.Add(this.txtAuthor);
            this.tabAdmin.Controls.Add(this.txtTitle);
            this.tabAdmin.Location = new System.Drawing.Point(4, 29);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(876, 528);
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(18, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Title";
            this.txtTitle.Size = new System.Drawing.Size(300, 27);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(324, 18);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.PlaceholderText = "Author";
            this.txtAuthor.Size = new System.Drawing.Size(200, 27);
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(530, 18);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.PlaceholderText = "ISBN";
            this.txtIsbn.Size = new System.Drawing.Size(150, 27);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(686, 17);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(94, 29);
            this.btnAddBook.Text = "Add";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // lvBooks
            // 
            this.lvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBookTitle, this.colBookAuthor, this.colBookIsbn});
            this.lvBooks.FullRowSelect = true;
            this.lvBooks.GridLines = true;
            this.lvBooks.Location = new System.Drawing.Point(18, 63);
            this.lvBooks.MultiSelect = false;
            this.lvBooks.Name = "lvBooks";
            this.lvBooks.Size = new System.Drawing.Size(840, 452);
            this.lvBooks.View = System.Windows.Forms.View.Details;
            // 
            // colBookTitle
            // 
            this.colBookTitle.Text = "Title";
            this.colBookTitle.Width = 420;
            // 
            // colBookAuthor
            // 
            this.colBookAuthor.Text = "Author";
            this.colBookAuthor.Width = 220;
            // 
            // colBookIsbn
            // 
            this.colBookIsbn.Text = "ISBN";
            this.colBookIsbn.Width = 160;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBook.Location = new System.Drawing.Point(764, 521);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(94, 0); // invisible spacer; designer keeps size
            this.btnDeleteBook.Visible = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tabLoans.ResumeLayout(false);
            this.tabAdmin.ResumeLayout(false);
            this.tabAdmin.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
