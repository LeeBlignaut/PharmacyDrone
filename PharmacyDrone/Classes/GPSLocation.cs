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
        GeoCoordinate gpsLocation;

        public GeoCoordinate GpsLocation { get => gpsLocation; set => gpsLocation = value; }

        public GPSLocation()
        {

        }
        public double GetDistance()
        {
            GeoCoordinate distribution = new GeoCoordinate(-25.746020, 28.187120);
            return gpsLocation.GetDistanceTo(distribution);
        }

        public void GetCurrentGPSLocation()
        {
            Notify notify = new Notify();
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            GeoCoordinate coord = watcher.Position.Location;
            if (coord.IsUnknown != true)
            {
                gpsLocation = coord;
            }
            else
            {
                notify.warning("Failed to retrieve GPS location");
            }
        }

        public override string ToString()
        {
            return "Long : " + gpsLocation.Longitude + " Lat : " + gpsLocation.Latitude;
        }

    }
}
