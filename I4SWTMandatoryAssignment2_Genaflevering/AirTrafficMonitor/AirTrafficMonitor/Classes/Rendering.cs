using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class Rendering
    {
        iConflictDetection ConflictDetect = new ConflictDetection();

        public void printTrack(Track track)
        {
            
           Console.WriteLine("Tag: " + track.Tag + ", X: " + track.Xcoor + ", Y: " + track.Ycoor + ", Altitude: " + track.Altitude + ", Velocity: " + track.Velocity + ", Course: " + track.Compass);
        }

        public void printConflict(Track track1, Track track2)
        {
            Console.WriteLine("Conflict between " + track1.Tag + " & " + track2.Tag +
                        "   " + condition[set].TimeStamp.Day + "/" + condition[set].TimeStamp.Month + "-" + condition[set].TimeStamp.Year +
                        " " + condition[set].TimeStamp.Hour + ":" + condition[set].TimeStamp.Minute + ":" + condition[set].TimeStamp.Second +
                        "." + condition[set].TimeStamp.Millisecond);
        }
    }
}
