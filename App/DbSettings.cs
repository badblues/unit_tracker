using System.Configuration;

namespace UnitTracker
{
    public class DbSettings
    {
        public string ConnectionString { get; }
        public DbSettings()
        {
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            ConnectionString = $"Data Source =; Initial Catalog = unit_tracker; User ID = {username}; Password = {password}; TrustServerCertificate = True";
        }
    }
}
