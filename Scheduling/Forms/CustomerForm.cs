using Scheduling.Data.Repositories;
using Scheduling.Enums;
using Scheduling.Helpers;
using Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class CustomerForm : Form
    {
        private Mode _mode;
        private readonly CustomerRepository _customerRepository;
        
        public CustomerForm(IDatabase database, Mode mode)
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository(database);
            _mode = mode;
            this.Text = _mode == Mode.Create ? "Add Customer" : "Edit Customer";
            CenterControls();

        }

        private void CenterControls()
        {
            // Center Input controls vertically
            LayoutManager.CenterSingleNestedControlYMargins(pnlCustomerMain, pnlCustomerControls, 30, 30);
            // Center input control horizontially
            LayoutManager.CenterSingleNestedControlsX(pnlCustomerMain, pnlCustomerControls);

            // Center button controls
            LayoutManager.CenterSingleNestedControlsX(pnlCustomerMain, tplBtnControls);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
