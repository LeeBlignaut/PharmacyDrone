using PharmacyDrone.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyDrone.Classes
{
    class MedicalSupply
    {
        private int supplyId;
        private string supplyName;
        private string supplyType;
        private string supplyDesc;
        private int supplyPrice;
        public int SupplyId { get => supplyId; set => supplyId = value; }
        public string SupplyName { get => supplyName; set => supplyName = value; }
        public string SupplyDesc { get => supplyDesc; set => supplyDesc = value; }
        public int SupplyPrice { get => supplyPrice; set => supplyPrice = value; }
        public string SupplyType { get => supplyType; set => supplyType = value; }
        public MedicalSupply()
        {

        }
        public MedicalSupply(int supplyId, string supplyName, string supplyType, string supplyDesc, int supplyPrice)
        {
            this.supplyId = supplyId;
            this.supplyName = supplyName;
            this.supplyType = supplyType;
            this.supplyDesc = supplyDesc;
            this.supplyPrice = supplyPrice;
        }
        public MedicalSupply(string supplyName, string supplyType, string supplyDesc, int supplyPrice)
        {
            this.supplyName = supplyName;
            this.supplyType = supplyType;
            this.supplyDesc = supplyDesc;
            this.supplyPrice = supplyPrice;
        }
      

        public List<MedicalSupply> readMedicalSupplies()
        {
            DatahandlerR dr = new DatahandlerR();
            List<MedicalSupply> medicalSupplyList = dr.ReadMedicalSupplies();
            return medicalSupplyList;
        }

        public MedicalSupply readMedicalSuppliesByID(int id)
        {
            DatahandlerR dr = new DatahandlerR();
            MedicalSupply ms = dr.ReadMedicalSuppliesByID(id);
            return ms;
        }


    }
}
