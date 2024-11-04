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

        public static void CenterNestedControl(Control outerPanel, Control innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
        }
    }
}
