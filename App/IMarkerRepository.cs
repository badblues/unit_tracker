
using System.Collections.Generic;
using System;

namespace App
{
    public interface IMarkerRepository
    {
        Marker GetMarkers(Guid id);
        IEnumerable<Marker> GetMarkers();
        void CreateMarker(Marker marker);
        void UpdateMarker(Marker marker);
        void DeleteMarker(Guid id);
    }
}
