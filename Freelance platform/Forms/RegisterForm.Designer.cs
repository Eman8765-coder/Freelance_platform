using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblTitle = new Label();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblExtra = new Label();
            txtExtra = new TextBox();
            lblHourlyRate = new Label();
            txtHourlyRate = new TextBox();
            lblError = new Label();
            btnRegister = new Button();
            btnBack = new Button();

            panelMain.SuspendLayout();
            SuspendLayout();

            // panelMain
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Location = new Point(60, 30);
            panelMain.Size = new Size(420, 580);
            panelMain.Controls.AddRange(new Control[] {
                lblTitle,
                lblFirstName, txtFirstName,
                lblLastName,  txtLastName,
                lblEmail,     txtEmail,
                lblPhone,     txtPhone,
                lblPassword,  txtPassword,
                lblRole,      cmbRole,
                lblExtra,     txtExtra,
                lblHourlyRate,txtHourlyRate,
                lblError,
                btnRegister,  btnBack
            });

            // lblTitle
            lblTitle.Text = "Create Account";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Size = new Size(378, 36);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblFirstName
            lblFirstName.Text = "First Name";
            lblFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFirstName.Location = new Point(20, 65);
            lblFirstName.Size = new Size(185, 18);

            // txtFirstName
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(20, 85);
            txtFirstName.Size = new Size(185, 28);
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.PlaceholderText = "First name";

            // lblLastName
            lblLastName.Text = "Last Name";
            lblLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLastName.Location = new Point(215, 65);
            lblLastName.Size = new Size(185, 18);

            // txtLastName
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(215, 85);
            txtLastName.Size = new Size(185, 28);
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.PlaceholderText = "Last name";

            // lblEmail
            lblEmail.Text = "Email Address";
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 125);
            lblEmail.Size = new Size(378, 18);

            // txtEmail
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(20, 145);
            txtEmail.Size = new Size(378, 28);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.PlaceholderText = "Enter your email";

            // lblPhone
            lblPhone.Text = "Phone Number";
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhone.Location = new Point(20, 185);
            lblPhone.Size = new Size(378, 18);

            // txtPhone
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(20, 205);
            txtPhone.Size = new Size(378, 28);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.PlaceholderText = "03XXXXXXXXX";

            // lblPassword
            lblPassword.Text = "Password";
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(20, 245);
            lblPassword.Size = new Size(378, 18);

            // txtPassword
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(20, 265);
            txtPassword.Size = new Size(378, 28);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Min 6 characters";

            // lblRole
            lblRole.Text = "Register As";
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.Location = new Point(20, 305);
            lblRole.Size = new Size(378, 18);

            // cmbRole
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.Location = new Point(20, 325);
            cmbRole.Size = new Size(378, 28);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "client", "freelancer" });
            cmbRole.SelectedIndex = 0;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;

            // lblExtra  (Company Name for client / Experience for freelancer)
            lblExtra.Text = "Company Name (optional)";
            lblExtra.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblExtra.Location = new Point(20, 365);
            lblExtra.Size = new Size(378, 18);

            // txtExtra
            txtExtra.Font = new Font("Segoe UI", 10F);
            txtExtra.Location = new Point(20, 385);
            txtExtra.Size = new Size(378, 28);
            txtExtra.BorderStyle = BorderStyle.FixedSingle;
            txtExtra.PlaceholderText = "Your company name";

            // lblHourlyRate  (only visible for freelancer)
            lblHourlyRate.Text = "Hourly Rate (PKR)";
            lblHourlyRate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHourlyRate.Location = new Point(20, 425);
            lblHourlyRate.Size = new Size(378, 18);
            lblHourlyRate.Visible = false;

            // txtHourlyRate
            txtHourlyRate.Font = new Font("Segoe UI", 10F);
            txtHourlyRate.Location = new Point(20, 445);
            txtHourlyRate.Size = new Size(378, 28);
            txtHourlyRate.BorderStyle = BorderStyle.FixedSingle;
            txtHourlyRate.PlaceholderText = "e.g. 2500";
            txtHourlyRate.Visible = false;

            // lblError
            lblError.Text = "";
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(20, 483);
            lblError.Size = new Size(378, 18);
            lblError.TextAlign = ContentAlignment.MiddleCenter;

            // btnRegister
            btnRegister.Text = "Create Account";
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.BackColor = Color.FromArgb(37, 99, 235);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Location = new Point(20, 508);
            btnRegister.Size = new Size(378, 40);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Click += btnRegister_Click;

            // btnBack
            btnBack.Text = "← Back to Login";
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.ForeColor = Color.FromArgb(37, 99, 235);
            btnBack.BackColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Location = new Point(130, 552);
            btnBack.Size = new Size(160, 24);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += btnBack_Click;

            // RegisterForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 255);
            ClientSize = new Size(542, 640);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "FreelancePlatform - Register";
            Controls.Add(panelMain);

            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblTitle;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblExtra;
        private TextBox txtExtra;
        private Label lblHourlyRate;
        private TextBox txtHourlyRate;
        private Label lblError;
        private Button btnRegister;
        private Button btnBack;
    }
}