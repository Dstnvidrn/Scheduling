using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class formLogin : Form
    {
        private int inputTextWidth = 175;
        private int inputTextHeight = 30;
        

        public formLogin()
        {
            InitializeComponent();
            this.AutoSize = false;
            dropdownLanguage.SelectedItem = "EN";
            // Set sizing for login form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            pnlLoginLeft.BackColor = Color.FromArgb(63, 72, 87);

            // Assign color schemes to controls
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml(Colors.PrimaryColor);
            btnLogin.BackColor = ColorTranslator.FromHtml(Colors.CtaColor);

            labelUserLocation.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor);
            labelDate.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor) ;
            labelTime.ForeColor = ColorTranslator.FromHtml(Colors.NeutralLightColor) ;

            // Set input text control height/width
            

        }
        
        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void labelTime_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dropdownLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
