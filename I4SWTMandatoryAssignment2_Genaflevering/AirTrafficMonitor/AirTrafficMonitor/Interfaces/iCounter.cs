using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iCounter
    {

        public void addTrack();
        public void subtractTrack();
        public int getTracks();
    }
}
