﻿using System;
using System.Collections.Generic;

namespace App
{
    public class MemMarkerRepository : IMarkerRepository
    {
        private readonly List<Marker> markers = new List<Marker>();  

        public MemMarkerRepository()
        {
            Marker marker = new Marker() { Latitude = 55.01, Longitude = 82.55 };
            markers.Add(marker);
        }

        public void CreateMarker(Marker marker)
        {
            markers.Add(marker);
        }

        public void DeleteMarker(Guid id)
        {
            Marker marker = markers.Find(x => x.Id == id);
            markers.Remove(marker);
        }

        public Marker GetMarkers(Guid id)
        {
            return markers.Find(x => x.Id == id);
        }

        public IEnumerable<Marker> GetMarkers()
        {
            return markers;
        }

        public void UpdateMarker(Marker marker)
        {
            Marker oldMarker = markers.Find(x => x.Id == marker.Id);
            oldMarker.Latitude = marker.Latitude;
            oldMarker.Longitude = marker.Longitude;
        }
    }
}
