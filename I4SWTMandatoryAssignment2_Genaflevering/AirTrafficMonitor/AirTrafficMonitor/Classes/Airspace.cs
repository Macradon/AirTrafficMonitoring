using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    class Airspace : iAirspace
    {
        iTrackCalculator TrackCalc = new iTrackCalculator();
        iCounter counter = new iCounter();
    }
}
