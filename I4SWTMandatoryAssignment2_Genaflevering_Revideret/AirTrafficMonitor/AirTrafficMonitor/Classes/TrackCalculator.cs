using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    class TrackCalculator : iTrackCalculator
    {
        public TrackCalculator()
        {

        }

        public double CalculateVelocity(Track oldTrack, Track newTrack)
        {
            double time = newTrack.TimeStamp.Subtract(oldTrack.TimeStamp).TotalSeconds;
            double distance = Math.Sqrt(Math.Pow(newTrack.Xcoor - oldTrack.Xcoor, 2) + Math.Pow(newTrack.Ycoor - oldTrack.Ycoor, 2));
            double velocity = distance/time;

            return velocity;
        }
    }
}
