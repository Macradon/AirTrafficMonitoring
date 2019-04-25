using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public interface iDecrypting
    {
        Track decryptData(string trackData);
        event EventHandler<NewTracksEventArgs> UpdatedTracks;
    }

    public class NewTracksEventArgs : EventArgs
    {
        public List<Track> Tracks { get; set; }

        public NewTracksEventArgs(List<Track> newTracks)
        {
            Tracks = newTracks;
        }
    }
}
