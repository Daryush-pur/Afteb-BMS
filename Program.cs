using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFTAB
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Pass a temporary empty role when starting the application
            Main mainForm = new Main("");  // Empty or placeholder role
            Application.Run(mainForm);
        }
    }
}
