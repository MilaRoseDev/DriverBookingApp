 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    class System
    {
        private List<Depot> myDepots;
        private int userChoice;
        private int depotChoice;
        private int vehicleChoice;
        private const string VIEW_WORK_SCHEDULE = "1";
        private const string ASSIGN_WORK_SCHEDULE = "2";
        private const string MOVE_VEHICLE = "3";
        private const string VIEW_VEHICLE_HISTORY = "4";
        private const string ADD_VEHICLE_HISTORY = "5";
        private const string LOGOUT = "6";

        public System()
        {
            myDepots = new List<Depot>();

            myDepots.Add(new Depot("Liverpool"));
            myDepots.Add(new Depot("Manchester"));
            myDepots.Add(new Depot("Warrington"));

            myDepots[0].AddDriver(new Manager("A", "1"));
            myDepots[0].AddDriver(new Driver("B", "2"));
            myDepots[0].AddVehicle(new Truck("Krupp", "MX 50", 10, "MR3T TRN", 50));
            myDepots[0].AddVehicle(new Tanker("Krupp", "TS 440", 10, "MR3T P4N", 50, "Oil"));
            myDepots[0].AddWorkSchedule(new WorkSchedule("A", "MX 50", "Brian", new DateTime(2012, 03, 26), new DateTime(2012, 03, 26)));
            myDepots[0].AddWorkSchedule(new WorkSchedule("A", "MX 50", "Brian", new DateTime(2012, 03, 26), new DateTime(2012, 03, 26)));
            myDepots[0].AddWorkSchedule(new WorkSchedule("B", "TS 440", "Paul", new DateTime(2012, 03, 26), new DateTime(2012, 03, 26)));
            myDepots[0].vehicles[0].AddHistory(new History(new DateTime(2011, 03, 26), "M.O.T", "Passed"));
            myDepots[0].vehicles[1].AddHistory(new History(new DateTime(2012, 03, 26), "Breakdown", "Flat Battery"));
            myDepots[0].vehicles[1].AddHistory(new History(new DateTime(2012, 03, 26), "Service", "Full Service"));

            myDepots[1].AddDriver(new Driver("C", "3"));
            myDepots[1].AddDriver(new Manager("D", "4"));
            myDepots[1].AddVehicle(new Truck("Krupp", "ZZ4", 10, "MR3T PPD", 30));
            myDepots[1].AddVehicle(new Tanker("Krupp", "A4 ZR", 10, "MR3T OOD", 20, "Oil"));
            myDepots[1].AddWorkSchedule(new WorkSchedule("C", "ZZ4", "Brian", new DateTime(2012, 03, 26), new DateTime(2012, 03, 26)));
            myDepots[1].AddWorkSchedule(new WorkSchedule("D", "A4 ZR", "Paul", new DateTime(2012, 03, 26), new DateTime(2012, 03, 26)));
            myDepots[1].vehicles[0].AddHistory(new History(new DateTime(2012, 03, 26), "Valet", "Fully Valeted"));
            myDepots[1].vehicles[1].AddHistory(new History(new DateTime(2012, 03, 26), "Valet", "Fully Valeted"));
            myDepots[1].vehicles[1].AddHistory(new History(new DateTime(2012, 03, 26), "Valet", "Fully Valeted"));

            myDepots[2].AddDriver(new Driver("E", "5"));
            myDepots[2].AddDriver(new Manager("F", "6"));

        }

        public void LocateDepot()
        {
            do
            {
                Console.WriteLine("Depots");
                Console.WriteLine("");

                for (int index = 0; index < myDepots.Count; index++)
                {
                    Console.WriteLine((index + 1).ToString() + " : " + myDepots[index].GetDepotName());
                }
                Console.WriteLine("\nInput (E) to exit application");
                Console.Write("\nSelect Depot(Number) : ");
                string input = Console.ReadLine();

                if (input == "E")
                {
                    Environment.Exit(0);
                }

                if (!int.TryParse(input, out userChoice) || (userChoice <= 0) || (userChoice >= 4))
                {
                    Console.Write("\n{0} is not a valid choice.Try again...", input);
                    Console.ReadLine();
                }

                if ((userChoice > 0) && (userChoice < 4))
                {
                    Console.Clear();
                    myDepots[userChoice - 1].LogOn();
                    MenuOptions();
                }

                Console.Clear();

            } while (true);
        }

        private void MenuOptions()
        {
            Console.Clear();
            string userOption;

            do
            {
                Console.WriteLine("Option Menu\n");

                Console.WriteLine("1 - VIEW WORK SCHEDULE");
                if (myDepots[userChoice - 1].IsManager(myDepots[userChoice - 1].GetLoginName()) == true)
                {
                    Console.WriteLine("2 - ASSIGN WORK SCHEDULE");
                    Console.WriteLine("3 - MOVE VEHICLE");
                    Console.WriteLine("4 - VIEW VEHICLE HISTORY");
                    Console.WriteLine("5 - ADD VEHICLE HISTORY");
                }
                Console.WriteLine("6 - LOG OUT");

                Console.Write("\nChoice (Number): ");

                // Retrieve the user's choice
                userOption = Console.ReadLine();

                // Make a decision based on the user's choice
                switch (userOption)
                {
                    case VIEW_WORK_SCHEDULE:
                        myDepots[userChoice - 1].ViewWorkSchedule();
                        Console.Write("\nPress (Enter) to go back to menu...");
                        Console.ReadLine();
                        break;
                    case ASSIGN_WORK_SCHEDULE:
                        if (myDepots[userChoice - 1].IsManager(myDepots[userChoice - 1].GetLoginName()) == true)
                        {
                            myDepots[userChoice - 1].SetUpWorkSchedule();
                        }
                        break;
                    case MOVE_VEHICLE:
                        if (myDepots[userChoice - 1].IsManager(myDepots[userChoice - 1].GetLoginName()) == true)
                        {
                            MoveVehicle();
                            Console.Write("\nPress (Enter) to go back to menu...");
                            Console.ReadLine();
                        }
                        break;
                    case VIEW_VEHICLE_HISTORY:
                        if (myDepots[userChoice - 1].IsManager(myDepots[userChoice - 1].GetLoginName()) == true)
                        {
                            myDepots[userChoice - 1].ViewVehicleHistory();
                        }
                        break;
                    case ADD_VEHICLE_HISTORY:
                        if (myDepots[userChoice - 1].IsManager(myDepots[userChoice - 1].GetLoginName()) == true)
                        {
                            myDepots[userChoice - 1].ViewVehicleHistory();
                        }
                        break;
                    case LOGOUT:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("{0} is not a valid choice", userOption);
                        break;
                }
                Console.Clear();
            } while (userOption != "6"); // Keep going until the user wants to quit
        }

        public void MoveVehicle()
        {
            Console.Clear();
            Console.WriteLine("Move Vehicle");
            string confirmVehicleMove;
            do
            {
                if (myDepots[userChoice - 1].vehicles.Count() == 0) 
                {
                    Console.WriteLine("\nNo Vehicles To Move");
                    break;
                }
                SelectVehicleToMoveToDepot();
                SelectDepotToMoveVehicle();

                Vehicle MoveVehicle = myDepots[userChoice - 1].RemoveVehicle(myDepots[userChoice - 1].vehicles[vehicleChoice - 1].GetVehiclesRegNo());

                if (MoveVehicle != null)
                {
                    myDepots[depotChoice - 1].AddVehicle(MoveVehicle);
                }

                Console.Write("Confirm Vehicle Move: ");
                confirmVehicleMove = Console.ReadLine();

            } while (confirmVehicleMove != "4");
        }

        public void SelectDepotToMoveVehicle() 
        {
            string depotInput;
            bool CheckDepot = false;
            Console.WriteLine("\nSelect depot to move the " + myDepots[userChoice - 1].vehicles[vehicleChoice-1].GetVehiclesMake() + " vehicle");
            Console.WriteLine("");
            for (int index = 0; index < myDepots.Count; index++)
            {
                if (myDepots[index].GetDepotName() != myDepots[userChoice - 1].GetDepotName())
                {
                    Console.WriteLine((index + 1).ToString() + " : " + myDepots[index].GetDepotName());
                }
            }
            do
            {
                Console.Write("\nSelect Depot(Number) : ");
                depotInput = Console.ReadLine();

                if (myDepots[userChoice - 1].GetDepotName() == "Liverpool")
                {

                    if (!int.TryParse(depotInput, out depotChoice) || depotChoice > 3 || depotChoice < 2)
                    {
                        Console.Write("\n{0} is not a valid choice.Try again...", depotInput);
                        Console.ReadLine();
                    }
                    else
                        CheckDepot = true;
                }

                else if (myDepots[userChoice - 1].GetDepotName() == "Manchester")
                {

                    if (!int.TryParse(depotInput, out depotChoice) || depotChoice > 3 || depotChoice < 1 || depotChoice == 2)
                    {
                        Console.Write("\n{0} is not a valid choice.Try again...", depotInput);
                        Console.ReadLine();
                    }
                    else
                        CheckDepot = true;
                }

                else if (myDepots[userChoice - 1].GetDepotName() == "Warrington")
                {

                    if (!int.TryParse(depotInput, out depotChoice) || depotChoice > 3 || depotChoice < 0 || depotChoice == 3)
                    {
                        Console.Write("\n{0} is not a valid choice.Try again...", depotInput);
                        Console.ReadLine();
                    }
                    else
                        CheckDepot = true;
                }
            } while (!int.TryParse(depotInput, out depotChoice) || !CheckDepot);
        }

        public void SelectVehicleToMoveToDepot() 
        {
            string vehicleInput;
            
            Console.WriteLine("\nInput| Vehcile |Vehicle| Cargo  | Vehicle |Vehicle|   Cargo   | Liquid |Liquid");
            Console.WriteLine("     |   Make  | Model | Weight |  RegNo  |  Type | Capacity  |Capacity| Type ");
            Console.WriteLine("");

            for (int index = 0; index < myDepots[userChoice - 1].vehicles.Count; index++)
            {
                
                Console.WriteLine("  " + (index + 1).ToString() 
                    + "\t" + myDepots[userChoice - 1].vehicles[index].GetVehiclesMake()
                    + "\t"  + " " + myDepots[userChoice - 1].vehicles[index].GetVehiclesModel()
                    + "\t"  + "   " + myDepots[userChoice - 1].vehicles[index].GetVehiclesWeight()
                    + "\t"  + "  " + myDepots[userChoice - 1].vehicles[index].GetVehiclesRegNo()
                    +  "  " + myDepots[userChoice - 1].vehicles[index].GetType().Name
                    + "\t" +  "  " + myDepots[userChoice - 1].vehicles[index].GetCargoCapacity()
                    + "\t" +  "  " + myDepots[userChoice - 1].vehicles[index].GetLiquidCapacity()
                    + "\t" +   "  "  + myDepots[userChoice - 1].vehicles[index].GetLiquidType()
                    );
            }
            do{
            Console.Write("\nSelect Vehicle(Number): ");
            vehicleInput = Console.ReadLine();

            if (!int.TryParse(vehicleInput, out vehicleChoice) || vehicleChoice < 1 || vehicleChoice > myDepots[userChoice - 1].vehicles.Count)
            {
                Console.Write("\n{0} is not a valid choice.Try again...", vehicleInput);
                Console.ReadLine();
            }
            } while (!int.TryParse(vehicleInput, out vehicleChoice) || vehicleChoice < 1 || vehicleChoice > myDepots[userChoice - 1].vehicles.Count);
        }
    }
}

