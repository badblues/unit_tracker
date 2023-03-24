using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.Windows.Forms;
using UnitTracker.Controllers;
using UnitTracker.Domain;

namespace UnitTracker
{
    public partial class MainWindow : Form
    {
        private Controller controller;
        GMapOverlay gMapMarkers = new GMapOverlay();
        public MainWindow(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            gMap.ShowCenter = true;
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.Position = new GMap.NET.PointLatLng(55.01, 82.55);
            gMap.Overlays.Add(gMapMarkers);
            gMap.MouseDown += GMap_MouseDown;
            gMap.DragDrop += GMap_DragDrop;
            gMap.DragEnter += GMap_DragEnter;
            gMap.MouseMove += GMap_MouseMove;
        }

        private void GMap_MouseMove(object sender, MouseEventArgs e)
        {
            double lat = gMap.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMap.FromLocalToLatLng(e.X, e.Y).Lng;
            label1.Text = $"lat = {lat}, lng = {lng}\n x = {e.X}, y = {e.Y}";
            label2.Text = controller.GetMarkersAsText();
        }

        private void GMap_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void gMap_Load(object sender, EventArgs e)
        {
            foreach (Marker marker in controller.GetMarkers())
            {
                PlaceMarker(marker);
            }   
        }

        private void GMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            foreach (GMapMarker marker in gMapMarkers.Markers)
            {
                if (marker.IsMouseOver)
                {
                    gMap.DoDragDrop(marker, DragDropEffects.Move);
                    return;
                }
            }
        }

        private void GMap_DragDrop(object sender, DragEventArgs e)
        {
            GMapMarker marker = (GMapMarker)e.Data.GetData(typeof(GMarkerGoogle));
            if (marker != null)
            {
                Point window_point = gMap.PointToClient(new Point(e.X, e.Y));
                PointLatLng point = gMap.FromLocalToLatLng(window_point.X, window_point.Y);
                marker.Position = point;
                controller.MoveMarker((Guid)marker.Tag, point.Lat, point.Lng);
            }
        }

        private void PlaceMarker(Marker marker)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(new PointLatLng(marker.Latitude, marker.Longitude), GMarkerGoogleType.red);
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);
            mapMarker.Tag = marker.Id;
            gMapMarkers.Markers.Add(mapMarker);
        }

        private void AddMarkerButton_Click(object sender, EventArgs e)
        {
            Marker marker = controller.AddMarker(gMap.Position.Lat, gMap.Position.Lng);
            PlaceMarker(marker);
        }
    }
}
