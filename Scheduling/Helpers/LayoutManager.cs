using System.Drawing;
using System.Windows.Forms;

namespace Scheduling.Helpers
{
    public class LayoutManager
    {

        public static void CenterSingleNestedControlsX(Control outerPanel, Control innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
        }
        public static void CenterSingleNestedControlsXMargins(Control outerPanel, Control innerPanel, int leftGap, int rightGap)
        {
            innerPanel.Left = leftGap + ((outerPanel.Width - innerPanel.Width - leftGap - rightGap) / 2);
        }
        public static void CenterDuoNestedControlsX(Control outerControl, Control innerControl1, Control innerControl2, int spaceBetweenInner)
        {
            // Calculate total width as a combined unit
            int totalWidth = innerControl1.Width + spaceBetweenInner + innerControl2.Width;

            // Calculate starting x position to center combined unit
            int startingX = (outerControl.Width - totalWidth) / 2;

            // Position controls
            innerControl1.Left = startingX;
            innerControl2.Left = startingX + spaceBetweenInner + innerControl1.Width;
        }
        public static void CenterSingleNestedControlYMargins(Control outerControl, Control innerControl, int topGap, int bottomGap)
        {

            innerControl.Top = topGap + ((outerControl.Height - innerControl.Height - topGap - bottomGap) / 2);
        }

        public static void SetPlacholderText(TextBox textBox, string text, string hexColor)
        {
            textBox.Text = text;
            textBox.ForeColor = ColorTranslator.FromHtml(hexColor);
        }
        public static string Capitalize(params string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = $"{strings[i][0].ToString().ToUpper()}{strings[i].Substring(1)}";
            }
            return string.Join(" ", strings);
        }

    }
}
