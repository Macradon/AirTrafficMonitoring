using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4SWTMandatoryAssignment2.Model
{
    public class Counter : iCounter
    {
        private int _trackCounter;

        public int TrackCounter { get; set; }

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
