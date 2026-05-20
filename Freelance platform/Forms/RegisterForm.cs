using System;
using System.Windows.Forms;
using Freelance_Platform.Database;
using Freelance_Platform.Models;

namespace Freelance_Platform.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public RegisterForm()
        {
            InitializeComponent();
        }

        // When role dropdown changes — show/hide extra fields
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string role = cmbRole.SelectedItem?.ToString() ?? "client";

            if (role == "freelancer")
            {
                lblExtra.Text = "Experience";
                txtExtra.PlaceholderText = "e.g. 3 years web development";
                lblHourlyRate.Visible = true;
                txtHourlyRate.Visible = true;
            }
            else
            {
                lblExtra.Text = "Company Name (optional)";
                txtExtra.PlaceholderText = "Your company name";
                lblHourlyRate.Visible = false;
                txtHourlyRate.Visible = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // Validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please fill all required fields.";
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                lblError.Text = "Password must be at least 6 characters.";
                return;
            }

            string role = cmbRole.SelectedItem?.ToString() ?? "client";

            double hourlyRate = 0;
            if (role == "freelancer")
            {
                if (!double.TryParse(txtHourlyRate.Text, out hourlyRate))
                {
                    lblError.Text = "Please enter a valid hourly rate.";
                    return;
                }
            }

            // Build user object
            var user = new User
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Role = role,
                CompanyName = txtExtra.Text.Trim(),
                Experience = txtExtra.Text.Trim(),
                HourlyRate = hourlyRate
            };

            bool success = _userRepo.Register(user, txtPassword.Text);

            if (!success)
            {
                lblError.Text = "Email already exists. Please use another email.";
                return;
            }

            MessageBox.Show(
                "Account created successfully! You can now login.",
                "Registration Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}