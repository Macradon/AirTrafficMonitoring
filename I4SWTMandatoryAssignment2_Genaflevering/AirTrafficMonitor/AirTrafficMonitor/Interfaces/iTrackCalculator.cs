using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iTrackCalculator
    {
        void calculateVelocity(Track track1, Track track2);
        void calculateCompass(Track track1, Track track2);
    }
}
