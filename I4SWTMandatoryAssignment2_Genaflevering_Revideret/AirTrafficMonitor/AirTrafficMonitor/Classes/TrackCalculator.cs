using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class TrackCalculator : iTrackCalculator
    {
        public TrackCalculator()
        {

        }

        public void calculateVelocity(Track trackBefore, Track trackNew)
        {
            double distance = Math.Sqrt((Math.Pow((trackNew.Xcoor - trackBefore.Xcoor), 2)) + (Math.Pow((trackNew.Ycoor - trackBefore.Ycoor), 2)));
            trackNew.Velocity = Math.Round(distance, 2);
        }

        public void calculateCompass(Track centerPos, Track trackPos)
        {
            double xDis = Math.Abs(centerPos.Xcoor - trackPos.Xcoor);
            double yDis = Math.Abs(centerPos.Ycoor - trackPos.Ycoor);
            double hypo = Math.Sqrt(Math.Pow(xDis, 2) + Math.Pow(yDis, 2));

            double angle;
            if (trackPos.Xcoor == centerPos.Xcoor && trackPos.Ycoor == centerPos.Ycoor)     //Track is centered
                angle = 0;
            else if (trackPos.Xcoor == centerPos.Xcoor && trackPos.Ycoor > centerPos.Ycoor) //Track moves North
                angle = 0;
            else if (trackPos.Xcoor < centerPos.Xcoor && trackPos.Ycoor == centerPos.Ycoor) //Track moves West
                angle = 90;
            else if (trackPos.Xcoor == centerPos.Xcoor && trackPos.Ycoor < centerPos.Ycoor) //Track moves South
                angle = 180;
            else if (trackPos.Xcoor > centerPos.Xcoor && trackPos.Ycoor == centerPos.Ycoor) //Track moves East
                angle = 270;
            else
            {
                angle = Math.Acos((-(Math.Pow(yDis, 2)) + Math.Pow(xDis, 2) + Math.Pow(hypo, 2)) / (2 * xDis * hypo)) * 360 / (2 * Math.PI);

                if (trackPos.Xcoor < centerPos.Xcoor && trackPos.Ycoor >= centerPos.Ycoor)
                    angle = 90 - angle;
                else if (trackPos.Xcoor < centerPos.Xcoor && trackPos.Ycoor < centerPos.Ycoor)
                    angle += 90;
                else if (trackPos.Xcoor >= centerPos.Xcoor && trackPos.Ycoor < centerPos.Ycoor)
                    angle = 270 - angle;
                else if (trackPos.Xcoor >= centerPos.Xcoor && trackPos.Ycoor >= centerPos.Ycoor)
                    angle += 270;
            }

            double cource = angle;
            trackPos.Compass = Math.Round(cource, 2);
        }
    }
}
