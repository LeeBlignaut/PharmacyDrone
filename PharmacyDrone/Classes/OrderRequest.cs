using PharmacyDrone.DataHandlers;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyDrone.Classes
{
    class OrderRequest
    {
        private int orderID;
        private int orderNum;
        private int medicalSupplyID;
        private int userID;
        private int droneID;
        private GeoCoordinate gpsLocation;


        public int OrderID { get => orderID; set => orderID = value; }
        public int MedicalSupplyID { get => medicalSupplyID; set => medicalSupplyID = value; }
        public int OrderNum { get => orderNum; set => orderNum = value; }
        public int UserID { get => userID; set => userID = value; }
        public int DroneID { get => droneID; set => droneID = value; }
        public GeoCoordinate GpsLocation { get => gpsLocation; set => gpsLocation = value; }

        public OrderRequest(int orderNum, int medicalSupplyID, int userID)
        {
            this.orderNum = orderNum;
            this.medicalSupplyID = medicalSupplyID;
            this.userID = userID;
        }

        public OrderRequest(int orderID, int orderNum, int medicalSupplyID, int userID)
        {
            this.orderID = orderID;
            this.orderNum = orderNum;
            this.medicalSupplyID = medicalSupplyID;
            this.userID = userID;
        }

        public OrderRequest()
        {

        }


        public int GenerateNum()
        {
          
            return (new Random()).Next(10, 100); 
        }

        public bool InsertOrderRequests(OrderRequest or)
        {
            return DatahandlerR.InsertOrderRequest(or);
        }

        public List<OrderRequest> ReadOrderRequests()
        {
            return DatahandlerR.ReadOrderRequests();
        }

        public void DeleteOrderByID(int id)
        {
            DatahandlerR.DeleteOrderByID(id);
        }
        public void SetDrone(int droneID)
        {
            this.droneID = droneID;
        }
        public void SetGeoLocaton(GeoCoordinate gpsLocation)
        {
            this.gpsLocation = gpsLocation;
        }
        public bool UpdateState(int userId)
        {
            return DatahandlerR.UpdateOrderState(userId);
        }
    }
}
