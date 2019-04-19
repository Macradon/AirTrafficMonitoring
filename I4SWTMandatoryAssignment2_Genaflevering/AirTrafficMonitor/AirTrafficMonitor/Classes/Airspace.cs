using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class Airspace : iAirspace
    {
        public int swCornerX { get; set; }
        public int swCornerY { get; set; }
        public int neCornerX { get; set; }
        public int neCornerY { get; set; }
        public int minAlt { get; set; }
        public int maxAlt { get; set; }

        iCounter counter = new Counter();

        public Airspace()
        {
            swCornerX = 5000;
            swCornerY = 5000;

            neCornerX = 85000;
            neCornerY = 85000;

            minAlt = 500;
            maxAlt = 20000;
        }

        public bool checkPosition(Track track)
        {
            if (track.Xcoor >= swCornerX && track.Xcoor <= neCornerX &&
                track.Ycoor >= swCornerY && track.Ycoor <= neCornerY &&
                track.Altitude >= minAlt && track.Altitude <= maxAlt)
            {
                counter.addTrack();
                return true;
            }
            else
                return false;
        }
    }
}
