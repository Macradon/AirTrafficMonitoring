using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iDecrypting
    {
        Track decryptData(string data);
        event EventHandler<TracksChangedEventArgs> TracksChanged;
    }

    public class TracksChangedEventArgs : EventArgs
    {
        public List<Track> Tracks { get; set; }

        public TracksChangedEventArgs(List<Track> tracks)
        {
            Tracks = tracks;
        }
    }
}
