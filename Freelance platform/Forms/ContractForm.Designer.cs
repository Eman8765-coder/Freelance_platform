// ============================================================
// ContractForm.Designer.cs
// ============================================================
using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class ContractForm
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
            dgvContracts = new DataGridView();
            panelDetail = new Panel();
            lblDetail = new Label();
            lblContractInfo = new Label();
            btnMarkDone = new Button();
            btnCloseDetail = new Button();

            panelTop.SuspendLayout();
            panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContracts).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(37, 99, 235);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 60;
            panelTop.Controls.Add(lblTitle);

            // lblTitle
            lblTitle.Text = "📄  Contracts";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(400, 30);

            // dgvContracts
            dgvContracts.Location = new Point(10, 75);
            dgvContracts.Size = new Size(820, 400);
            dgvContracts.AllowUserToAddRows = false;
            dgvContracts.AllowUserToDeleteRows = false;
            dgvContracts.ReadOnly = true;
            dgvContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContracts.BackgroundColor = Color.White;
            dgvContracts.BorderStyle = BorderStyle.None;
            dgvContracts.RowHeadersVisible = false;
            dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContracts.Font = new Font("Segoe UI", 9F);
            dgvContracts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 255);
            dgvContracts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvContracts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(37, 99, 235);
            dgvContracts.EnableHeadersVisualStyles = false;
            dgvContracts.CellClick += dgvContracts_CellClick;

            // panelDetail
            panelDetail.BackColor = Color.White;
            panelDetail.BorderStyle = BorderStyle.FixedSingle;
            panelDetail.Location = new Point(840, 75);
            panelDetail.Size = new Size(300, 300);
            panelDetail.Visible = false;
            panelDetail.Controls.AddRange(new Control[] {
                lblDetail, lblContractInfo, btnMarkDone, btnCloseDetail
            });

            // lblDetail
            lblDetail.Text = "Contract Details";
            lblDetail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetail.ForeColor = Color.FromArgb(37, 99, 235);
            lblDetail.Location = new Point(15, 15);
            lblDetail.Size = new Size(270, 28);

            // lblContractInfo
            lblContractInfo.Text = "";
            lblContractInfo.Font = new Font("Segoe UI", 9F);
            lblContractInfo.ForeColor = Color.FromArgb(55, 65, 81);
            lblContractInfo.Location = new Point(15, 55);
            lblContractInfo.Size = new Size(270, 160);

            // btnMarkDone
            btnMarkDone.Text = "✓ Mark as Completed";
            btnMarkDone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMarkDone.BackColor = Color.FromArgb(22, 163, 74);
            btnMarkDone.ForeColor = Color.White;
            btnMarkDone.FlatStyle = FlatStyle.Flat;
            btnMarkDone.FlatAppearance.BorderSize = 0;
            btnMarkDone.Location = new Point(15, 225);
            btnMarkDone.Size = new Size(180, 36);
            btnMarkDone.Cursor = Cursors.Hand;
            btnMarkDone.Click += btnMarkDone_Click;

            // btnCloseDetail
            btnCloseDetail.Text = "Close";
            btnCloseDetail.Font = new Font("Segoe UI", 10F);
            btnCloseDetail.BackColor = Color.FromArgb(229, 231, 235);
            btnCloseDetail.ForeColor = Color.FromArgb(55, 65, 81);
            btnCloseDetail.FlatStyle = FlatStyle.Flat;
            btnCloseDetail.FlatAppearance.BorderSize = 0;
            btnCloseDetail.Location = new Point(205, 225);
            btnCloseDetail.Size = new Size(75, 36);
            btnCloseDetail.Cursor = Cursors.Hand;
            btnCloseDetail.Click += btnCloseDetail_Click;

            // ContractForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 255);
            ClientSize = new Size(1160, 560);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contracts";
            Controls.AddRange(new Control[] { panelTop, dgvContracts, panelDetail });

            panelTop.ResumeLayout(false);
            panelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContracts).EndInit();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private DataGridView dgvContracts;
        private Panel panelDetail;
        private Label lblDetail;
        private Label lblContractInfo;
        private Button btnMarkDone;
        private Button btnCloseDetail;
    }
}