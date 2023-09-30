using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Driver
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        // A primary attribute id is defined for the Driver's Opertaions
        public int id { get; set; }   
        

        public Location currLocation;
        //The vehicle used by the driver
        public Vehicle vehicle;

        //The list of rating to driver, based on passengers’ feedback 
        public List<int> rating;

        public bool availability;

        // Default Constructor.
        public Driver()  
        {
            name = "";
            age = 0;
            gender = "";
            address = "";
            id = 0;
            phoneNumber = "";
            rating = new List<int>();
            vehicle = new Vehicle();
            currLocation = new Location();
            //Currently Set availability of Driver for ride
            availability = false;

        }
        //Paramertarized Constructor
        public Driver(int id, string name, int age, string gender, string address, string phoneNumber, Location currLocation, Vehicle vehicle, bool availibility)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.currLocation = currLocation;
            this.id = id;
            this.vehicle= vehicle;
            this.address = address;
            rating = new List<int>();
            this.availability = true;
        }


        //Functions
        public void updateAvailibility(bool status)
        {
            availability = status;
        }

        public double getRating()
        {
            if (rating.Count == 0)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                foreach (int rating in rating)
                {
                    sum += rating;
                }
                return sum / rating.Count;
            }
        }
        public void updateLocation(Location newLocation)
        {
            currLocation = newLocation;
        }

    }
}
