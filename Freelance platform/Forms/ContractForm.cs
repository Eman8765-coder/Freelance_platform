using System;
using System.Windows.Forms;
using Freelance_Platform.Database;

namespace Freelance_Platform.Forms
{
    public partial class ContractForm : Form
    {
        private readonly ContractRepository _contractRepo = new ContractRepository();
        private int _selectedContractId = 0;

        public ContractForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadContracts();
        }

        private void LoadContracts()
        {
            dgvContracts.Rows.Clear();
            dgvContracts.Columns.Clear();
            dgvContracts.Columns.Add("contract_id", "ID");
            dgvContracts.Columns.Add("project", "Project");
            dgvContracts.Columns.Add("freelancer", "Freelancer");
            dgvContracts.Columns.Add("start_date", "Start Date");
            dgvContracts.Columns.Add("end_date", "End Date");
            dgvContracts.Columns.Add("status", "Status");
            dgvContracts.Columns["contract_id"].Visible = false;

            var contracts = Freelance_Platform.Session.IsClient
                ? _contractRepo.GetContractsByClient(Freelance_Platform.Session.ClientId)
                : _contractRepo.GetContractsByFreelancer(Freelance_Platform.Session.FreelancerId);

            foreach (var c in contracts)
                dgvContracts.Rows.Add(
                    c.ContractId, c.ProjectTitle, c.FreelancerName,
                    c.StartDate, c.EndDate, c.Status.ToUpper());
        }

        private void dgvContracts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _selectedContractId = Convert.ToInt32(
                dgvContracts.Rows[e.RowIndex].Cells["contract_id"].Value);

            string project = dgvContracts.Rows[e.RowIndex].Cells["project"].Value?.ToString() ?? "";
            string freelancer = dgvContracts.Rows[e.RowIndex].Cells["freelancer"].Value?.ToString() ?? "";
            string start = dgvContracts.Rows[e.RowIndex].Cells["start_date"].Value?.ToString() ?? "";
            string end = dgvContracts.Rows[e.RowIndex].Cells["end_date"].Value?.ToString() ?? "";
            string status = dgvContracts.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "";

            lblContractInfo.Text =
                $"Project:     {project}\r\n\r\n" +
                $"Freelancer: {freelancer}\r\n\r\n" +
                $"Start Date: {start}\r\n\r\n" +
                $"End Date:   {end}\r\n\r\n" +
                $"Status:     {status}";

            // Only client can mark as completed
            btnMarkDone.Visible = Freelance_Platform.Session.IsClient && status != "COMPLETED";

            panelDetail.Visible = true;
            this.Width = 1160;
        }

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Mark this contract as completed?",
                "Complete Contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = _contractRepo.UpdateStatus(_selectedContractId, "completed");
                if (success)
                {
                    MessageBox.Show("Contract marked as completed!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelDetail.Visible = false;
                    LoadContracts();
                }
            }
        }

        private void btnCloseDetail_Click(object sender, EventArgs e)
        {
            panelDetail.Visible = false;
        }
    }
}