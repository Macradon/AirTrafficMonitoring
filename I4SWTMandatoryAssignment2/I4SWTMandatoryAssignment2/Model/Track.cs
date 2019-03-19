using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4SWTMandatoryAssignment2.Model
{
    public class Track
    {
        //attributes
        private string _tag;
        private int _x;
        private int _y;
        private int _alt;
        private DateTime _timestamp;

        //Properties R/W
        public string Tag { get; set; }
        public string Xcoor { get; set; }
        public string Ycoor { get; set; }
        public string Altitude { get; set; }
        public DateTime TimeStamp { get; set; }

        //Contstructor init

        public Track(string tag, int xcoor, int ycoor, int altitude, DateTime timestamp)
        {
            _tag = tag;
            _x = xcoor;
            _y = ycoor;
            _alt = altitude;
            _timestamp = timestamp;
        }

        //Formater function
        public override string ToString()
        {
            String.Format("Tag: {0} \r\n" +
                          "X koordinater: {1} \r\n" +
                          "Y koordinater: {2} \r\n" +
                          "Altitude: {3} \r\n",
                          _tag, _x, _y, _alt);

            return base.ToString();
        }

    }
}
