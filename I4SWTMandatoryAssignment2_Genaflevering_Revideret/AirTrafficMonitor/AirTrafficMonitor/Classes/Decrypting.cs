using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitor
{
    public class Decrypting : iDecrypting
    {
        public Decrypting()
        {

        }

        public event EventHandler<NewTracksEventArgs> newTracks

        public Decrypting(ITransponderReceiver transRec)
        {
            trackList = new List<Track>();
        }

        public Track decryptData(string data)
        {

        }
    }
}
