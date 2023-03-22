using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Windows.Forms;

namespace App
{
    public partial class MainWindow : Form
    {
        private Controller controller;
        GMapOverlay gMapMarkers = new GMapOverlay();
        public MainWindow(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            gMap.ShowCenter = false;
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.Position = new GMap.NET.PointLatLng(55.01, 82.55);
            gMap.Overlays.Add(gMapMarkers);
        }

        private void gMap_Load(object sender, System.EventArgs e)
        {
            foreach (Marker marker in controller.GetMarkers())
            {
                PlaceMarker(marker);
            }   
        }

        private void PlaceMarker(Marker marker)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng(marker.Latitude, marker.Longitude), GMarkerGoogleType.red);
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);
            gMapMarkers.Markers.Add(mapMarker);
        }

        private void AddMarkerButton_Click(object sender, System.EventArgs e)
        {
            Marker marker = controller.AddMarker(gMap.Position.Lat, gMap.Position.Lng);
            PlaceMarker(marker);
        }
    }
}
