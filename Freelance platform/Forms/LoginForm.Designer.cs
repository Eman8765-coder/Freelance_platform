using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Freelance_Platform.Forms
{
    partial class LoginForm
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
            lblSubtitle = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblError = new Label();
            btnLogin = new Button();
            lblRegisterText = new Label();
            btnRegister = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblSubtitle);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(lblError);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(lblRegisterText);
            panelMain.Controls.Add(btnRegister);
            panelMain.Location = new Point(129, 117);
            panelMain.Margin = new Padding(4, 5, 4, 5);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(542, 715);
            panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblTitle.Location = new Point(29, 47);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(483, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "FreelancePlatform";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(29, 123);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(483, 43);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sign in to your account";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(43, 203);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(454, 33);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email Address";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new Point(43, 242);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Enter your email";
            txtEmail.Size = new Size(453, 34);
            txtEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(43, 320);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(454, 33);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new Point(43, 358);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(453, 34);
            txtPassword.TabIndex = 5;
            // 
            // lblError
            // 
            lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(43, 430);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(454, 33);
            lblError.TabIndex = 6;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(43, 480);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(454, 70);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblRegisterText
            // 
            lblRegisterText.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblRegisterText.ForeColor = Color.Gray;
            lblRegisterText.Location = new Point(79, 583);
            lblRegisterText.Margin = new Padding(4, 0, 4, 0);
            lblRegisterText.Name = "lblRegisterText";
            lblRegisterText.Size = new Size(229, 37);
            lblRegisterText.TabIndex = 8;
            lblRegisterText.Text = "Don't have an account?";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.White;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Underline);
            btnRegister.ForeColor = Color.FromArgb(37, 99, 235);
            btnRegister.Location = new Point(304, 578);
            btnRegister.Margin = new Padding(4, 5, 4, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(157, 43);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register here";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 255);
            ClientSize = new Size(800, 950);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FreelancePlatform - Login";
            Load += LoginForm_Load_1;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelMain;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblError;
        private Label lblRegisterText;
        private Button btnRegister;
    }
}