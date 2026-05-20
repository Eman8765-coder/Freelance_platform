using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class BidForm
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
            panelTop = new Panel();
            lblTitle = new Label();
            dgvBids = new DataGridView();
            panelForm = new Panel();
            lblFormTitle = new Label();
            lblProject = new Label();
            cmbProject = new ComboBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            lblProposal = new Label();
            txtProposal = new TextBox();
            btnSubmitBid = new Button();
            btnCancelBid = new Button();
            btnAcceptBid = new Button();
            btnOpenBidForm = new Button();

            panelTop.SuspendLayout();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBids).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(37, 99, 235);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;
            panelTop.Controls.AddRange(new Control[] { lblTitle, btnOpenBidForm });

            // lblTitle
            lblTitle.Text = "💰  Bids";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(300, 30);

            // btnOpenBidForm
            btnOpenBidForm.Text = "+ Submit Bid";
            btnOpenBidForm.Font = new Font("Segoe UI", 10F);
            btnOpenBidForm.BackColor = Color.White;
            btnOpenBidForm.ForeColor = Color.FromArgb(37, 99, 235);
            btnOpenBidForm.FlatStyle = FlatStyle.Flat;
            btnOpenBidForm.FlatAppearance.BorderSize = 0;
            btnOpenBidForm.Location = new Point(680, 15);
            btnOpenBidForm.Size = new Size(130, 32);
            btnOpenBidForm.Cursor = Cursors.Hand;
            btnOpenBidForm.Visible = false;
            btnOpenBidForm.Click += btnOpenBidForm_Click;

            // dgvBids
            dgvBids.Location = new Point(10, 75);
            dgvBids.Size = new Size(820, 400);
            dgvBids.AllowUserToAddRows = false;
            dgvBids.AllowUserToDeleteRows = false;
            dgvBids.ReadOnly = true;
            dgvBids.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBids.BackgroundColor = Color.White;
            dgvBids.BorderStyle = BorderStyle.None;
            dgvBids.RowHeadersVisible = false;
            dgvBids.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBids.Font = new Font("Segoe UI", 9F);
            dgvBids.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 255);
            dgvBids.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvBids.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            dgvBids.EnableHeadersVisualStyles = false;
            dgvBids.CellClick += dgvBids_CellClick;

            // panelForm
            panelForm.BackColor = Color.White;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Location = new Point(840, 75);
            panelForm.Size = new Size(330, 400);
            panelForm.Visible = false;
            panelForm.Controls.AddRange(new Control[] {
                lblFormTitle,
                lblProject,  cmbProject,
                lblAmount,   txtAmount,
                lblProposal, txtProposal,
                btnSubmitBid, btnCancelBid, btnAcceptBid
            });

            // lblFormTitle
            lblFormTitle.Text = "Submit a Bid";
            lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblFormTitle.Location = new Point(15, 15);
            lblFormTitle.Size = new Size(300, 28);

            // lblProject
            lblProject.Text = "Select Project";
            lblProject.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProject.Location = new Point(15, 55);
            lblProject.Size = new Size(300, 18);

            // cmbProject
            cmbProject.Font = new Font("Segoe UI", 10F);
            cmbProject.Location = new Point(15, 75);
            cmbProject.Size = new Size(300, 28);
            cmbProject.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblAmount
            lblAmount.Text = "Your Bid Amount (PKR)";
            lblAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAmount.Location = new Point(15, 115);
            lblAmount.Size = new Size(300, 18);

            // txtAmount
            txtAmount.Font = new Font("Segoe UI", 10F);
            txtAmount.Location = new Point(15, 135);
            txtAmount.Size = new Size(300, 28);
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.PlaceholderText = "e.g. 25000";

            // lblProposal
            lblProposal.Text = "Your Proposal";
            lblProposal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProposal.Location = new Point(15, 175);
            lblProposal.Size = new Size(300, 18);

            // txtProposal
            txtProposal.Font = new Font("Segoe UI", 10F);
            txtProposal.Location = new Point(15, 195);
            txtProposal.Size = new Size(300, 100);
            txtProposal.BorderStyle = BorderStyle.FixedSingle;
            txtProposal.Multiline = true;
            txtProposal.ScrollBars = ScrollBars.Vertical;

            // btnSubmitBid
            btnSubmitBid.Text = "Submit Bid";
            btnSubmitBid.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmitBid.BackColor = Color.FromArgb(37, 99, 235);
            btnSubmitBid.ForeColor = Color.White;
            btnSubmitBid.FlatStyle = FlatStyle.Flat;
            btnSubmitBid.FlatAppearance.BorderSize = 0;
            btnSubmitBid.Location = new Point(15, 315);
            btnSubmitBid.Size = new Size(140, 36);
            btnSubmitBid.Cursor = Cursors.Hand;
            btnSubmitBid.Click += btnSubmitBid_Click;

            // btnCancelBid
            btnCancelBid.Text = "Cancel";
            btnCancelBid.Font = new Font("Segoe UI", 10F);
            btnCancelBid.BackColor = Color.FromArgb(229, 231, 235);
            btnCancelBid.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancelBid.FlatStyle = FlatStyle.Flat;
            btnCancelBid.FlatAppearance.BorderSize = 0;
            btnCancelBid.Location = new Point(165, 315);
            btnCancelBid.Size = new Size(80, 36);
            btnCancelBid.Cursor = Cursors.Hand;
            btnCancelBid.Click += btnCancelBid_Click;

            // btnAcceptBid (only for clients)
            btnAcceptBid.Text = "✓ Accept Bid";
            btnAcceptBid.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAcceptBid.BackColor = Color.FromArgb(22, 163, 74);
            btnAcceptBid.ForeColor = Color.White;
            btnAcceptBid.FlatStyle = FlatStyle.Flat;
            btnAcceptBid.FlatAppearance.BorderSize = 0;
            btnAcceptBid.Location = new Point(15, 315);
            btnAcceptBid.Size = new Size(140, 36);
            btnAcceptBid.Cursor = Cursors.Hand;
            btnAcceptBid.Visible = false;
            btnAcceptBid.Click += btnAcceptBid_Click;

            // BidForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 255);
            ClientSize = new Size(1200, 550);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bids";
            Controls.AddRange(new Control[] { panelTop, dgvBids, panelForm });

            panelTop.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBids).EndInit();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Button btnOpenBidForm;
        private DataGridView dgvBids;
        private Panel panelForm;
        private Label lblFormTitle;
        private Label lblProject;
        private ComboBox cmbProject;
        private Label lblAmount;
        private TextBox txtAmount;
        private Label lblProposal;
        private TextBox txtProposal;
        private Button btnSubmitBid;
        private Button btnCancelBid;
        private Button btnAcceptBid;
    }
}