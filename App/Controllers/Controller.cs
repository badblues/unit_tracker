using System;
using System.Collections.Generic;
using UnitTracker.Domain;
using UnitTracker.Persistence.Interfaces;

namespace UnitTracker.Controllers
{
    public class Controller
    {
        private IMarkerRepository repository;
        public Controller(IMarkerRepository repository)
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

        public void UpdateMarker(Guid id, double lat, double lng)
        {
            Marker marker = new Marker() { Id = id, Latitude = lat, Longitude = lng };
            repository.UpdateMarker(marker);
        }

        public void DeleteMarker(Guid id)
        {
            repository.DeleteMarker(id);
        }
    }
}
