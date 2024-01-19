using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    class WorkSchedule
    {
        private string driver;
        private string vehicle;
        private string client;
        private DateTime startDate;
        private DateTime endDate;

        public WorkSchedule(string newDriver, string newVehicle, string newClient, DateTime newStartDate, DateTime newEndDate)
        {

           this.driver = newDriver;
           this.vehicle = newVehicle;
           this.client = newClient;
           this.startDate = newStartDate;
           this.endDate = newEndDate;
       
       }

       public string GetDrive()
       {
           return driver;
       }

        public string GetVehicle()
        {
            return vehicle;
        }

        public string GetClient()
        {
            return client;
        }

        public DateTime GetStartDate()
        {
            return startDate;
        }

        public DateTime GetEndDate()
        {
            return endDate;
        }

        public bool CheckDate(DateTime date)
        {
            if (startDate == date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
