using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Freelance_Platform.Database;
using Freelance_Platform.Models;

namespace Freelance_Platform.Forms
{
    public partial class BidForm : Form
    {
        private readonly BidRepository _bidRepo = new BidRepository();
        private readonly ProjectRepository _projectRepo = new ProjectRepository();
        private readonly ContractRepository _contractRepo = new ContractRepository();

        private List<Project> _openProjects = new List<Project>();
        private int _selectedBidId = 0;
        private int _selectedFreelancerId = 0;
        private int _selectedProjectId = 0;

        public BidForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Freelance_Platform.Session.IsFreelancer)
            {
                btnOpenBidForm.Visible = true;
                LoadFreelancerBids();
            }
            else
            {
                btnOpenBidForm.Visible = false;
                LoadClientBids();
            }
        }

        // Load all bids submitted by this freelancer
        private void LoadFreelancerBids()
        {
            SetupBidGrid();
            var bids = _bidRepo.GetBidsByFreelancer(Freelance_Platform.Session.FreelancerId);
            foreach (var b in bids)
                dgvBids.Rows.Add(b.BidId, b.ProjectTitle, $"PKR {b.BidAmount:N0}", b.Proposal, b.BidDate);
        }

        // Load all bids on client's projects
        private void LoadClientBids()
        {
            SetupBidGrid();
            var projects = _projectRepo.GetProjectsByClient(Freelance_Platform.Session.ClientId);
            foreach (var proj in projects)
            {
                var bids = _bidRepo.GetBidsByProject(proj.ProjectId);
                foreach (var b in bids)
                    dgvBids.Rows.Add(b.BidId, b.ProjectTitle, $"PKR {b.BidAmount:N0}", b.FreelancerName, b.BidDate);
            }
        }

        private void SetupBidGrid()
        {
            dgvBids.Rows.Clear();
            dgvBids.Columns.Clear();
            dgvBids.Columns.Add("bid_id", "ID");
            dgvBids.Columns.Add("project", "Project");
            dgvBids.Columns.Add("amount", "Bid Amount");

            if (Freelance_Platform.Session.IsClient)
                dgvBids.Columns.Add("freelancer", "Freelancer");
            else
                dgvBids.Columns.Add("proposal", "Proposal");

            dgvBids.Columns.Add("date", "Date");
            dgvBids.Columns["bid_id"].Visible = false;
        }

        // Freelancer clicks + Submit Bid
        private void btnOpenBidForm_Click(object sender, EventArgs e)
        {
            // Load open projects into dropdown
            _openProjects = _projectRepo.GetOpenProjects();
            cmbProject.Items.Clear();
            foreach (var p in _openProjects)
                cmbProject.Items.Add(p.Title);

            if (cmbProject.Items.Count == 0)
            {
                MessageBox.Show("No open projects available to bid on.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cmbProject.SelectedIndex = 0;
            lblFormTitle.Text = "Submit a Bid";
            btnSubmitBid.Visible = true;
            btnAcceptBid.Visible = false;
            txtAmount.Clear();
            txtProposal.Clear();
            panelForm.Visible = true;
            this.Width = 1200;
        }

        // Client clicks on a bid row to accept it
        private void dgvBids_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!Freelance_Platform.Session.IsClient) return;

            _selectedBidId = Convert.ToInt32(dgvBids.Rows[e.RowIndex].Cells["bid_id"].Value);

            // Find the bid details
            var projects = _projectRepo.GetProjectsByClient(Freelance_Platform.Session.ClientId);
            foreach (var proj in projects)
            {
                var bids = _bidRepo.GetBidsByProject(proj.ProjectId);
                foreach (var b in bids)
                {
                    if (b.BidId == _selectedBidId)
                    {
                        _selectedFreelancerId = b.FreelancerId;
                        _selectedProjectId = b.ProjectId;

                        lblFormTitle.Text = $"Bid by {b.FreelancerName}";
                        cmbProject.Items.Clear();
                        cmbProject.Items.Add(b.ProjectTitle);
                        cmbProject.SelectedIndex = 0;
                        txtAmount.Text = b.BidAmount.ToString();
                        txtProposal.Text = b.Proposal;
                        btnSubmitBid.Visible = false;
                        btnAcceptBid.Visible = true;
                        panelForm.Visible = true;
                        this.Width = 1200;
                        return;
                    }
                }
            }
        }

        private void btnSubmitBid_Click(object sender, EventArgs e)
        {
            if (cmbProject.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtAmount.Text) ||
                string.IsNullOrWhiteSpace(txtProposal.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtAmount.Text, out double amount))
            {
                MessageBox.Show("Please enter a valid bid amount.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bid = new Bid
            {
                ProjectId = _openProjects[cmbProject.SelectedIndex].ProjectId,
                FreelancerId = Freelance_Platform.Session.FreelancerId,
                BidAmount = amount,
                Proposal = txtProposal.Text.Trim()
            };

            bool success = _bidRepo.AddBid(bid);
            if (success)
            {
                MessageBox.Show("Bid submitted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelForm.Visible = false;
                this.Width = 860;
                LoadFreelancerBids();
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Client accepts a bid — creates a contract automatically
        private void btnAcceptBid_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Accept this bid and create a contract?",
                "Accept Bid", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var contract = new Contract
            {
                ProjectId = _selectedProjectId,
                FreelancerId = _selectedFreelancerId,
                StartDate = DateTime.Today.ToString("yyyy-MM-dd"),
                EndDate = DateTime.Today.AddMonths(1).ToString("yyyy-MM-dd"),
                Status = "active"
            };

            bool success = _contractRepo.AddContract(contract);
            if (success)
            {
                MessageBox.Show(
                    "Bid accepted! Contract created successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelForm.Visible = false;
                this.Width = 860;
                LoadClientBids();
            }
        }

        private void btnCancelBid_Click(object sender, EventArgs e)
        {
            panelForm.Visible = false;
            this.Width = 860;
        }
    }
}