using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iConflictDetection
    {
        bool checkConflict(Track track1, Track track2);
    }
}
