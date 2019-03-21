using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;  //Used for DateTime

namespace I4SWTMandatoryAssignment2.Model
{
    public class Decrypting : iDecrypting
    {
        //public Decrypting(iTransponderReceiver TransponderReceiver)
        public Decrypting(string data)
        {

        }


        public Track displayTrack(string currentTrack)
        {
            var track = new Track();
            CultureInfo provider = CultureInfo.InvariantCulture;

            track.Tag = currentTrack.Substring(0, 6);
            track.Xcoor = Int32.Parse(currentTrack.Substring(7, 5));
            track.Ycoor = Int32.Parse(currentTrack.Substring(13, 5));
            track.Altitude = Int32.Parse(currentTrack.Substring(19, 5));
            track.TimeStamp = DateTime.ParseExact(currentTrack.Substring(25, 17), "yyyyMMddHHmmssfff", provider);
            track.Velocity = 0;
            track.Compass = 0;

            return track;
        }
    }
}
