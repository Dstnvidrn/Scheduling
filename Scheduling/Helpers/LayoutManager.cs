using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling.Helpers
{
    public class LayoutManager
    {

        public static void CenterSingleNestedControl(Control outerPanel, Control innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
        }
        public static void CenterDuoNestedControls(Control outerControl, Control innerControl1, Control innerControl2, int spaceBetweenInner)
        {
            // Calculate total width as a combined unit
            int totalWidth = innerControl1.Width + spaceBetweenInner + innerControl2.Width;

            // Calculate starting x position to center combined unit
            int startingX = (outerControl.Width - totalWidth) / 2;

            // Position controls
            innerControl1.Left = startingX;
            innerControl2.Left = startingX + spaceBetweenInner + innerControl1.Width;
        }

    }
}
