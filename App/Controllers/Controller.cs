using System;
using System.Collections.Generic;
using UnitTracker.Domain;
using UnitTracker.Persistence;

namespace UnitTracker.Controllers
{
    public class Controller
    {
        private MemMarkerRepository repository;
        public Controller(MemMarkerRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Marker> GetMarkers()
        {
            return repository.GetMarkers();
        }

        public Marker AddMarker(double lat, double lng)
        {
            Marker marker = new Marker() { Id = Guid.NewGuid(),  Latitude = lat, Longitude = lng };
            repository.CreateMarker(marker);
            return marker;
        }

        public void MoveMarker(Guid id, double lat, double lng)
        {
            Marker marker = new Marker() { Id = id, Latitude = lat, Longitude = lng };
            repository.UpdateMarker(marker);
        }

        public void DeleteMarker(Guid id)
        {
            repository.DeleteMarker(id);
        }

        public String GetMarkersAsText()
        {
            string res = "";
            foreach (Marker marker in repository.GetMarkers())
            {
                res += $"id = {marker.Id}\nlat = {marker.Latitude}, lng = {marker.Longitude}\n";
            }
            return res;

        }
    }
}
