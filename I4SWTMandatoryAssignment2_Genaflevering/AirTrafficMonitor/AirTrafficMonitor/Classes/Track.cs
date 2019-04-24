﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class Track: iTrack
    {
        TrackCalculator trackCalculator = new TrackCalculator();
        Airspace airspace = new Airspace();
        //attributes
        private string _tag;
        private int _x;
        private int _y;
        private int _alt;
        private double _velocity;
        private double _compass;
        private DateTime _timestamp;
        private int formerX;
        private int formerY;

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

        public Track()
        {
            
        }

        public Track(string tag, int xcoor, int ycoor, int altitude, DateTime timestamp)
        {
            formerX = _x;
            formerY = _y;
            _tag = tag;
            _x = xcoor;
            _y = ycoor;
            _alt = altitude;
            _timestamp = timestamp;

            trackCalculator.calculateVelocity(formerX, formerY, this);
            trackCalculator.calculateCompass(airspace.neCornerX - airspace.swCornerX, airspace.neCornerY - airspace.swCornerY, this);

            airspace.checkPosition(this);
        }
    }
}
