using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirTrafficMonitor
{
    public class Airspace : iAirspace
    {
        public int swCornerX { get; set; }
        public int swCornerY { get; set; }
        public int neCornerX { get; set; }
        public int neCornerY { get; set; }
        public int minAlt { get; set; }
        public int maxAlt { get; set; }

        public event EventHandler<DecryptedTracksEventArgs> TracksDecrypted;
        public List<Track> DecryptedTracks;


        public Airspace(iDecrypting decrypting)
        {
            swCornerX = 5000;
            swCornerY = 5000;

            neCornerX = 85000;
            neCornerY = 85000;

            minAlt = 500;
            maxAlt = 20000;

            DecryptedTracks = new List<Track>();
            decrypting.UpdatedTracks += InsideAirspace;
        }

        public void InsideAirspace(object sender, NewTracksEventArgs e)
        {
            foreach (var tracks in e.Tracks)
            {
                if (checkAirspace(tracks))
                {
                    DecryptedTracks.Add(tracks);
                }
            }
            var handler = TracksDecrypted;
            handler?.Invoke(this, new DecryptedTracksEventArgs(DecryptedTracks));
        }

        //Undersøger om tracken er i Airspace
        public bool checkAirspace(Track track)
        {
            if (track.Xcoor >= swCornerX && track.Xcoor <= neCornerX &&
                track.Ycoor >= swCornerY && track.Ycoor <= neCornerY &&
                track.Altitude >= minAlt && track.Altitude <= maxAlt)
                return true;
            else
                return false;
        }
    }
}
