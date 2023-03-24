using System;

namespace UnitTracker.Domain
{
    public class Marker
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
