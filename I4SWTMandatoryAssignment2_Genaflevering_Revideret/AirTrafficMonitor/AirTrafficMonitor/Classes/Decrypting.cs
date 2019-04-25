using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Globalization;  //Used for DateTime

namespace AirTrafficMonitor
{
    public class Decrypting : iDecrypting
    {
        public Decrypting()
        {

        }

        public event EventHandler<NewTracksEventArgs> UpdatedTracks;
        private List<Track> trackList;

        public Decrypting(ITransponderReceiver transponderReceiver)
        {
            // This will store the real or the fake transponder data receiver
            trackList = new List<Track>();
            // Attach to the event of the real or the fake TDR
            transponderReceiver.TransponderDataReady += ReceiverOnDataReady;

            Console.Write("Decrypt Test\n");
        }

        public void ReceiverOnDataReady(object sender, RawTransponderDataEventArgs e)
        {
            Console.Clear();
            trackList.Clear();
            foreach (var data in e.TransponderData)
            {
                Console.WriteLine($"Transponderdata {data}");
                var trackVariables = decryptData(data);
                trackList.Add(trackVariables);
            }

            if (trackList.Count > 0)
            {
                var handler = UpdatedTracks;
                handler?.Invoke(this, new NewTracksEventArgs(trackList));
            }
            
        }

        public Track decryptData(string currentTrack)
        {
            var track = new Track();
            CultureInfo provider = CultureInfo.InvariantCulture;

            string[] splitter = new string[5];
            splitter = currentTrack.Split(';');
            int i = 0;

            foreach (var variable in splitter)
            {
                splitter[i] = variable;
                i++;
            }

            int tagLen = splitter[0].Length;
            int xLen = splitter[1].Length;
            int yLen = splitter[2].Length;
            int altLen = splitter[3].Length;
            int timeLen = splitter[4].Length;

            int tagPos = 0;
            int xPos = tagPos + tagLen + 1;
            int yPos = xPos + xLen + 1;
            int altPos = yPos + yLen + 1;
            int timePos = altPos + altLen + 1;


            track.Tag = currentTrack.Substring(tagPos, tagLen);
            track.Xcoor = Int32.Parse(currentTrack.Substring(xPos, xLen));
            track.Ycoor = Int32.Parse(currentTrack.Substring(yPos, yLen));
            track.Altitude = Int32.Parse(currentTrack.Substring(altPos, altLen));
            track.TimeStamp = DateTime.ParseExact(currentTrack.Substring(timePos, timeLen), "yyyyMMddHHmmssfff", provider);
            track.Velocity = 0;
            track.Compass = 0;

            return track;
        }
    }
}
