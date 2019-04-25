using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public interface iAirspace
    {
        bool checkAirspace(Track track);
        event EventHandler<DecryptedTracksEventArgs> TracksDecrypted;
    }

    public class DecryptedTracksEventArgs : EventArgs
    {
        public List<Track> DecryptedTracks { get; set; }

        public DecryptedTracksEventArgs(List<Track> tracksDecrypted)
        {
            DecryptedTracks = tracksDecrypted;
        }
    }
}

