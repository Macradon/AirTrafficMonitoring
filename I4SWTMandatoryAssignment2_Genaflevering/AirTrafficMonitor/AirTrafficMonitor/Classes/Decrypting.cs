﻿using System;
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
        private TransponderReceiverClient _myTrack;
        

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
            TransponderReceiverClient myCalc = new TransponderReceiverClient();
            myCalc.OnKnowAnswer += new KnowAnswer(myCalc_OnKnowAnswer);
        }

        private void myCalc_OnKnowAnswer(object sender, AnswerEventArgs e)
        {
            //decryptData(e);
            Console.WriteLine("Sup");
        }

        public void decryptData(List<string> data)
        {
            var aggData = String.Join("",data.ToArray());

            Console.WriteLine("fuck");
            CultureInfo provider = CultureInfo.InvariantCulture;

            string[] splitter = new string[5];
            splitter = aggData.Split(';');
            int i = 0;

            string test = string.Join(" ", data);

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

            _tag = aggData.Substring(tagPos, tagLen);
            _x = Int32.Parse(aggData.Substring(xPos, xLen));
            _y = Int32.Parse(aggData.Substring(yPos, yLen));
            _alt = Int32.Parse(aggData.Substring(altPos, altLen));
            _timestamp = DateTime.ParseExact(aggData.Substring(timePos, timeLen), "yyyyMMddHHmmssfff", provider);

            Track track = new Track(_tag, _x, _y, _alt, _timestamp);
    }


    }
}
