using System;
using System.Windows.Forms;

namespace LockSniffer
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SnifferAppContext());
        }
    }
}
