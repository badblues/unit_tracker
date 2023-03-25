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
            //Map settings
            gMap.ShowCenter = true;
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMap.Position = new PointLatLng(55.01, 82.55);
            gMap.Overlays.Add(gMapMarkers);
            gMap.MouseDown += GMap_MouseDown;
            gMap.DragDrop += GMap_DragDrop;
            gMap.DragEnter += GMap_DragEnter;
            foreach (Marker marker in controller.GetMarkers())
            {
                PlaceMarker(marker);
            }
        } 

        private void GMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (GMapMarker marker_ in gMapMarkers.Markers)
                {
                    if (marker_.IsMouseOver)
                    {
                        gMap.DoDragDrop(marker_, DragDropEffects.Move);
                        return;
                    }
                }
                PointLatLng point = gMap.FromLocalToLatLng(e.X, e.Y);
                Marker marker = controller.AddMarker(point.Lat, point.Lng);
                PlaceMarker(marker);
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (GMapMarker marker_ in gMapMarkers.Markers)
                {
                    if (marker_.IsMouseOver)
                    {
                        controller.DeleteMarker((Guid)marker_.Tag);
                        gMapMarkers.Markers.Remove(marker_);
                        return;
                    }
                }
            }
        }

        private void GMap_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void GMap_DragDrop(object sender, DragEventArgs e)
        {
            GMapMarker marker = (GMapMarker)e.Data.GetData(typeof(GMarkerGoogle));
            if (marker != null)
            {
                Point window_point = gMap.PointToClient(new Point(e.X, e.Y));
                PointLatLng point = gMap.FromLocalToLatLng(window_point.X, window_point.Y);
                marker.Position = point;
                controller.UpdateMarker((Guid)marker.Tag, point.Lat, point.Lng);
            }
        }

        private void PlaceMarker(Marker marker)
        {
            GMarkerGoogle mapMarker = new GMarkerGoogle(new PointLatLng(marker.Latitude, marker.Longitude), GMarkerGoogleType.red);
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);
            mapMarker.Tag = marker.Id;
            gMapMarkers.Markers.Add(mapMarker);
        }
    }
}
