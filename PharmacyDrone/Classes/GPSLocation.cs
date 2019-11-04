using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyDrone.Classes
{
    class GPSLocation
    {
        public GeoCoordinate gpsLocation;
        private GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

        public GeoCoordinate GpsLocation { get => gpsLocation; set => gpsLocation = value; }

        public GPSLocation()
        {

        }
        public GPSLocation(GeoCoordinate coord)
        {
            this.gpsLocation = coord;
        }
        public double GetDistance()
        {
            GeoCoordinate distribution = new GeoCoordinate(26.1394, 28.2468); //OR Tambo
            return gpsLocation.GetDistanceTo(distribution);
        }

        public void GetCurrentGPSLocation()
        {
            
            watcher.StatusChanged += Watcher_StatusChanged;
            watcher.Start();
            
        }
        public void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            Notify notify = new Notify();
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (watcher.Position.Location.IsUnknown)
                {
                    Console.WriteLine("Cannot find location data");
                }
                else
                {
                    GeoCoordinate coord =watcher.Position.Location;
                    if (coord.IsUnknown != true)
                    {
                        gpsLocation = coord;
                    }
                    else
                    {
                        notify.warning("Failed to retrieve GPS location");
                    }
                }
            }
        public override string ToString()
        {
            return "Long : " + gpsLocation.Longitude + " Lat : " + gpsLocation.Latitude;
        }

    }
}
