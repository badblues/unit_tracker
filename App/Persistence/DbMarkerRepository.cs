using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using UnitTracker.Domain;
using UnitTracker.Persistence.Interfaces;

namespace App.Persistence
{
    public class DbMarkerRepository : IMarkerRepository
    {
        private SqlConnection connection;

        public DbMarkerRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            MessageBox.Show(connection.State.ToString());            
        }

        public void CreateMarker(Marker marker)
        {
            NumberFormatInfo nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
            string query = $"INSERT INTO marker (Id, Latitude, Longitude) VALUES('{marker.Id}', {marker.Latitude.ToString(nfi)}, {marker.Longitude.ToString(nfi)});";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }

        public void DeleteMarker(Guid id)
        {
            string query = $"DELETE FROM marker WHERE Id = '{id}';";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }

        public Marker GetMarker(Guid id)
        {
            string query = $"SELECT [Id], [Latitude], [Longitude] FROM marker WHERE Id = '{id}';";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Marker marker = null;
            try
            {
                reader.Read();
                marker = new Marker() { Id = (Guid)reader["Id"], Latitude = (double)reader["Latitude"], Longitude = (double)reader["Longitude"] };
            }
            finally
            {
                reader.Close();
            }
            return marker;
        }

        public IEnumerable<Marker> GetMarkers()
        {
            string query = "SELECT [Id], [Latitude], [Longitude] FROM marker;";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            //TODO try?
            List<Marker> markers = new List<Marker>();
            try
            {
                while (reader.Read())
                {
                    Marker marker = new Marker() { Id = (Guid)reader["Id"], Latitude = (double)reader["Latitude"], Longitude = (double)reader["Longitude"] };
                    markers.Add(marker);
                }
            }
            finally
            {
                reader.Close();
            }
            return markers;
        }

        public void UpdateMarker(Marker marker)
        {
            NumberFormatInfo nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
            string query = $"UPDATE marker SET Latitude = {marker.Latitude.ToString(nfi)}, Longitude = {marker.Longitude.ToString(nfi)} WHERE Id = '{marker.Id}';";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }
    }
}
