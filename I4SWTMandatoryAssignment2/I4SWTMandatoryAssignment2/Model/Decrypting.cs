using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;  //Used for DateTime
using TransponderReceiver;


namespace I4SWTMandatoryAssignment2.Model
{
    public class Decrypting : iDecrypting
    {
        public Decrypting(string data)
        {

        }

        public Track decryptTrack(string currentTrack)
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

        public Track decryptTrackVelocity(Track formerTrack, Track newTrack)
        {
            newTrack.Velocity = Math.Sqrt((Math.Pow((newTrack.Xcoor - formerTrack.Xcoor), 2)) + (Math.Pow((newTrack.Ycoor - formerTrack.Ycoor), 2)));
            newTrack.Velocity = Math.Round(newTrack.Velocity, 2);
            return newTrack;
        }

        public Track decryptTrackCompass(Track centerPos, Track newTrack)
        {
            double xDis = Math.Abs(centerPos.Xcoor - newTrack.Xcoor);
            double yDis = Math.Abs(centerPos.Ycoor - newTrack.Ycoor);
            double hypo = Math.Sqrt(Math.Pow(xDis, 2) + Math.Pow(yDis, 2));
            double angle = Math.Acos((-(Math.Pow(yDis, 2)) + Math.Pow(xDis, 2) + Math.Pow(hypo, 2)) / (2 * xDis * hypo)) * 360 / (2 * Math.PI);

            if (newTrack.Xcoor < centerPos.Xcoor && newTrack.Ycoor >= centerPos.Ycoor)
                angle = 180 - angle;
            else if (newTrack.Xcoor < centerPos.Xcoor && newTrack.Ycoor < centerPos.Ycoor)
                angle += 180;
            else if (newTrack.Xcoor >= centerPos.Xcoor && newTrack.Ycoor < centerPos.Ycoor)
                angle = 360 - angle;
            else if (newTrack.Xcoor == centerPos.Xcoor && newTrack.Ycoor == centerPos.Ycoor)
                angle = 0;


            newTrack.Compass = angle;
            newTrack.Compass = Math.Round(newTrack.Compass, 2);
            return newTrack;
        }
    }  
}
