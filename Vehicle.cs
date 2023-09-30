using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Vehicle
    {
        public string type { get; set; }
        public string model { get; set; }
        public string license_plate { get; set; }

        public Vehicle()
        {
            type = "";
            model = "";
            license_plate = "";
        }
        public Vehicle(string typ, string mod, string lplate)
        {
            type = typ;
            model = mod;
            license_plate = lplate;
        }
    }
}
