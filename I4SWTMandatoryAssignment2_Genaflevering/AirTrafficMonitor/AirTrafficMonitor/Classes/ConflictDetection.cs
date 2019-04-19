using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class ConflictDetection : iConflictDetection
    {
        iAirspace Airspace = new Airspace();

        public bool checkConflict(Track tag1, Track tag2)
        {
            if (Math.Sqrt(Math.Pow((tag1.Xcoor - tag2.Xcoor), 2) + Math.Pow((tag1.Ycoor - tag2.Ycoor), 2)) < 5000 &&
                (Math.Abs(tag1.Altitude - tag2.Altitude) < 300) && tag1 != tag2)
                return true;
            else
                return false;

        }
    }
}
