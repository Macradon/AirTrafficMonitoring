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
        event EventHandler<NewTracksEventArgs> newTracks;
    }

    public class NewTracksEventArgs : EventArgs
    {
        public List<Track> Tracks { get; set; }

        public NewTracksEventArgs(List<Track> updatedTracks)
        {
            Tracks = updatedTracks;
        }
    }
}
