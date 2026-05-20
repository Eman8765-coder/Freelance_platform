using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Freelance_Platform.Database;
using Freelance_Platform.Models;

namespace Freelance_Platform.Forms
{
    public partial class PaymentForm : Form
    {
        private readonly PaymentRepository _paymentRepo = new PaymentRepository();
        private readonly ContractRepository _contractRepo = new ContractRepository();
        private List<Contract> _contracts = new List<Contract>();

        public PaymentForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Only clients can make payments
            btnAddPayment.Visible = Freelance_Platform.Session.IsClient;

            SetupGrid();
            LoadPayments();
        }

        private void SetupGrid()
        {
            dgvPayments.Rows.Clear();
            dgvPayments.Columns.Clear();
            dgvPayments.AutoGenerateColumns = false;

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "payment_id",
                HeaderText = "ID",
                Visible = false
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "project",
                HeaderText = "Project",
                FillWeight = 35
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "amount",
                HeaderText = "Amount",
                FillWeight = 20
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "method",
                HeaderText = "Method",
                FillWeight = 20
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "date",
                HeaderText = "Date",
                FillWeight = 25
            });

            // Extra column for freelancer — shows who paid
            if (Freelance_Platform.Session.IsFreelancer)
            {
                dgvPayments.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "total",
                    HeaderText = "Total Earned",
                    FillWeight = 20
                });
            }

            dgvPayments.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPayments()
        {
            dgvPayments.Rows.Clear();

            try
            {
                if (Freelance_Platform.Session.IsClient)
                {
                    // Client sees payments they made
                    var payments = _paymentRepo.GetPaymentsByClient(
                        Freelance_Platform.Session.ClientId);

                    if (payments.Count == 0)
                    {
                        dgvPayments.Rows.Add(0, "No payments found.", "", "", "");
                        return;
                    }

                    double total = 0;
                    foreach (var p in payments)
                    {
                        total += p.Amount;
                        dgvPayments.Rows.Add(
                            p.PaymentId,
                            p.ProjectTitle,
                            $"PKR {p.Amount:N0}",
                            p.PaymentMethod,
                            p.PaymentDate);
                    }

                    // Show total at bottom
                    dgvPayments.Rows.Add(0, "TOTAL PAID", $"PKR {total:N0}", "", "");
                }
                else
                {
                    // Freelancer sees payments they received
                    var payments = _paymentRepo.GetPaymentsByFreelancer(
                        Freelance_Platform.Session.FreelancerId);

                    if (payments.Count == 0)
                    {
                        dgvPayments.Rows.Add(0, "No earnings found yet.", "", "", "", "");
                        return;
                    }

                    double total = _paymentRepo.GetTotalEarnings(
                        Freelance_Platform.Session.FreelancerId);

                    foreach (var p in payments)
                    {
                        dgvPayments.Rows.Add(
                            p.PaymentId,
                            p.ProjectTitle,
                            $"PKR {p.Amount:N0}",
                            p.PaymentMethod,
                            p.PaymentDate,
                            "");
                    }

                    // Show total earnings at bottom
                    dgvPayments.Rows.Add(
                        0, "TOTAL EARNINGS",
                        $"PKR {total:N0}", "", "",
                        $"PKR {total:N0}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            _contracts = _contractRepo.GetContractsByClient(
                Freelance_Platform.Session.ClientId);

            cmbContract.Items.Clear();
            foreach (var c in _contracts)
                cmbContract.Items.Add($"{c.ProjectTitle} ({c.Status})");

            if (_contracts.Count == 0)
            {
                MessageBox.Show(
                    "No contracts found. Please accept a bid first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cmbContract.SelectedIndex = 0;
            txtAmount.Clear();
            panelForm.Visible = true;
            this.Width = 1160;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbContract.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid amount.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var payment = new Payment
            {
                ContractId = _contracts[cmbContract.SelectedIndex].ContractId,
                Amount = amount,
                PaymentMethod = cmbMethod.SelectedItem?.ToString() ?? "Cash"
            };

            bool success = _paymentRepo.AddPayment(payment);
            if (success)
            {
                MessageBox.Show("Payment recorded successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelForm.Visible = false;
                this.Width = 860;
                LoadPayments();
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelForm.Visible = false;
            this.Width = 860;
        }
    }
}