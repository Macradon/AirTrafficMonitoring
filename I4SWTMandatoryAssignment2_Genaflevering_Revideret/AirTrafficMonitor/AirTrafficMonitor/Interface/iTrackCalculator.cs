using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public interface iTrackCalculator
    {
        void calculateVelocity(Track trackBefore, Track trackNow);
        void calculateCompass(Track centerPos, Track trackPos);
        event EventHandler<NewTracksEventArgs> CalculatedTracks;
    }

    public class CorrectTracksEventArgs : EventArgs
    {
        public List<Track> AirspacedTracks { get; set; }

        public CorrectTracksEventArgs(List<Track> correctTracks)
        {
            AirspacedTracks = correctTracks;
        }
    }
}
