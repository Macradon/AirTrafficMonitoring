using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iTrackCalculator
    {
        double calculateVelocity(int formerX, int formerY, int newX, int newY);
        double calculateCompass(int trackX, int trackY);
    }
}
