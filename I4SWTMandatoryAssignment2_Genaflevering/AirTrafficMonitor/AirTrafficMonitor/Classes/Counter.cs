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

        public int TrackCounter
        {
            get { return _trackCounter; }
            set { _trackCounter = value; }
        }

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
    }
}
