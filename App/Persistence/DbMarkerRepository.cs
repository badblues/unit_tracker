using System;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Windows.Forms;
using UnitTracker.Domain;
using UnitTracker.Persistence.Interfaces;

namespace App.Persistence
{
    public class DbMarkerRepository : IMarkerRepository
    {

        public DbMarkerRepository(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            MessageBox.Show(con.State.ToString());            
        }

        public void CreateMarker(Marker marker)
        {
            throw new NotImplementedException();
        }

        public void DeleteMarker(Guid id)
        {
            throw new NotImplementedException();
        }

        public Marker GetMarker(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Marker> GetMarkers()
        {
            throw new NotImplementedException();
        }

        public void UpdateMarker(Marker marker)
        {
            throw new NotImplementedException();
        }
    }
}
