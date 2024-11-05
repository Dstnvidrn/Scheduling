using Scheduling.Data;
using System;
using Scheduling.Helpers;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class AppointmentsForm : Form
    {
        private int? _userId;
        private readonly MySqlDatabase _database;
        public AppointmentsForm()
        {
            InitializeComponent();
        }
        public AppointmentsForm(MySqlDatabase database, int? userId)
        {
            InitializeComponent();
            _userId = userId;
            _database = database;
            dgvAppointments.Width = this.Width;
            dgvAppointments.Height = this.Height;
            pnlContainer.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnCreate.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);

            
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            RenameColumnHeaders();
            LayoutManager.CenterSingleNestedControl(pnlContainer, tlpMenuOptions);
            LayoutManager.CenterSingleNestedControl(pnlContainer, tlpLogoutOption);
            LayoutManager.CenterSingleNestedControl(pnlContainer, lblAppointments);
            LayoutManager.CenterSingleNestedControl(pnlContainer, lblCustomers);
            // Set placerholder text in search box
            LayoutManager.SetPlacholderText(txtAppointmentSearch, "Search", Colors.NeutalDarkColor);
        }
        
        
        private void RenameColumnHeaders()
        {
            dgvAppointments.AutoGenerateColumns = false;
            //Rename table headers for greater readability
            
            dgvAppointments.Columns["customerName"].HeaderText = "Customer Name";
            dgvAppointments.Columns["title"].HeaderText = "Title";
            dgvAppointments.Columns["description"].HeaderText = "Description";
            dgvAppointments.Columns["location"].HeaderText = "Location";
            dgvAppointments.Columns["contact"].HeaderText = "Contact";
            dgvAppointments.Columns["type"].HeaderText = "Type";
            dgvAppointments.Columns["createDate"].HeaderText = "Created Date";
            dgvAppointments.Columns["createdBy"].HeaderText = "Created By";
            dgvAppointments.Columns["lastUpdate"].HeaderText = "Last Update";
            dgvAppointments.Columns["lastUpdateBy"].HeaderText = "Updated By";
        }
        private void PopulateDataGridView()
        {
            try
            {
                DataTable userData = _database.GetAppointments();

                dgvAppointments.DataSource = userData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void txtAppointmentSearch_Enter(object sender, EventArgs e)
        {
            TextBox searchTxt = sender as TextBox;
            if (searchTxt != null && searchTxt.ForeColor == ColorTranslator.FromHtml(Colors.NeutalDarkColor))
            {
                LayoutManager.SetPlacholderText((sender as TextBox), "", "#000000");
            }
        }
        private void txtAppointmentSearch_Exit(object sender, EventArgs e)
        {
            TextBox searchTxt = sender as TextBox;
            if (searchTxt != null && string.IsNullOrEmpty(searchTxt.Text))
            {
                LayoutManager.SetPlacholderText((sender as TextBox), "Search", Colors.NeutalDarkColor);
            }
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
