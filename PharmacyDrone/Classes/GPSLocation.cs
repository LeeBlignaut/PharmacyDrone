using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PharmacyDrone.Classes
{
    class GPSLocation
    {
        private GeoCoordinate gpsLocation;
        private GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        private double distance;

        public GeoCoordinate GpsLocation { get => gpsLocation; set => gpsLocation = value; }
        public double Distance { get => distance; set => distance = value; }

        public GPSLocation()
        {

        }
        //public GPSLocation(GeoCoordinate coord)
        //{
        //    this.gpsLocation = coord;
        //}
        private void GetDistance()
        {
            GeoCoordinate distribution = new GeoCoordinate(-26.1394, 28.2468); //OR Tambo
            distance = gpsLocation.GetDistanceTo(distribution);
        }

        public void GetCurrentGPSLocation()
        {
            Notify notify = new Notify();
            // Create the watcher.
            watcher = new GeoCoordinateWatcher();

            // Catch the StatusChanged event.
            watcher.StatusChanged += Watcher_StatusChanged;

            // Start the watcher.
            watcher.Start();
            Thread.Sleep(3000);
        }
        public string longitude;
        public string latitude;
        public void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            Notify notify = new Notify();
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (watcher.Position.Location.IsUnknown)
                {
                    notify.warning("Failed to retrieve GPS location");
                }
                else
                {
                    GeoCoordinate coord = watcher.Position.Location;
                    gpsLocation = coord;
                    latitude = gpsLocation.Latitude.ToString();
                    longitude = gpsLocation.Longitude.ToString();

                    notify.success(latitude);
                    notify.success(longitude);



                }
            }
        }

     

        public override string ToString()
        {
            return "Long : " + gpsLocation.Longitude.ToString() + " Lat : " + gpsLocation.Latitude.ToString();
        }

    }
}
