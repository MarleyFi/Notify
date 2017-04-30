using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notify
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new FrmNotify());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error on startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //FrmNotify.NotifyMessage(250, "Notify crashed", e.Message, ToolTipIcon.Error);
            }
        }
    }
}
