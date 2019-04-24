using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iTrackCalculator
    {
        void calculateVelocity(int formerX, int formerY, Track track);
        void calculateCompass(Track track);
    }
}
