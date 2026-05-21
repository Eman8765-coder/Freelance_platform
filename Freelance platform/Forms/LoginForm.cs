using System.Windows.Forms;
using Freelance_Platform.Database;
using Freelance_Platform.Models;
using System;
using Freelance_Platform;

namespace Freelance_Platform.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both email and password.";
                return;
            }

            User? user = _userRepo.Login(email, password);

            if (user == null)
            {
                lblError.Text = "Invalid email or password.";
                txtPassword.Clear();
                return;
            }

            // Save logged in user to Session
            Freelance_Platform.Session.CurrentUser = user;
            Freelance_Platform.Session.ClientId = _userRepo.GetClientId(user.UserId);
            Freelance_Platform.Session.FreelancerId = _userRepo.GetFreelancerId(user.UserId);
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}