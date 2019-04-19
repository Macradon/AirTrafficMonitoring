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

        }
    }
}
