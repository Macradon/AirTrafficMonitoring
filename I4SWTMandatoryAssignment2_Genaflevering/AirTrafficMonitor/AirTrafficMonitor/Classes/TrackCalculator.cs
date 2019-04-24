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
        public TrackCalculator()
        {
            
        }

        public void calculateVelocity(int formerX, int formerY, Track track)
        {
            double Velocity = Math.Sqrt((Math.Pow((track.Xcoor - formerX), 2)) + (Math.Pow((track.Ycoor - formerY), 2)));
            track.Velocity = Math.Round(Velocity, 2);
        }

        public void calculateCompass(int centerX, int centerY, Track track)
        {
            double xDis = Math.Abs(centerX - track.Xcoor);
            double yDis = Math.Abs(centerY - track.Ycoor);
            double hypo = Math.Sqrt(Math.Pow(xDis, 2) + Math.Pow(yDis, 2));

            double angle;
            if (track.Xcoor == centerX && track.Ycoor == centerY)     //Track is centered
                angle = 0;
            else if (track.Xcoor == centerX && track.Ycoor > centerY) //Track moves North
                angle = 0;
            else if (track.Xcoor < centerX && track.Ycoor == centerY) //Track moves West
                angle = 90;
            else if (track.Xcoor == centerX && track.Ycoor < centerY) //Track moves South
                angle = 180;
            else if (track.Xcoor > centerX && track.Ycoor == centerY) //Track moves East
                angle = 270;
            else
            {
                angle = Math.Acos((-(Math.Pow(yDis, 2)) + Math.Pow(xDis, 2) + Math.Pow(hypo, 2)) / (2 * xDis * hypo)) * 360 / (2 * Math.PI);

                if (track.Xcoor < centerX && track.Ycoor >= centerY)
                    angle = 90 - angle;
                else if (track.Xcoor < centerX && track.Ycoor < centerY)
                    angle += 90;
                else if (track.Xcoor >= centerX && track.Ycoor < centerY)
                    angle = 270 - angle;
                else if (track.Xcoor >= centerX && track.Ycoor >= centerY)
                    angle += 270;
            }

            double Compass = angle;
            track.Compass = Math.Round(Compass, 2);
        }
    }
}
