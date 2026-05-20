using System;
using System.Windows.Forms;
using Freelance_Platform.Database;
using Freelance_Platform.Models;

namespace Freelance_Platform.Forms
{
    public partial class ProjectForm : Form
    {
        private readonly ProjectRepository _projectRepo = new ProjectRepository();
        private int _selectedProjectId = 0;
        private bool _isEditing = false;

        public ProjectForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnAddProject.Visible = Freelance_Platform.Session.IsClient;
            SetupGrid();
            LoadProjects();
        }

        private void SetupGrid()
        {
            dgvProjects.Rows.Clear();
            dgvProjects.Columns.Clear();
            dgvProjects.AutoGenerateColumns = false;

            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "project_id",
                HeaderText = "ID",
                Visible = false
            });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "title",
                HeaderText = "Title",
                FillWeight = 30
            });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "client_name",
                HeaderText = "Client",
                FillWeight = 20
            });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "budget",
                HeaderText = "Budget (PKR)",
                FillWeight = 15
            });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "deadline",
                HeaderText = "Deadline",
                FillWeight = 15
            });
            dgvProjects.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "status",
                HeaderText = "Status",
                FillWeight = 10
            });

            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadProjects()
        {
            dgvProjects.Rows.Clear();

            try
            {
                var projects = Freelance_Platform.Session.IsClient
                    ? _projectRepo.GetProjectsByClient(Freelance_Platform.Session.ClientId)
                    : _projectRepo.GetOpenProjects();

                if (projects.Count == 0)
                {
                    // Show message inside grid area
                    dgvProjects.Rows.Add(0, "No projects found.", "", "", "", "");
                    return;
                }

                foreach (var p in projects)
                {
                    dgvProjects.Rows.Add(
                        p.ProjectId,
                        p.Title,
                        p.ClientName,
                        $"PKR {p.Budget:N0}",
                        p.Deadline,
                        p.Status.ToUpper()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            _selectedProjectId = 0;
            lblFormTitle.Text = "Add New Project";
            btnDelete.Visible = false;
            btnSave.Visible = true;
            ClearForm();
            panelForm.Visible = true;
            this.Width = 1200;
        }

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProjects.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["project_id"].Value);
            if (id == 0) return; // this is the "No projects found" row

            _selectedProjectId = id;
            var project = _projectRepo.GetProjectById(_selectedProjectId);
            if (project == null) return;

            txtPTitle.Text = project.Title;
            txtDesc.Text = project.Description;
            txtBudget.Text = project.Budget.ToString();
            cmbStatus.Text = project.Status;

            if (DateTime.TryParse(project.Deadline, out DateTime dl))
                dtDeadline.Value = dl;

            _isEditing = true;
            lblFormTitle.Text = "Edit Project";
            btnDelete.Visible = Freelance_Platform.Session.IsClient;
            btnSave.Visible = Freelance_Platform.Session.IsClient;
            panelForm.Visible = true;
            this.Width = 1200;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtPTitle.Text))
            {
                MessageBox.Show("Please enter a project title.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBudget.Text))
            {
                MessageBox.Show("Please enter a budget.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtBudget.Text, out double budget))
            {
                MessageBox.Show("Budget must be a number. Example: 50000",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check client ID
            if (Freelance_Platform.Session.ClientId == 0)
            {
                MessageBox.Show("Client ID not found. Please logout and login again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var project = new Project
            {
                ProjectId = _selectedProjectId,
                ClientId = Freelance_Platform.Session.ClientId,
                Title = txtPTitle.Text.Trim(),
                Description = txtDesc.Text.Trim(),
                Budget = budget,
                Deadline = dtDeadline.Value.ToString("yyyy-MM-dd"),
                Status = cmbStatus.SelectedItem?.ToString() ?? "open"
            };

            bool success = _isEditing
                ? _projectRepo.UpdateProject(project)
                : _projectRepo.AddProject(project);

            if (success)
            {
                MessageBox.Show(
                    _isEditing ? "Project updated successfully!" : "Project added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                panelForm.Visible = false;
                this.Width = 860;
                ClearForm();
                LoadProjects();  // Reload grid
            }
            else
            {
                MessageBox.Show(
                    "Failed to save project. Your Client ID may not be set correctly.\n" +
                    "Client ID: " + Freelance_Platform.Session.ClientId,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProjectId == 0) return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this project?",
                "Delete Project", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = _projectRepo.DeleteProject(_selectedProjectId);
                if (success)
                {
                    MessageBox.Show("Project deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelForm.Visible = false;
                    this.Width = 860;
                    LoadProjects();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelForm.Visible = false;
            this.Width = 860;
            ClearForm();
        }

        private void ClearForm()
        {
            txtPTitle.Clear();
            txtDesc.Clear();
            txtBudget.Clear();
            dtDeadline.Value = DateTime.Today;
            cmbStatus.SelectedIndex = 0;
        }
    }
}
