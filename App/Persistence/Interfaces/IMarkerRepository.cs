
using System.Collections.Generic;
using System;
using UnitTracker.Domain;

namespace UnitTracker.Persistence.Interfaces
{
    public interface IMarkerRepository
    {
        Marker GetMarker(Guid id);
        IEnumerable<Marker> GetMarkers();
        void CreateMarker(Marker marker);
        void UpdateMarker(Marker marker);
        void DeleteMarker(Guid id);
    }
}
