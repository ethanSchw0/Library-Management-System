using System;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class LoginForm : Form
    {
        private TextBox txtEmail = new TextBox { PlaceholderText = "Email", Width = 260 };
        private TextBox txtPassword = new TextBox { PlaceholderText = "Password", UseSystemPasswordChar = true, Width = 260 };
        private Button btnLogin = new Button { Text = "Login", Width = 260 };
        private Label lblMsg = new Label { AutoSize = true, ForeColor = System.Drawing.Color.Firebrick };

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Library — Login";
            this.Width = 360;
            this.Height = 240;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            BuildUi();
        }

        private void BuildUi()
        {
            var panel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(20, 20, 20, 20) };
            panel.Controls.Add(new Label { Text = "Sign in", AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold) });
            panel.Controls.Add(txtEmail);
            panel.Controls.Add(txtPassword);
            panel.Controls.Add(btnLogin);
            panel.Controls.Add(lblMsg);
            Controls.Add(panel);

            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblMsg.Text = "";
            using var db = new LibraryContext();
            var user = db.Users.FirstOrDefault(u => u.Email == txtEmail.Text && u.Password == txtPassword.Text);
            if (user == null)
            {
                lblMsg.Text = "Invalid email or password.";
                return;
            }

            var main = new MainForm(user);
            main.FormClosed += (_, __) => this.Show();
            this.Hide();
            main.Show();
        }
    }
}
