using App.Persistence;
using System;
using System.Windows.Forms;
using UnitTracker.Controllers;
using UnitTracker.Persistence;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnitTracker
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
            String connString = "Data Source =; Initial Catalog = unit_tracker; User ID = unit_tracker_admin; Password = admin; TrustServerCertificate = True";
            DbMarkerRepository repository = new DbMarkerRepository(connString);
            Controller controller = new Controller(repository);
            MainWindow mainWindow = new MainWindow(controller);
            Application.Run(mainWindow);
        }
    }
}
