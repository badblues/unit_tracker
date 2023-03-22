using System;
using System.Collections.Generic;

namespace App
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
            Marker marker = new Marker() { Id = new Guid(),  Latitude = lat, Longitude = lng };
            repository.CreateMarker(marker);
            return marker;
        }

    }
}
