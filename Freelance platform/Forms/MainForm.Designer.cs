using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class MainForm
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
            panelSidebar = new Panel();
            lblAppName = new Label();
            lblWelcome = new Label();
            lblRole = new Label();
            btnProjects = new Button();
            btnBids = new Button();
            btnContracts = new Button();
            btnPayments = new Button();
            btnReviews = new Button();
            btnLogout = new Button();
            panelContent = new Panel();
            lblContentTitle = new Label();
            lblStats = new Label();

            panelSidebar.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();

            // ── panelSidebar ────────────────────────────────────
            panelSidebar.BackColor = Color.FromArgb(37, 99, 235);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Width = 210;
            panelSidebar.Controls.AddRange(new Control[] {
                lblAppName, lblWelcome, lblRole,
                btnProjects, btnBids, btnContracts,
                btnPayments, btnReviews, btnLogout
            });

            // lblAppName
            lblAppName.Text = "FreelancePlatform";
            lblAppName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(5, 20);
            lblAppName.Size = new Size(200, 30);
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;

            // lblWelcome
            lblWelcome.Text = "Welcome!";
            lblWelcome.Font = new Font("Segoe UI", 9F);
            lblWelcome.ForeColor = Color.FromArgb(200, 220, 255);
            lblWelcome.Location = new Point(5, 55);
            lblWelcome.Size = new Size(200, 20);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            // lblRole
            lblRole.Text = "";
            lblRole.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(147, 197, 253);
            lblRole.Location = new Point(5, 75);
            lblRole.Size = new Size(200, 18);
            lblRole.TextAlign = ContentAlignment.MiddleCenter;

            // ── Sidebar Buttons ─────────────────────────────────
            int bX = 5, bW = 200, bH = 44, startY = 110, gap = 50;

            btnProjects.Text = "📋  Projects";
            btnProjects.Font = new Font("Segoe UI", 10F);
            btnProjects.ForeColor = Color.White;
            btnProjects.BackColor = Color.FromArgb(37, 99, 235);
            btnProjects.FlatStyle = FlatStyle.Flat;
            btnProjects.FlatAppearance.BorderSize = 0;
            btnProjects.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnProjects.Location = new Point(bX, startY);
            btnProjects.Size = new Size(bW, bH);
            btnProjects.TextAlign = ContentAlignment.MiddleLeft;
            btnProjects.Padding = new Padding(12, 0, 0, 0);
            btnProjects.Cursor = Cursors.Hand;
            btnProjects.Click += btnProjects_Click;

            btnBids.Text = "💰  Bids";
            btnBids.Font = new Font("Segoe UI", 10F);
            btnBids.ForeColor = Color.White;
            btnBids.BackColor = Color.FromArgb(37, 99, 235);
            btnBids.FlatStyle = FlatStyle.Flat;
            btnBids.FlatAppearance.BorderSize = 0;
            btnBids.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnBids.Location = new Point(bX, startY + gap);
            btnBids.Size = new Size(bW, bH);
            btnBids.TextAlign = ContentAlignment.MiddleLeft;
            btnBids.Padding = new Padding(12, 0, 0, 0);
            btnBids.Cursor = Cursors.Hand;
            btnBids.Click += btnBids_Click;

            btnContracts.Text = "📄  Contracts";
            btnContracts.Font = new Font("Segoe UI", 10F);
            btnContracts.ForeColor = Color.White;
            btnContracts.BackColor = Color.FromArgb(37, 99, 235);
            btnContracts.FlatStyle = FlatStyle.Flat;
            btnContracts.FlatAppearance.BorderSize = 0;
            btnContracts.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnContracts.Location = new Point(bX, startY + gap * 2);
            btnContracts.Size = new Size(bW, bH);
            btnContracts.TextAlign = ContentAlignment.MiddleLeft;
            btnContracts.Padding = new Padding(12, 0, 0, 0);
            btnContracts.Cursor = Cursors.Hand;
            btnContracts.Click += btnContracts_Click;

            btnPayments.Text = "💳  Payments";
            btnPayments.Font = new Font("Segoe UI", 10F);
            btnPayments.ForeColor = Color.White;
            btnPayments.BackColor = Color.FromArgb(37, 99, 235);
            btnPayments.FlatStyle = FlatStyle.Flat;
            btnPayments.FlatAppearance.BorderSize = 0;
            btnPayments.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnPayments.Location = new Point(bX, startY + gap * 3);
            btnPayments.Size = new Size(bW, bH);
            btnPayments.TextAlign = ContentAlignment.MiddleLeft;
            btnPayments.Padding = new Padding(12, 0, 0, 0);
            btnPayments.Cursor = Cursors.Hand;
            btnPayments.Click += btnPayments_Click;

            btnReviews.Text = "⭐  Reviews";
            btnReviews.Font = new Font("Segoe UI", 10F);
            btnReviews.ForeColor = Color.White;
            btnReviews.BackColor = Color.FromArgb(37, 99, 235);
            btnReviews.FlatStyle = FlatStyle.Flat;
            btnReviews.FlatAppearance.BorderSize = 0;
            btnReviews.FlatAppearance.MouseOverBackColor = Color.FromArgb(59, 130, 246);
            btnReviews.Location = new Point(bX, startY + gap * 4);
            btnReviews.Size = new Size(bW, bH);
            btnReviews.TextAlign = ContentAlignment.MiddleLeft;
            btnReviews.Padding = new Padding(12, 0, 0, 0);
            btnReviews.Cursor = Cursors.Hand;
            btnReviews.Click += btnReviews_Click;

            btnLogout.Text = "🚪  Logout";
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.FromArgb(254, 202, 202);
            btnLogout.BackColor = Color.FromArgb(37, 99, 235);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
            btnLogout.Location = new Point(bX, startY + gap * 6);
            btnLogout.Size = new Size(bW, bH);
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.Padding = new Padding(12, 0, 0, 0);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += btnLogout_Click;

            // ── panelContent ────────────────────────────────────
            panelContent.BackColor = Color.FromArgb(245, 247, 255);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Controls.AddRange(new Control[] {
                lblContentTitle, lblStats
            });

            lblContentTitle.Text = "Dashboard";
            lblContentTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblContentTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblContentTitle.Location = new Point(30, 30);
            lblContentTitle.Size = new Size(600, 45);

            lblStats.Text = "";
            lblStats.Font = new Font("Segoe UI", 11F);
            lblStats.ForeColor = Color.FromArgb(71, 85, 105);
            lblStats.Location = new Point(30, 90);
            lblStats.Size = new Size(700, 420);

            // ── MainForm ────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(950, 600);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 550);
            Text = "FreelancePlatform - Dashboard";

            // Important — add panelContent BEFORE panelSidebar
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);

            panelSidebar.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Control declarations
        private Panel panelSidebar;
        private Label lblAppName;
        private Label lblWelcome;
        private Label lblRole;
        private Button btnProjects;
        private Button btnBids;
        private Button btnContracts;
        private Button btnPayments;
        private Button btnReviews;
        private Button btnLogout;
        private Panel panelContent;
        private Label lblContentTitle;
        private Label lblStats;
    }
}