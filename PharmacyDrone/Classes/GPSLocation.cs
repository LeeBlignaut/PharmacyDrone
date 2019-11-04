using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Data;
using System.ComponentModel;
using System.Drawing;





namespace PharmacyDrone.Classes
{
    class GPSLocation
    {
        private string latitude;
        private string longitude;
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }

        public GPSLocation()
        {

        }
        public double GetDistance()
        {

            double earthRadiusKm = 6371;

            double dLat = degreesToRadians(-25.746020 - Double.Parse(latitude));
            double dLon = degreesToRadians(28.187120 - Double.Parse(longitude));

            double lat1 = degreesToRadians(Double.Parse(latitude));
            double lat2 = degreesToRadians(-25.746020);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return earthRadiusKm * c;
        }
        public double degreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public void GetCurrentGPSLocation()
        {
            Notify notify = new Notify();
            SerialPort serialPort1 = new SerialPort();
            try
            {
                serialPort1.Open();

                if(serialPort1.IsOpen)
                {
                    string data = serialPort1.ReadExisting();
                    string[] lines = data.Split('$');
                    for (int x = 0; x < lines.Length; x++)
                    {
                        string temp = lines[x];
                        string[] lineArr = temp.Split(',');
                        if(lineArr[0] == "GPGGA")
                        {
                            try
                            {
                                Double dlat = Convert.ToDouble(lineArr[2]);
                                dlat = dlat / 100;
                                string[] lat = dlat.ToString().Split('.');
                                this.latitude= lineArr[3].ToString() + lat[0].ToString() + "."
                                    +((Convert.ToDouble(lat[1]) /60)).ToString("#####");

                                Double dLon = Convert.ToDouble(lineArr[4]);
                                dLon = dLon / 100;
                                string[] lon = dLon.ToString().Split('.');
                                this.longitude = lineArr[5].ToString() +lon[0].ToString() + "." 
                                    +((Convert.ToDouble(lon[1]) /60)).ToString("#####");

                            }
                            catch
                            {
                                this.latitude = "GPS unavailible";
                                this.longitude = "GPS unavailible";
                            }
                        }
                    }
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                serialPort1.Close();
                notify.warning(ex.Message);
                throw;
            }
            
        }

        public override string ToString()
        {
            return "Long : " + longitude + " Lat : " + latitude;
        }


    }
}
