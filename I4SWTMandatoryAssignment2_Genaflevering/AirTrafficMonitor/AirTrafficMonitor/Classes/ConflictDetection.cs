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

        public bool checkConflict(Track track1, Track track2)
        {
            {
                if (Math.Sqrt(Math.Pow((track1.Xcoor - track2.Xcoor), 2) + Math.Pow((track1.Ycoor - track2.Ycoor), 2)) < 5000 &&
                    (Math.Abs(track1.Altitude - track2.Altitude) < 300) && track1 != track2)
                    return true;
                else
                    return false;

            }
        }
    }
}
