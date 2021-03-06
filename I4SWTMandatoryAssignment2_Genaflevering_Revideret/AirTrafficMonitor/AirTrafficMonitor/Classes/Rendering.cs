﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor;

namespace AirTrafficMonitor
{
    public class Rendering : IRendering
    {
        public event EventHandler<CalculatedTracksEventArgs> TracksCalculated;
        public List<Track> CalculatedTracks;

        public Rendering(iTrackCalculator calculator)
        {
            CalculatedTracks = new List<Track>();
            calculator.CalculatedTracks += OnCalculatedTracks;
        }

        public void OnCalculatedTracks(object sender, CorrectTracksEventArgs e)
        {
            foreach (var data in e.AirspacedTracks)
            {
                printTrack(data);
            }
        }

        public void printConflict(string Tag1, string Tag2, DateTime Time)
        {
            Console.WriteLine("Conflict between " + Tag1 + " & " + Tag2 + "   " +
                              Time.Day + "/" + Time.Month + "-" + Time.Year + " " +
                              Time.Hour + ":" + Time.Minute + ":" + Time.Second + "." + Time.Millisecond);
        }

        public void printTrack(Track track)
        {

            Console.WriteLine("Tag : " + track.Tag + ", X : " + track.Xcoor + ", Y : " + track.Ycoor + ", Altitude: " + track.Altitude + ", Velocity: " + track.Velocity + ", Course: " + track.Compass);
        }

        
    }
}