using System;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var user = Freelance_Platform.Session.CurrentUser;
            if (user == null) { this.Close(); return; }

            lblWelcome.Text = $"Welcome, {user.FirstName}!";
            lblRole.Text = $"[ {user.Role.ToUpper()} ]";

            if (user.Role == "client")
            {
                btnProjects.Text = "📋  My Projects";
                btnBids.Text = "💰  View Bids";
                btnContracts.Text = "📄  Contracts";
                btnPayments.Text = "💳  Payments";
                btnReviews.Text = "⭐  Give Review";
            }
            else
            {
                btnProjects.Text = "📋  Browse Projects";
                btnBids.Text = "💰  My Bids";
                btnContracts.Text = "📄  My Contracts";
                btnPayments.Text = "💳  My Earnings";
                btnReviews.Text = "⭐  My Reviews";
            }

            lblStats.Text =
                $"Hello {user.FullName}, you are logged in as {user.Role}.\r\n\r\n" +
                "Use the menu on the left to navigate.\r\n\r\n" +
                "• Projects   — Post or browse available projects\r\n" +
                "• Bids       — Submit or review bids on projects\r\n" +
                "• Contracts  — View active and completed contracts\r\n" +
                "• Payments   — Track payments made or received\r\n" +
                "• Reviews    — Submit or view reviews";
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ProjectForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Projects: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBids_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new BidForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Bids: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ContractForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Contracts: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new PaymentForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Payments: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ReviewForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Reviews: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Freelance_Platform.Session.Clear();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void lblStats_Click(object sender, EventArgs e)
        {

        }
    }
}
    
