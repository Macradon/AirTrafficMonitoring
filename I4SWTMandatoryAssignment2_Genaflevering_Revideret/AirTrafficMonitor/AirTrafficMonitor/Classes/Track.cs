using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class Track : iTrack
    {
        //attributes
        private string _tag;
        private int _x;
        private int _y;
        private int _alt;
        private double _velocity;
        private double _compass;
        private DateTime _timestamp;

        //Properties R/W
        public string Tag { get; set; }
        public int Xcoor { get; set; }
        public int Ycoor { get; set; }
        public int Altitude { get; set; }
        public double Velocity { get; set; }
        public double Compass { get; set; }
        public DateTime TimeStamp { get; set; }

        //Contstructor init

        public Track()
        {
            _tag = "";
            _x = 0;
            _y = 0;
            _alt = 0;
            _velocity = 0;
            _compass = 0;
            _timestamp = DateTime.Now;
        }
    }
}
