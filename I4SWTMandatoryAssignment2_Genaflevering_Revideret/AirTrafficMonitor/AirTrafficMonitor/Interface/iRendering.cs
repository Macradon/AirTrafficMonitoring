using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface IRendering
    {

    }

    public class CalculatedTracksEventArgs : EventArgs
    {
        public List<Track> CalculatedTracks { get; set; }

        public CalculatedTracksEventArgs(List<Track> tracksCalculated)
        {
            CalculatedTracks = tracksCalculated;
        }
    }
}
