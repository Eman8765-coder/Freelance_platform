// ============================================================
// ReviewForm.Designer.cs
// ============================================================
using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class ReviewForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            btnAddReview = new Button();
            dgvReviews = new DataGridView();
            panelForm = new Panel();
            lblFormTitle = new Label();
            lblContract = new Label();
            cmbContract = new ComboBox();
            lblRating = new Label();
            cmbRating = new ComboBox();
            lblFeedback = new Label();
            txtFeedback = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();

            panelTop.SuspendLayout();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(37, 99, 235);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;
            panelTop.Controls.AddRange(new Control[] { lblTitle, btnAddReview });

            lblTitle.Text = "⭐  Reviews";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(300, 30);

            btnAddReview.Text = "+ Give Review";
            btnAddReview.Font = new Font("Segoe UI", 10F);
            btnAddReview.BackColor = Color.White;
            btnAddReview.ForeColor = Color.FromArgb(37, 99, 235);
            btnAddReview.FlatStyle = FlatStyle.Flat;
            btnAddReview.FlatAppearance.BorderSize = 0;
            btnAddReview.Location = new Point(680, 15);
            btnAddReview.Size = new Size(130, 32);
            btnAddReview.Cursor = Cursors.Hand;
            btnAddReview.Visible = false;
            btnAddReview.Click += btnAddReview_Click;

            // dgvReviews
            dgvReviews.Location = new Point(10, 75);
            dgvReviews.Size = new Size(820, 380);
            dgvReviews.AllowUserToAddRows = false;
            dgvReviews.AllowUserToDeleteRows = false;
            dgvReviews.ReadOnly = true;
            dgvReviews.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReviews.BackgroundColor = Color.White;
            dgvReviews.BorderStyle = BorderStyle.None;
            dgvReviews.RowHeadersVisible = false;
            dgvReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReviews.Font = new Font("Segoe UI", 9F);
            dgvReviews.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 255);
            dgvReviews.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvReviews.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            dgvReviews.EnableHeadersVisualStyles = false;

            // panelForm
            panelForm.BackColor = Color.White;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Location = new Point(840, 75);
            panelForm.Size = new Size(300, 360);
            panelForm.Visible = false;
            panelForm.Controls.AddRange(new Control[] {
                lblFormTitle, lblContract, cmbContract,
                lblRating, cmbRating, lblFeedback, txtFeedback,
                btnSave, btnCancel
            });

            lblFormTitle.Text = "Write a Review";
            lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblFormTitle.Location = new Point(15, 15);
            lblFormTitle.Size = new Size(270, 28);

            lblContract.Text = "Select Contract";
            lblContract.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContract.Location = new Point(15, 55);
            lblContract.Size = new Size(270, 18);

            cmbContract.Font = new Font("Segoe UI", 10F);
            cmbContract.Location = new Point(15, 75);
            cmbContract.Size = new Size(270, 28);
            cmbContract.DropDownStyle = ComboBoxStyle.DropDownList;

            lblRating.Text = "Rating (1-5 Stars)";
            lblRating.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRating.Location = new Point(15, 115);
            lblRating.Size = new Size(270, 18);

            cmbRating.Font = new Font("Segoe UI", 10F);
            cmbRating.Location = new Point(15, 135);
            cmbRating.Size = new Size(270, 28);
            cmbRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRating.Items.AddRange(new object[] {
                "⭐ 1 - Poor", "⭐⭐ 2 - Fair",
                "⭐⭐⭐ 3 - Good", "⭐⭐⭐⭐ 4 - Very Good",
                "⭐⭐⭐⭐⭐ 5 - Excellent"
            });
            cmbRating.SelectedIndex = 4;

            lblFeedback.Text = "Feedback";
            lblFeedback.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFeedback.Location = new Point(15, 175);
            lblFeedback.Size = new Size(270, 18);

            txtFeedback.Font = new Font("Segoe UI", 10F);
            txtFeedback.Location = new Point(15, 195);
            txtFeedback.Size = new Size(270, 90);
            txtFeedback.BorderStyle = BorderStyle.FixedSingle;
            txtFeedback.Multiline = true;
            txtFeedback.ScrollBars = ScrollBars.Vertical;

            btnSave.Text = "Submit Review";
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location = new Point(15, 305);
            btnSave.Size = new Size(150, 36);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.BackColor = Color.FromArgb(229, 231, 235);
            btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Location = new Point(175, 305);
            btnCancel.Size = new Size(80, 36);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 255);
            ClientSize = new Size(1160, 540);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reviews";
            Controls.AddRange(new Control[] { panelTop, dgvReviews, panelForm });

            panelTop.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Button btnAddReview;
        private DataGridView dgvReviews;
        private Panel panelForm;
        private Label lblFormTitle;
        private Label lblContract;
        private ComboBox cmbContract;
        private Label lblRating;
        private ComboBox cmbRating;
        private Label lblFeedback;
        private TextBox txtFeedback;
        private Button btnSave;
        private Button btnCancel;
    }
}