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

        public void printTrack(Track track)
        {
            
           Console.WriteLine("Tag: " + track.Tag + ", X: " + track.Xcoor + ", Y: " + track.Ycoor + ", Altitude: " + track.Altitude + ", Velocity: " + track.Velocity + ", Course: " + track.Compass);
        }

        public void printConflict(string tag1, string tag2, DateTime time)
        {
            Console.WriteLine("Conflict between " + tag1 + " & " + tag2 + "   " + 
                              time.Day + "/" + time.Month + "-" + time.Year + " " + 
                              time.Hour + ":" + time.Minute + ":" + time.Second + "." + time.Millisecond);
        }
    }
}
