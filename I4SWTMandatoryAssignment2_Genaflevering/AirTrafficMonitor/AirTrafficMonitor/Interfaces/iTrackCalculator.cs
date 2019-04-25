using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iTrackCalculator
    {
        double calculateVelocity(Track trackBefore, Track trackNow);
        double calculateCompass(Track centerPos, Track trackPos);
    }
}
