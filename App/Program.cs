using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MemMarkerRepository repository = new MemMarkerRepository();
            Controller controller = new Controller(repository);
            MainWindow mainWindow = new MainWindow(controller);
            Application.Run(mainWindow);
        }
    }
}
