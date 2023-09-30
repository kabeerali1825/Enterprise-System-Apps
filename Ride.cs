using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Ride
    {
        public Location start_location { get; set; }
        public Location endLocation { get; set; }
        public int price { get; private set; }
        public Driver driver { get; private set; }
        public Passenger passenger { get; private set; }

        public Ride()
        {
            start_location = new Location();
            endLocation = new Location();
            price = 0;
            driver = new Driver();
            passenger = new Passenger();
        }
        public Ride(Location startLocation, Location endLocation, int price, Driver driver, Passenger passenger)
        {
            this.start_location = startLocation;
            this.endLocation = endLocation;
            this.price = price;
            this.driver = driver;
            this.passenger = passenger;
        }

        // You will ask for the passenger object and set it to the passenger object
        public void assignPassenger(Passenger p)
        {
            this.passenger = p;
        }

        public void assignDriver(Admin obj)
        {
            Driver DrivernearMe = new Driver();
            DrivernearMe = null;
            double minDistance = double.MaxValue;
            for (int i = 0; i < obj.drivers.Count; i++)
            {
                if (driver.availability)
                {
                    double distance = driver.currLocation.CloserDriverDistanceTo(this.start_location);
                    if (distance < minDistance)
                    {
                        DrivernearMe = driver;
                        minDistance = distance;
                    }
                }
            }


            if (DrivernearMe != null)
            {
                this.driver = DrivernearMe;
                //Driver start working Now
                DrivernearMe.availability = false;
                Console.WriteLine($"Assigned driver {DrivernearMe.name} to the ride.");
            }
            else
            {
                Console.WriteLine("No available driver found for the ride.");
            }

        }

        //public void getLocations()
        //{
        //    Console.Write("\t\tEnter start location coordinates of thee (latitude, longitude): ");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    float startLatitude = float.Parse(Console.ReadLine());
        //    float startLongitude = float.Parse(Console.ReadLine());
        //    Console.ForegroundColor = ConsoleColor.Black;
        //    this.start_location = new Location(startLatitude, startLongitude);

        //    Console.Write("\t\tEnter end location coordinates of thee (latitude, longitude): ");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    float endLatitude = float.Parse(Console.ReadLine());
        //    float endLongitude = float.Parse(Console.ReadLine());
        //    Console.ForegroundColor = ConsoleColor.Black;
        //    this.endLocation = new Location(endLatitude, endLongitude);
        //}
        public void getLocations()
        {
            Console.Write("\t\tEnter Start Location Coordinates (latitude, longitude): ");
            Console.ForegroundColor = ConsoleColor.Green;
            string startLocationInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;

            // Split the user input using ',' as the separator
            string[] startLocationParts = startLocationInput.Split(',');

            if (startLocationParts.Length == 2)
            {
                if (float.TryParse(startLocationParts[0], out float startLatitude) && float.TryParse(startLocationParts[1], out float startLongitude))
                {
                    this.start_location = new Location(startLatitude, startLongitude);
                }
                else
                {
                    Console.WriteLine("\t\tInvalid input. Please Enter valid Latitude and Longitude values.");
                    return; // Exit the method as the input was invalid.
                }
            }
            else
            {
                Console.WriteLine("\t\tInvalid input format. Please enter latitude and longitude separated by a comma.");
                return; // Exit the method as the input format was invalid.
            }

            Console.Write("\t\tEnter end location coordinates (latitude, longitude): ");
            Console.ForegroundColor = ConsoleColor.Green;
            string endLocationInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;


            string[] endLocationParts = endLocationInput.Split(',');

            if (endLocationParts.Length == 2)
            {
                if (float.TryParse(endLocationParts[0], out float endLatitude) && float.TryParse(endLocationParts[1], out float endLongitude))
                {
                    this.endLocation = new Location(endLatitude, endLongitude);
                }
                else
                {
                    Console.WriteLine("\t\tInvalid input. Please enter valid latitude and longitude values.");
                }
            }
            else
            {
                Console.WriteLine("\t\tInvalid input format. Please enter latitude and longitude separated by a comma.");
            }
        }

        public void calculatePrice(Vehicle veh)
        {
            float fuelPrice = 275.3F;
            //  km values avergae.
            int fuelAverage = 0;
            float commissionRate = 0.00F;
            float distance = this.start_location.CloserDriverDistanceTo(this.endLocation);
            if (veh.type == "Bike")
            {
                fuelAverage = 50;
                commissionRate = 0.05F;
            }
            else if (veh.type == "Rickshaw")
            {
                fuelAverage = 35;
                commissionRate = 0.1F;
            }
            else if (veh.type == "Car")
            {
                fuelAverage = 15;
                commissionRate = 0.2F;
            }
            float compnayCommission = distance * commissionRate;
            this.price = (int)Math.Round((distance * fuelPrice) / fuelAverage + compnayCommission);
            Console.WriteLine($"\t\tPrice Of The Ride is: {this.price} pkr only");

        }

        public void giveRating()
        {
            Console.Write("\n\t\tHey Dear ! How was the ride? Rate the driver from 1 to 5 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            int driverNewRating = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Black;

            if (driverNewRating >= 1 && driverNewRating <= 5)
            {
                driver.rating.Add(driverNewRating);
            }
            else
            {
                Console.WriteLine("Invalid Rating! Please Enter Again in (1-5)!");

                giveRating();
            }
        }


    }
}
