using System;
using System.Text.RegularExpressions; //For Use Regex.IsMatch 
namespace Assignment_1
{
    class Program
    {
        static bool IsPhoneNumberValid(string phoneNumber)
        {
            try
            {
                // expression that matches only digits.
                string pattern = "^[0-9]+$";

                // Use Regex.IsMatch to check if the input matches the pattern.
                return Regex.IsMatch(phoneNumber, pattern);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred while validating phone number: " + ex.Message);
                return false;
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //Creating Class Objects
                Driver dri = new Driver();
                Location loc = new Location();
                Passenger pass = new Passenger();
                Ride rid = new Ride();
                Vehicle veh = new Vehicle();
                Admin adm = new Admin();
                //Bonuc Task Implementation
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;


            StartMyRide:
                Console.WriteLine("\n----------------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t*** WELCOME TO MYRIDE ***\t\t\t");
                Console.WriteLine("----------------------------------------------------------------------------------");

                Console.WriteLine("\t\t1. Book A Ride\n\t\t2. Enter As Driver\n\t\t3. Enter As Admin\n\n");
                Console.Write("\t\tPress number 1 To 3 to Select an Option: ");
                //Bonuc Task Implementation
                Console.ForegroundColor = ConsoleColor.Green;
                int option = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Black;

                //PASSENGER BLOCK
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tBOOK A RIDE\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\t\tOPTIONS As Passenger ...!\n");


                    Console.Write("\t\tEnter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    pass.passengerName = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Black;
                    //Applying Phone_No Validations
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\t\tEnter Phone Number: ");
                        pass.passengerphone_no = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;

                        if (IsPhoneNumberValid(pass.passengerphone_no))
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid phone number. Only digits are allowed.");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    rid.getLocations();

                    Console.Write("\t\tEnter Ride type (Bike, Car or Rickshaw):");
                    Console.ForegroundColor = ConsoleColor.Green;
                    veh.type = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\n\t ------------------------- THANK YOU ---------------------------\n\n");

                    rid.calculatePrice(veh);

                    Console.Write("\n\t\tEnter ‘Y/y’ if you want to Book the ride, enter ‘N/n’ if you want to cancel operation: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    char rideStatus = char.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (rideStatus == 'Y' || rideStatus == 'y')
                    {
                        Console.WriteLine("\n\t\t\t Happy Travel :)\t");
                    }
                    rid.giveRating();

                }

                //DRIVER BLOCK
                else if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tENTER AS DRIVER\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\t\t\tOPTIONS as Driver ...!\n");
                LoginOrRegister:
                    Console.Write("\t\t\t1. LOGIN as OLD DRIVER \n\t\t\t2. REGISTER as New Driver\n\t\t ");
                    Console.Write("\n\t\t\tPlease Enter Your Choice:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int logRegChoice = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (logRegChoice == 1)
                    {
                        Console.WriteLine("\n\t\t\tEnter DriverID and Drivername to LOG IN as Driver ...!\n");
                        Console.Write("\t\tEnter ID: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int driverID = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write("\t\tEnter Name: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        dri.name = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Black;

                        Driver driver = adm.drivers.Find(d => d.id == driverID);
                        if (driver == null)
                        {
                            Console.WriteLine("\n\t\tYou Are not Registered with MYRIDE Application, Please Enter 2 to make Yoirself Register!!!\n");
                            goto LoginOrRegister;
                        }
                        else
                        {
                            Console.WriteLine($"\n\t\tHello {driver.name}!\n");
                            Console.Write("\t\tEnter Your current Location's (Latitude, Longitude): ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            float currLatitude = float.Parse(Console.ReadLine());
                            float currLongitude = float.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Black;

                            driver.currLocation.setLocation(currLatitude, currLongitude);
                            Console.WriteLine("\t\tYour Current Location Set Successfully!\n");
                        DriverMenu:
                            Console.WriteLine("\t\t1. Change Your Availability\n\t\t2. Change Your Location\n\t\t3. Exit AS Driver\n\n");
                            Console.Write("\t\tEnter 1 to 3 for furthur changes: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            int driversChoice = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (driversChoice == 1)
                            {
                                Console.WriteLine("\n\t\t Updating Your Availability ...!\n");
                                Console.Write("\t\tEnter 'A' or 'a' is you are Avaiable: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                char availability = char.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Black;
                                if (availability == 'A' || availability == 'a')
                                {
                                    Console.WriteLine("\t\tHurrah!!You are Available to Pick Rides!");
                                    dri.updateAvailibility(true);
                                    goto DriverMenu;
                                }
                                else
                                {
                                    Console.WriteLine("\t\tUpps !! You Are Not Available to pick rides!");
                                    dri.updateAvailibility(false);
                                    goto DriverMenu;
                                }

                            }
                            else if (driversChoice == 2)
                            {
                                Console.WriteLine("\t\t Updating Location ..!\n");
                                Console.Write("\t\tEnter new location (Latitude, Longitude): ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                float newLatitude = float.Parse(Console.ReadLine());
                                float newLongitude = float.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Black;
                                driver.currLocation.setLocation(newLatitude, newLongitude);
                                goto DriverMenu;

                            }
                            else if (driversChoice == 3)
                            {
                                Console.WriteLine("\n\t\tExiting as Driver ..!");
                                goto StartMyRide;
                            }
                            else
                            {
                                Console.WriteLine("\t\tInvalid Choice! (Please from 1-3)");
                            }
                        }
                    }
                    else if (logRegChoice == 2)
                    {
                        Console.WriteLine("\n\t\t\tSIGN UP as New Driver ...!\n");
                        adm.addDriver();
                        goto LoginOrRegister;
                    }


                }

                //ADMIN BLOCK
                else if (option == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n\tENTER AS ADMIN\n");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\t\t\tEntering as Admin ...!\n");
                AdminBlockStart:
                    Console.WriteLine("\t\t1. Add Driver\n\t\t2. Remove Driver\n\t\t3. Update Driver\n\t\t4. Search Driver\n\t\t5. Exit as Admin\n\n");
                    Console.Write("\t\tEnter Choose Option (1 to 5) FOR ADMIN OPERATIONS:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int adminsSelection = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Black;

                    if (adminsSelection == 1)
                    {
                        Console.WriteLine("\n\t\tAdding new Driver ..!\n");
                        adm.addDriver();
                        goto AdminBlockStart;
                    }
                    else if (adminsSelection == 2)
                    {

                        Console.WriteLine("\n\t\tRemoving a Driver ..!\n");
                        Console.Write("\t\tEnter ID to Remove a Driver: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int removeID = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Black;
                        adm.removeDriver(removeID);
                        goto AdminBlockStart;
                    }
                    else if (adminsSelection == 3)
                    {
                        Console.WriteLine("\n\t\tUpdating a Driver ..!\n");
                        Console.Write("\t\tEnter ID to update a driver's detail: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int updateID = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Black;
                        adm.updateDriver(updateID);
                        goto AdminBlockStart;
                    }
                    else if (adminsSelection == 4)
                    {
                        Console.WriteLine("\n\t\tSearching a Driver ..!\n");
                        Console.Write("\t\tEnter ID to search a driver's detail: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int searchDriverID = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Black;
                        adm.searchDriver(searchDriverID);
                        goto AdminBlockStart;
                    }
                    else if (adminsSelection == 5)
                    {
                        Console.WriteLine("\n\t\tExiting as Admin ..!\n");
                        goto StartMyRide;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Option! (please Choose between (1-5)");
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An Error Occurred: " + ex.Message);
            }
        }

        
    }
    
}
