using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    class Depot
    {
        public List<Driver> drivers;
        public List<Vehicle> vehicles;
        public List<WorkSchedule> workSchedule;
        private bool checkLogin;
        private string defaultLogin = "";
        private string depotName;
        private string userName;
        private DateTime Date;
        private int userChoice;

        public Depot(string depotName)
        {
            this.drivers = new List<Driver>();
            this.vehicles = new List<Vehicle>();
            this.workSchedule = new List<WorkSchedule>();
            this.depotName = depotName;
            checkLogin = false;
        }

        public void ViewVehicleHistory() 
        {
            Console.Write("Select Vehicle: ");
            userChoice = Convert.ToInt32(Console.ReadLine());
            vehicles[userChoice - 1].GetHistory();
            Console.ReadLine();
        }

        public void LogOn()
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to the " + this.depotName + " eDepot System");
                Console.Write("\nPlease Enter Username : ");
                string userName = Console.ReadLine();
                this.userName = userName;
                Console.Write("\nPlease Enter Password : ");
                string userPass = Console.ReadLine();

                checkLogin = AuthenticateUser(userName, userPass);

                if (checkLogin)
                {
                    this.defaultLogin = userName;
                    break;
                }
                else
                {
                    Console.Write("\nWrong Username Provided. Please Enter Valid Username");
                    Console.ReadLine();
                    Console.Clear();
                    
                }
            } while (!checkLogin);
        }

        public string GetLoginName() {

            return this.userName;

        }

        public string GetDepotName()
        {
            return this.depotName;
        }

        public void AddDriver(Driver theDriver)
        {
            drivers.Add(theDriver);
        }
        
        public void AddVehicle(Vehicle theVehicle)
        {
            vehicles.Add(theVehicle);
        }

        public void AddWorkSchedule(WorkSchedule theWorkSchedule)
        {
            workSchedule.Add(theWorkSchedule);
        }

        public void NewWorkScheduleDate(string newDriver, string newVehicle, string newClient, DateTime newStartDate, DateTime newEndDate)
        {
            AddWorkSchedule(new WorkSchedule(newDriver, newVehicle, newClient, newStartDate, newEndDate));
        }

        public void ViewWorkSchedule()
        {
            Console.Clear();
            Console.WriteLine("Work Schedules");
            int counter = 1;
            
            foreach (WorkSchedule ScheduleAccount in workSchedule)
            {
                
                if (userName == ScheduleAccount.GetDrive())
                {
                    Console.WriteLine
                        ( "\n" + counter++ + ".Work Schedule"
                        + "\n" + "Vehicle Name: " + ScheduleAccount.GetVehicle()
                        + "\n" + "Client Name: " + ScheduleAccount.GetClient()
                        + "\n" + "Start Date: " + ScheduleAccount.GetStartDate().ToString("dd MMM yy")
                        + "\n" + "End Date: " + ScheduleAccount.GetEndDate().ToString("dd MMM yy")
                        );
                }
                
            }
        }

        public void SetUpWorkSchedule() 
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Set Up Work Schedule");
                string client;
                SetWorkScheduleDate();
                LocateDriver();
                LocateVehicle();
                Console.Write("\nClient Name: ");
                client = Console.ReadLine();
                Console.ReadLine();
                //break;
                NewWorkScheduleDate(drivers[userChoice - 1].GetUserName(),
                                                 vehicles[userChoice - 1].GetVehiclesMake(),
                                                 client,
                                                 this.Date,
                                                 this.Date.AddDays(+3));
            } while (true);

        }

        public void SetWorkScheduleDate()
        {
            string input;
            Console.WriteLine("\nWork Schedule Start Date");
            do
            {
            Console.Write("\nPlease enter a date in the following format (dd-mm-yyyy): ");
            input = Console.ReadLine();

            if (!DateTime.TryParse(input, out this.Date) || this.Date < DateTime.Now.AddDays(+2))
            {
                Console.Write("\n{0} is not a valid choice.Try again...", input);
                Console.ReadLine();
                continue;
            }

            if (DateTime.TryParse(input, out this.Date) || this.Date > DateTime.Now.AddDays(+2))
            {
                Console.WriteLine("\nThe new work schedule start date will be: " + this.Date.ToString("dd MMM yy") + 
                 "\n" + "The work schedule end date will be: " + this.Date.AddDays(+3).ToString("dd MMM yy"));

            }

            } while (!DateTime.TryParse(input, out this.Date) || this.Date < DateTime.Now.AddDays(+2));

        }

        public void LocateDriver()
        {
            string driverName;
            Console.WriteLine("\nSelect Driver from the List");
            do
            {
                Console.WriteLine("");
                for (int index = 0; index < drivers.Count; index++)
                {
                    Console.WriteLine((index + 1).ToString() + " : " + drivers[index].GetUserName());
                }

                Console.Write("\nSelect Driver(Number): ");
                driverName = Console.ReadLine();

                if (!int.TryParse(driverName, out userChoice) || (userChoice <= 0) || (userChoice >= 3))
                {
                    Console.Write("\n{0} is not a valid choice.Try again...", driverName);
                    Console.ReadLine();
                    continue;
                }

                if ((userChoice > 0) && (userChoice < 3))
                {
                    Console.WriteLine("\nYou have selected " + drivers[userChoice - 1].GetUserName());
                }

                if (!IsDriverAvailable(this.Date, drivers[userChoice - 1].GetUserName()))
                {
                    Console.WriteLine("The selected driver is not available at the selected date");
                }


            } while ((userChoice <= 0) || (userChoice >= 3) || !IsDriverAvailable(this.Date, drivers[userChoice - 1].GetUserName()));
        }

        public void LocateVehicle()
        {
            string vehicleName;
            Console.WriteLine("\nSelect Vehicle from the List");
            do{
            Console.WriteLine("");
            for (int index = 0; index < vehicles.Count; index++)
            {
                Console.WriteLine((index + 1).ToString() + " : " + vehicles[index].GetVehiclesMake() +
                " Vehicle Type: (" + vehicles[index].GetType().Name + ")");
            }

            Console.Write("\nSelect Vehicle(Number): ");
            vehicleName = Console.ReadLine();

            if (!int.TryParse(vehicleName, out userChoice) || (userChoice <= 0) || (userChoice >= 3))
            {
                Console.Write("\n{0} is not a valid choice.Try again...", vehicleName);
                Console.ReadLine();
                continue;
            }

            if ((userChoice > 0) && (userChoice < 3))
            {
                Console.WriteLine("\nYou have selected " + vehicles[userChoice - 1].GetVehiclesMake());
            }

            if (!IsVehicleAvailable(this.Date, vehicles[userChoice - 1].GetVehiclesMake()))
            {
                Console.WriteLine("The selected vehicle is not available at the selected date");
            }

            } while ((userChoice <= 0) || (userChoice >= 3) || !IsVehicleAvailable(this.Date, vehicles[userChoice - 1].GetVehiclesMake()));


        }

        public bool IsDriverAvailable(DateTime workDate,string driverName)
        {

            foreach (WorkSchedule myWorkSchedule in workSchedule) {

                if (myWorkSchedule.GetDrive() == driverName)
                {
                    if (myWorkSchedule.CheckDate(workDate))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool IsVehicleAvailable(DateTime workDate, string vehicleName)
        {
           foreach (WorkSchedule myWorkSchedule in workSchedule) {

                if (myWorkSchedule.GetVehicle() == vehicleName)
                {
                    if (myWorkSchedule.CheckDate(workDate))
                    {
                        return false;
                    }
                }

            }
           return true;
        }

        public bool AuthenticateUser(string userName, string userPassword)
        {
            foreach (Driver myDriver in drivers)
            {
                if (myDriver.GetUserName() == userName)
                {
                    if (myDriver.CheckPassword(userPassword))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsManager(string userName)
        {
            foreach (Driver myDriver in drivers)
            {
                if (myDriver.GetUserName() == userName)
                {
                    if (myDriver is Manager)
                {
                        return true;
                    }
                }
            }
            return false;
        }

        public Vehicle RemoveVehicle(string vehicleName) 
        {
            Vehicle SelectedVehicle = vehicles.Single(o => o.GetVehiclesRegNo() == vehicleName);

            vehicles.Remove(SelectedVehicle);

            return SelectedVehicle;
        }

        }
        
     }

    

