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
        public bool checkConflict(Track track1, Track track2)
        {
            if (Math.Sqrt((Math.Pow((track1.Xcoor - track2.Xcoor), 2) + (Math.Pow((track1.Ycoor - track2.Ycoor), 2)))) < 5000 &&
                          (Math.Abs(track1.Altitude - track2.Altitude) < 300))
                return true;
            else
                return false;
            
        }

    }
}
