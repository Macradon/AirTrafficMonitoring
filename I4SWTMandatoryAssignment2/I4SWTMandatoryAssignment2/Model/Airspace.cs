using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace I4SWTMandatoryAssignment2.Model
{
    public class Airspace
    {
        public int swCornerX { get; set; }
        public int swCornerY { get; set; }
        public int neCornerX { get; set; }
        public int neCornery { get; set; }
        public int minAlt { get; set; }
        public int maxAlt { get; set; }

        public Airspace()
        {

            swCornerX = 0;
            swCornerY = 0;

            neCornerX = 80000;
            neCornery = 80000;

            minAlt = 500;
            maxAlt = 20000;

        }

        public bool positionTrack(Track track)
        {
            if (track.Xcoor >= swCornerX && track.Xcoor <= neCornerX &&
                track.Ycoor >= swCornerY && track.Ycoor <= neCornery &&
                track.Altitude >= minAlt && track.Altitude <= maxAlt)
                return true;
            else
                return false;
   
        }
    }
}
