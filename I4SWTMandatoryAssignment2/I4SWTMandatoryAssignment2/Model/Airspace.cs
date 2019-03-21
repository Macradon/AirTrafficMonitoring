using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace I4SWTMandatoryAssignment2.Model
{
    public class Airspace
    {
        public int rrCornerX {get; set;}
        public int rrCornerY { get; set; }
        public int llCornerX { get; set; }
        public int llCornery { get; set; }
        public int minAlt { get; set; }
        public int maxAlt { get; set; }

        public Airspace()
        {

            llCornerX = 0;
            llCornery = 0;

            rrCornerX = 80000;
            rrCornerY = 80000;

            minAlt = 500;
            maxAlt = 20000;



        

        }

    }
}
