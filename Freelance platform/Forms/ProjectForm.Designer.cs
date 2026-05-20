using System.Drawing;
using System.Windows.Forms;

namespace Freelance_Platform.Forms
{
    partial class ProjectForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTitle = new Label();
            btnAddProject = new Button();
            dgvProjects = new DataGridView();
            panelForm = new Panel();
            lblFormTitle = new Label();
            lblPTitle = new Label();
            txtPTitle = new TextBox();
            lblDesc = new Label();
            txtDesc = new TextBox();
            lblBudget = new Label();
            txtBudget = new TextBox();
            lblDeadline = new Label();
            dtDeadline = new DateTimePicker();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnDelete = new Button();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(37, 99, 235);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnAddProject);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1714, 100);
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
            lblTitle.Text = "📋  Projects";
            // 
            // btnAddProject
            // 
            btnAddProject.BackColor = Color.White;
            btnAddProject.Cursor = Cursors.Hand;
            btnAddProject.FlatAppearance.BorderSize = 0;
            btnAddProject.FlatStyle = FlatStyle.Flat;
            btnAddProject.Font = new Font("Segoe UI", 10F);
            btnAddProject.ForeColor = Color.FromArgb(37, 99, 235);
            btnAddProject.Location = new Point(971, 25);
            btnAddProject.Margin = new Padding(4, 5, 4, 5);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(186, 53);
            btnAddProject.TabIndex = 1;
            btnAddProject.Text = "+ Add Project";
            btnAddProject.UseVisualStyleBackColor = false;
            btnAddProject.Click += btnAddProject_Click;
            // 
            // dgvProjects
            // 
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjects.BackgroundColor = Color.White;
            dgvProjects.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 244, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProjects.ColumnHeadersHeight = 34;
            dgvProjects.EnableHeadersVisualStyles = false;
            dgvProjects.Font = new Font("Segoe UI", 9F);
            dgvProjects.Location = new Point(14, 125);
            dgvProjects.Margin = new Padding(4, 5, 4, 5);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.RowHeadersVisible = false;
            dgvProjects.RowHeadersWidth = 62;
            dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjects.Size = new Size(1171, 533);
            dgvProjects.TabIndex = 1;
            dgvProjects.CellClick += dgvProjects_CellClick;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Controls.Add(lblFormTitle);
            panelForm.Controls.Add(lblPTitle);
            panelForm.Controls.Add(txtPTitle);
            panelForm.Controls.Add(lblDesc);
            panelForm.Controls.Add(txtDesc);
            panelForm.Controls.Add(lblBudget);
            panelForm.Controls.Add(txtBudget);
            panelForm.Controls.Add(lblDeadline);
            panelForm.Controls.Add(dtDeadline);
            panelForm.Controls.Add(lblStatus);
            panelForm.Controls.Add(cmbStatus);
            panelForm.Controls.Add(btnSave);
            panelForm.Controls.Add(btnCancel);
            panelForm.Controls.Add(btnDelete);
            panelForm.Location = new Point(1200, 125);
            panelForm.Margin = new Padding(4, 5, 4, 5);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(485, 832);
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
            lblFormTitle.Size = new Size(443, 47);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Add New Project";
            // 
            // lblPTitle
            // 
            lblPTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPTitle.Location = new Point(21, 92);
            lblPTitle.Margin = new Padding(4, 0, 4, 0);
            lblPTitle.Name = "lblPTitle";
            lblPTitle.Size = new Size(443, 30);
            lblPTitle.TabIndex = 1;
            lblPTitle.Text = "Project Title";
            // 
            // txtPTitle
            // 
            txtPTitle.BorderStyle = BorderStyle.FixedSingle;
            txtPTitle.Font = new Font("Segoe UI", 10F);
            txtPTitle.Location = new Point(21, 125);
            txtPTitle.Margin = new Padding(4, 5, 4, 5);
            txtPTitle.Name = "txtPTitle";
            txtPTitle.PlaceholderText = "Enter project title";
            txtPTitle.Size = new Size(442, 34);
            txtPTitle.TabIndex = 2;
            // 
            // lblDesc
            // 
            lblDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesc.Location = new Point(21, 192);
            lblDesc.Margin = new Padding(4, 0, 4, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(443, 30);
            lblDesc.TabIndex = 3;
            lblDesc.Text = "Description";
            // 
            // txtDesc
            // 
            txtDesc.BorderStyle = BorderStyle.FixedSingle;
            txtDesc.Font = new Font("Segoe UI", 10F);
            txtDesc.Location = new Point(21, 225);
            txtDesc.Margin = new Padding(4, 5, 4, 5);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(442, 115);
            txtDesc.TabIndex = 4;
            // 
            // lblBudget
            // 
            lblBudget.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBudget.Location = new Point(21, 363);
            lblBudget.Margin = new Padding(4, 0, 4, 0);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(443, 30);
            lblBudget.TabIndex = 5;
            lblBudget.Text = "Budget (PKR)";
            // 
            // txtBudget
            // 
            txtBudget.BorderStyle = BorderStyle.FixedSingle;
            txtBudget.Font = new Font("Segoe UI", 10F);
            txtBudget.Location = new Point(21, 397);
            txtBudget.Margin = new Padding(4, 5, 4, 5);
            txtBudget.Name = "txtBudget";
            txtBudget.PlaceholderText = "e.g. 50000";
            txtBudget.Size = new Size(442, 34);
            txtBudget.TabIndex = 6;
            // 
            // lblDeadline
            // 
            lblDeadline.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeadline.Location = new Point(21, 463);
            lblDeadline.Margin = new Padding(4, 0, 4, 0);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new Size(443, 30);
            lblDeadline.TabIndex = 7;
            lblDeadline.Text = "Deadline";
            // 
            // dtDeadline
            // 
            dtDeadline.Font = new Font("Segoe UI", 10F);
            dtDeadline.Format = DateTimePickerFormat.Short;
            dtDeadline.Location = new Point(21, 497);
            dtDeadline.Margin = new Padding(4, 5, 4, 5);
            dtDeadline.Name = "dtDeadline";
            dtDeadline.Size = new Size(441, 34);
            dtDeadline.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(21, 563);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(443, 30);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.Items.AddRange(new object[] { "open", "in-progress", "completed", "closed" });
            cmbStatus.Location = new Point(21, 597);
            cmbStatus.Margin = new Padding(4, 5, 4, 5);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(441, 36);
            cmbStatus.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(21, 675);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 60);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
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
            btnCancel.Location = new Point(236, 675);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 60);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(364, 675);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 60);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 255);
            ClientSize = new Size(1714, 1083);
            Controls.Add(panelTop);
            Controls.Add(dgvProjects);
            Controls.Add(panelForm);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Projects";
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Button btnAddProject;
        private DataGridView dgvProjects;
        private Panel panelForm;
        private Label lblFormTitle;
        private Label lblPTitle;
        private TextBox txtPTitle;
        private Label lblDesc;
        private TextBox txtDesc;
        private Label lblBudget;
        private TextBox txtBudget;
        private Label lblDeadline;
        private DateTimePicker dtDeadline;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
        private Button btnDelete;
    }
}