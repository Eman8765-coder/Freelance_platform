// ============================================================
// PaymentForm.Designer.cs
// ============================================================
using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            btnAddPayment = new Button();
            dgvPayments = new DataGridView();
            panelForm = new Panel();
            lblFormTitle = new Label();
            lblContract = new Label();
            cmbContract = new ComboBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            lblMethod = new Label();
            cmbMethod = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(37, 99, 235);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnAddPayment);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1657, 100);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(429, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💳  Payments";
            // 
            // btnAddPayment
            // 
            btnAddPayment.BackColor = Color.White;
            btnAddPayment.Cursor = Cursors.Hand;
            btnAddPayment.FlatAppearance.BorderSize = 0;
            btnAddPayment.FlatStyle = FlatStyle.Flat;
            btnAddPayment.Font = new Font("Segoe UI", 10F);
            btnAddPayment.ForeColor = Color.FromArgb(37, 99, 235);
            btnAddPayment.Location = new Point(943, 25);
            btnAddPayment.Margin = new Padding(4, 5, 4, 5);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(214, 53);
            btnAddPayment.TabIndex = 1;
            btnAddPayment.Text = "+ Make Payment";
            btnAddPayment.UseVisualStyleBackColor = false;
            btnAddPayment.Visible = false;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 244, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPayments.ColumnHeadersHeight = 34;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.Font = new Font("Segoe UI", 9F);
            dgvPayments.Location = new Point(14, 125);
            dgvPayments.Margin = new Padding(4, 5, 4, 5);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowHeadersWidth = 62;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(1171, 633);
            dgvPayments.TabIndex = 1;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Controls.Add(lblFormTitle);
            panelForm.Controls.Add(lblContract);
            panelForm.Controls.Add(cmbContract);
            panelForm.Controls.Add(lblAmount);
            panelForm.Controls.Add(txtAmount);
            panelForm.Controls.Add(lblMethod);
            panelForm.Controls.Add(cmbMethod);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(btnCancel);
            panelForm.Location = new Point(1200, 125);
            panelForm.Margin = new Padding(4, 5, 4, 5);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(428, 532);
            panelForm.TabIndex = 2;
            panelForm.Visible = false;
            // 
            // lblFormTitle
            // 
            lblFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblFormTitle.Location = new Point(21, 25);
            lblFormTitle.Margin = new Padding(4, 0, 4, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(386, 47);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Make a Payment";
            // 
            // lblContract
            // 
            lblContract.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContract.Location = new Point(21, 92);
            lblContract.Margin = new Padding(4, 0, 4, 0);
            lblContract.Name = "lblContract";
            lblContract.Size = new Size(386, 30);
            lblContract.TabIndex = 1;
            lblContract.Text = "Select Contract";
            // 
            // cmbContract
            // 
            cmbContract.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContract.Font = new Font("Segoe UI", 10F);
            cmbContract.Location = new Point(21, 125);
            cmbContract.Margin = new Padding(4, 5, 4, 5);
            cmbContract.Name = "cmbContract";
            cmbContract.Size = new Size(384, 36);
            cmbContract.TabIndex = 2;
            // 
            // lblAmount
            // 
            lblAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAmount.Location = new Point(21, 192);
            lblAmount.Margin = new Padding(4, 0, 4, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(386, 30);
            lblAmount.TabIndex = 3;
            lblAmount.Text = "Amount (PKR)";
            // 
            // txtAmount
            // 
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.Font = new Font("Segoe UI", 10F);
            txtAmount.Location = new Point(21, 225);
            txtAmount.Margin = new Padding(4, 5, 4, 5);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "e.g. 25000";
            txtAmount.Size = new Size(385, 34);
            txtAmount.TabIndex = 4;
            // 
            // lblMethod
            // 
            lblMethod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMethod.Location = new Point(21, 292);
            lblMethod.Margin = new Padding(4, 0, 4, 0);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(386, 30);
            lblMethod.TabIndex = 5;
            lblMethod.Text = "Payment Method";
            // 
            // cmbMethod
            // 
            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.Font = new Font("Segoe UI", 10F);
            cmbMethod.Items.AddRange(new object[] { "JazzCash", "EasyPaisa", "Bank Transfer", "Cash" });
            cmbMethod.Location = new Point(21, 325);
            cmbMethod.Margin = new Padding(4, 5, 4, 5);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(384, 36);
            cmbMethod.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(21, 425);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(214, 60);
            btnSave.TabIndex = 7;
            btnSave.Text = "Make Payment";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(229, 231, 235);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancel.Location = new Point(250, 425);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 60);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 255);
            ClientSize = new Size(1657, 900);
            Controls.Add(panelTop);
            Controls.Add(dgvPayments);
            Controls.Add(panelForm);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payments";
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Button btnAddPayment;
        private DataGridView dgvPayments;
        private Panel panelForm;
        private Label lblFormTitle;
        private Label lblContract;
        private ComboBox cmbContract;
        private Label lblAmount;
        private TextBox txtAmount;
        private Label lblMethod;
        private ComboBox cmbMethod;
        private Button btnSave;
        private Button btnCancel;
    }
}