using Scheduling.Data;
using System;
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
            appointmentTable.Width = this.Width;
            appointmentTable.Height = this.Height;


            asideAppointments.BackColor = ColorTranslator.FromHtml(Colors.BaseColor);
            btnCreate.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);
        }

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
        private void PopulateDataGridView()
        {
            try
            {
                DataTable userData = _database.GetAppointments();

                appointmentTable.DataSource = userData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
