using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Passenger
    {
        public string passengerName { get; set; }

        public string passengerphone_no { get; set; }

        //Constructors
        public Passenger()
        {
            passengerName = "";
            passengerphone_no = "";
        }
        public Passenger(string pName, string PhNo)
        {
            passengerName = pName;
            passengerphone_no = PhNo;
        }



    }
}
