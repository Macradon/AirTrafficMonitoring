using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;
using TransponderReceiver;
using System.Globalization;  //Used for DateTime

namespace AirTrafficMonitor
{
    public class Decrypting: iDecrypting
    {
        
        //attributes
        private string _tag;
        private int _x;
        private int _y;
        private int _alt;
        private double _velocity;
        private double _compass;
        private DateTime _timestamp;

        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public int Xcoor
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Ycoor
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Altitude
        {
            get { return _alt; }
            set { _alt = value; }
        }

        public DateTime TimeStamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        public double Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public double Compass
        {
            get { return _compass; }
            set { _compass = value; }
        }

        public Decrypting()
        {

        }

        public string decryptData(string data)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            string[] splitter = new string[5];
            splitter = data.Split(';');
            int i = 0;

            foreach (var variable in splitter)
            {
                splitter[i] = variable;
                i++;
            }

            int tagLen = splitter[0].Length;
            int xLen = splitter[1].Length;
            int yLen = splitter[2].Length;
            int altLen = splitter[3].Length;
            int timeLen = splitter[4].Length;

            int tagPos = 0;
            int xPos = tagPos + tagLen + 1;
            int yPos = xPos + xLen + 1;
            int altPos = yPos + yLen + 1;
            int timePos = altPos + altLen + 1;

            _tag = data.Substring(tagPos, tagLen);
            _x = Int32.Parse(data.Substring(xPos, xLen));
            _y = Int32.Parse(data.Substring(yPos, yLen));
            _alt = Int32.Parse(data.Substring(altPos, altLen));
            _timestamp = DateTime.ParseExact(data.Substring(timePos, timeLen), "yyyyMMddHHmmssfff", provider);

            return "";
        }


    }
}
