using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class Airspace : iAirspace
    {
        Counter counter = new Counter();
        Rendering rendering = new Rendering();
        ConflictDetection conflict = new ConflictDetection();

        public int swCornerX { get; set; }
        public int swCornerY { get; set; }
        public int neCornerX { get; set; }
        public int neCornerY { get; set; }
        public int minAlt { get; set; }
        public int maxAlt { get; set; }

        

        public Airspace()
        {
            swCornerX = 5000;
            swCornerY = 5000;

            neCornerX = 85000;
            neCornerY = 85000;

            minAlt = 500;
            maxAlt = 20000;
        }

        static Track[] arr = new Track[30];
        public void checkPosition(Track track)
        {
            if (track.Xcoor >= swCornerX && track.Xcoor <= neCornerX &&
                track.Ycoor >= swCornerY && track.Ycoor <= neCornerY &&
                track.Altitude >= minAlt && track.Altitude <= maxAlt)
            {
                arr[counter.TrackCounter] = track;
                rendering.printTrack(arr[counter.TrackCounter]);
                counter.addTrack();

                if (counter.TrackCounter >= 2)
                {
                    for (int i = 0; i < counter.TrackCounter; i++)
                    {
                        conflict.checkConflict(arr[counter.TrackCounter], arr[i]);
                    }
                }
                
            }
            else
            {

            }
        }
    }
}
