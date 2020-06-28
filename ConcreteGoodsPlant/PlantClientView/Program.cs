using PlantBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;

namespace PlantClientView
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new FormEnter();
            form.ShowDialog();
            if (Client != null)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
