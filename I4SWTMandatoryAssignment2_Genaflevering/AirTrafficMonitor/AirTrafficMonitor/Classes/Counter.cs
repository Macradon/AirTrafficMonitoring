using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class Counter : iCounter
    {
        private int _trackCounter;

        public int TrackCounter { get; set; }

        public Counter()
        {
            _trackCounter = 0;
        }

        public void addTrack()
        {
            _trackCounter++;
        }

        public void subtractTrack()
        {
            if (_trackCounter > 0)
            {
                _trackCounter--;
            }
        }

        public int getTracks()
        {
            return _trackCounter;
        }
    }
}
