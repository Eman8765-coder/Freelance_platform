using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Freelance_Platform.Database;
using Freelance_Platform.Models;

namespace Freelance_Platform.Forms
{
    public partial class ReviewForm : Form
    {
        private readonly ReviewRepository _reviewRepo = new ReviewRepository();
        private readonly ContractRepository _contractRepo = new ContractRepository();
        private List<Contract> _contracts = new List<Contract>();

        public ReviewForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Only clients give reviews
            btnAddReview.Visible = Freelance_Platform.Session.IsClient;
            LoadReviews();
        }

        private void LoadReviews()
        {
            dgvReviews.Rows.Clear();
            dgvReviews.Columns.Clear();
            dgvReviews.Columns.Add("review_id", "ID");
            dgvReviews.Columns.Add("project", "Project");
            dgvReviews.Columns.Add("freelancer", "Freelancer");
            dgvReviews.Columns.Add("rating", "Rating");
            dgvReviews.Columns.Add("feedback", "Feedback");
            dgvReviews.Columns.Add("date", "Date");
            dgvReviews.Columns["review_id"].Visible = false;

            if (Freelance_Platform.Session.IsFreelancer)
            {
                var reviews = _reviewRepo.GetReviewsByFreelancer(
                    Freelance_Platform.Session.FreelancerId);
                foreach (var r in reviews)
                    dgvReviews.Rows.Add(
                        r.ReviewId, r.ProjectTitle, r.FreelancerName,
                        new string('⭐', r.Rating), r.Feedback, r.ReviewDate);
            }
            else
            {
                // Client sees reviews they gave — load via contracts
                var contracts = _contractRepo.GetContractsByClient(
                    Freelance_Platform.Session.ClientId);
                foreach (var c in contracts)
                {
                    var reviews = _reviewRepo.GetReviewsByContract(c.ContractId);
                    foreach (var r in reviews)
                        dgvReviews.Rows.Add(
                            r.ReviewId, r.ProjectTitle, r.FreelancerName,
                            new string('⭐', r.Rating), r.Feedback, r.ReviewDate);
                }
            }
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {
            _contracts = _contractRepo.GetContractsByClient(
                Freelance_Platform.Session.ClientId);

            cmbContract.Items.Clear();
            foreach (var c in _contracts)
                cmbContract.Items.Add($"{c.ProjectTitle} - {c.FreelancerName}");

            if (_contracts.Count == 0)
            {
                MessageBox.Show("No contracts found to review.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cmbContract.SelectedIndex = 0;
            txtFeedback.Clear();
            cmbRating.SelectedIndex = 4;
            panelForm.Visible = true;
            this.Width = 1160;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbContract.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtFeedback.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var review = new Review
            {
                ContractId = _contracts[cmbContract.SelectedIndex].ContractId,
                Rating = cmbRating.SelectedIndex + 1,  // 1 to 5
                Feedback = txtFeedback.Text.Trim()
            };

            bool success = _reviewRepo.AddReview(review);
            if (success)
            {
                MessageBox.Show("Review submitted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelForm.Visible = false;
                this.Width = 860;
                LoadReviews();
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelForm.Visible = false;
            this.Width = 860;
        }
    }
}