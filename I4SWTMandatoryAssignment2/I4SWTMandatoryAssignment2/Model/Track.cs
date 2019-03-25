using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4SWTMandatoryAssignment2.Model
{
    public class Track : iTrack
    {
        //attributes
        private string _tag;
        private int _x;
        private int _y;
        private int _alt;
        private int _velocity;
        private int _compass;
        private DateTime _timestamp;

        //Properties R/W
        public string Tag { get; set; }
        public int Xcoor { get; set; }
        public int Ycoor { get; set; }
        public int Altitude { get; set; }
        public int Velocity { get; set; }
        public int Compass { get; set; }
        public DateTime TimeStamp { get; set; }

        //Contstructor init

        public Track()
        {

        }

        public Track(string tag, int xcoor, int ycoor, int altitude, DateTime timestamp)
        {
            _tag = tag;
            _x = xcoor;
            _y = ycoor;
            _alt = altitude;
            _velocity = Velocity;
            _compass = Compass;
            _timestamp = timestamp;
        }

        //Formater function
        public override string ToString()
        {
            String.Format("Tag: {0} \r\n" +
                          "XY-Pos: {1} \r\n" +
                          "Altitude: {2} \r\n" +
                          "Velocity: {3} \r\n" +
                          "Compass Course: {4}",
                          _tag, _x, _y, _alt, _compass);

            return base.ToString();
        }

    }
}
