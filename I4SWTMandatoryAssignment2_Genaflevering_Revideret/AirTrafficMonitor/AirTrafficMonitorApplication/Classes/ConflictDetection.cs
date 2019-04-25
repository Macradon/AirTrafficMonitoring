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
        Logger log = new Logger();
        Rendering render = new Rendering();

        public ConflictDetection()
        {

        }

        public void checkConflict(Track track1, Track track2)
        {
            {
                if (Math.Sqrt(Math.Pow((track1.Xcoor - track2.Xcoor), 2) + Math.Pow((track1.Ycoor - track2.Ycoor), 2)) < 5000 &&
                    (Math.Abs(track1.Altitude - track2.Altitude) < 300) && track1 != track2)
                {
                    log.printToLog(track1.Tag, track2.Tag, track1.TimeStamp);
                    render.printConflict(track1.Tag, track2.Tag, track1.TimeStamp);

                }
                else
                {
                }


            }
        }
    }
}