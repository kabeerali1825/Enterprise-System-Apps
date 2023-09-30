using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }

        public Location()
        {
            latitude = 0.0F;
            longitude = 0.0F;
        }

        public Location(float latitud, float lognitude)
        {
            latitude = latitud;
            longitude = lognitude;
        }

        public void setLocation(float latitud, float log)
        {
            latitude = latitud;
            longitude = log;
        }


        // Find the Closeset Driver Using difference Euclidean distance formula
        public float CloserDriverDistanceTo(Location other) 
        {
            float latitudeDiff = latitude - other.latitude;
            float longitudeDiff = longitude - other.longitude;
            return (float)Math.Sqrt(latitudeDiff * latitudeDiff + longitudeDiff * longitudeDiff);
        }
    }
}
