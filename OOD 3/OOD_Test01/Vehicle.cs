using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    abstract class Vehicle
    {
        public List<History> vehicleHistory;
        protected string make;
        protected string model;
        protected int weight;
        protected string regNo;

        public Vehicle(string make, string model, int weight, string regNo)

        {
            this.make = make;
            this.model = model;
            this.weight = weight;
            this.regNo = regNo;
            vehicleHistory = new List<History>();
        }

        public void GetHistory() {
     
        foreach (History myHistory in vehicleHistory) { 
        Console.WriteLine(myHistory.getComment());
            
            }
        }

        public string GetVehiclesMake()
        {
            return make;
        }

        public string GetVehiclesModel()
        {
            return model;
        }

        public int GetVehiclesWeight()
        {
            return weight;
        }

        public string GetVehiclesRegNo()
        {
            return regNo;
        }

        public void AddHistory(History myHistory)
        {
            vehicleHistory.Add(myHistory);
        }

        public virtual string GetCargoCapacity()
        {
            return ("--");
        }

        public virtual string GetLiquidCapacity()
        {
            return ("--");
        }

        public virtual string GetLiquidType()
        {
            return ("--");
        }

        public void AddHistory(DateTime date, string type, string comments)
        {
            AddHistory(new History(date, type, comments));
        }
    }

}
