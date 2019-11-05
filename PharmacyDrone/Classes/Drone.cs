using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyDrone.DataHandlers;

namespace PharmacyDrone.Classes
{
    class Drone
    {
        private int droneID;
        private string droneName;

        public int DroneID { get => droneID; set => droneID = value; }
        public string DroneName { get => droneName; set => droneName = value; }

        public Drone(int droneID, string droneName)
        {
            this.droneID = droneID;
            this.droneName = droneName;
        }
        public Drone()
        {

        }

        public override string ToString()
        {
            return "Drone Name : " + droneName + " Drone ID : " + droneID;
        }
        public void GetDrone()
        {
            Drone temp = DatahandlerR.SelectDrone();
            this.droneID = temp.droneID;
            this.droneName = temp.droneName;
        }
        public void SelectDroneByID()
        {
            Drone temp = DatahandlerR.SelectDroneByID(this.droneID);
            this.droneID = temp.droneID;
            this.droneName = temp.droneName;
        }
    }
}
