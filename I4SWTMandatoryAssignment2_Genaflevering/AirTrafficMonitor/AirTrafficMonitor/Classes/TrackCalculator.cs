using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class TrackCalculator: iTrackCalculator
    {
        private Track tra1 = new Track();
        
        
       

        public TrackCalculator()
        {

        }

        public void calculateVelocity(Track formerTrack, Track newTrack)
        {
            newTrack.Velocity = Math.Sqrt((Math.Pow((newTrack.Xcoor - formerTrack.Xcoor), 2)) + (Math.Pow((newTrack.Ycoor - formerTrack.Ycoor), 2)));
            newTrack.Velocity = Math.Round(newTrack.Velocity, 2);
        }

        public void calculateCompass(Track centerPos, Track newTrack)
        {
            double xDis = Math.Abs(centerPos.Xcoor - newTrack.Xcoor);
            double yDis = Math.Abs(centerPos.Ycoor - newTrack.Ycoor);
            double hypo = Math.Sqrt(Math.Pow(xDis, 2) + Math.Pow(yDis, 2));

            double angle;
            if (newTrack.Xcoor == centerPos.Xcoor && newTrack.Ycoor == centerPos.Ycoor)     //Track is centered
                angle = 0;
            else if (newTrack.Xcoor == centerPos.Xcoor && newTrack.Ycoor > centerPos.Ycoor) //Track moves North
                angle = 0;
            else if (newTrack.Xcoor < centerPos.Xcoor && newTrack.Ycoor == centerPos.Ycoor) //Track moves West
                angle = 90;
            else if (newTrack.Xcoor == centerPos.Xcoor && newTrack.Ycoor < centerPos.Ycoor) //Track moves South
                angle = 180;
            else if (newTrack.Xcoor > centerPos.Xcoor && newTrack.Ycoor == centerPos.Ycoor) //Track moves East
                angle = 270;
            else
            {
                angle = Math.Acos((-(Math.Pow(yDis, 2)) + Math.Pow(xDis, 2) + Math.Pow(hypo, 2)) / (2 * xDis * hypo)) * 360 / (2 * Math.PI);

                if (newTrack.Xcoor < centerPos.Xcoor && newTrack.Ycoor >= centerPos.Ycoor)
                    angle = 90 - angle;
                else if (newTrack.Xcoor < centerPos.Xcoor && newTrack.Ycoor < centerPos.Ycoor)
                    angle += 90;
                else if (newTrack.Xcoor >= centerPos.Xcoor && newTrack.Ycoor < centerPos.Ycoor)
                    angle = 270 - angle;
                else if (newTrack.Xcoor >= centerPos.Xcoor && newTrack.Ycoor >= centerPos.Ycoor)
                    angle += 270;
            }

            newTrack.Compass = angle;
            newTrack.Compass = Math.Round(newTrack.Compass, 2);

            


        }
    }
}
