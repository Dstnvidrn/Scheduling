using Scheduling.DTOs;
using Scheduling.Enums;
using Scheduling.Helpers;
using System;
using System.Windows.Forms;

namespace Scheduling.Forms
{
    public partial class AppointmentManager : Form
    {
        public AppointmentManager(Mode mode, UserDTO loggedInUser)
        {
            InitializeComponent();
            AdjustLayout();
            if (mode == Mode.Create) { BtnOperation.Text = "Create"; }

        }
        private void AdjustLayout()
        {
            LayoutManager.CenterSingleNestedControlsX(pnlMiddle, tblInputs);
        }
        private void AppointmentManger_Load(object sender, EventArgs e)
        {

        }
    }
}
