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
    class Decrypting: iDecrypting
    {
        //attributes
        private string _tag;
        private int _x;
        private int _y;
        private int _alt;
        private double _velocity;
        private double _compass;
        private DateTime _timestamp;

        public string Tag { get; set; }
        public int Xcoor { get; set; }
        public int Ycoor { get; set; }
        public int Altitude { get; set; }
        public double Velocity { get; set; }
        public double Compass { get; set; }
        public DateTime TimeStamp { get; set; }

        public Decrypting()
        {

        }

        public void decryptData(string data)
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
        }


    }
}
