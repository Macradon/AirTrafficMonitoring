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
            Track Newtrack = new Track();
        }

        public double calculateVelocity(int formerX, int formerY, int newX, int newY)
        {
            double Velocity = Math.Sqrt((Math.Pow((newX - formerX), 2)) + (Math.Pow((newY - formerY), 2)));
            return Math.Round(Velocity, 2);
        }

        public double calculateCompass(int centerX, int centerY, int trackX, int trackY)
        {
            double xDis = Math.Abs(centerX - trackX);
            double yDis = Math.Abs(centerY - trackY);
            double hypo = Math.Sqrt(Math.Pow(xDis, 2) + Math.Pow(yDis, 2));

            double angle;
            if (trackX == centerX && trackY == centerY)     //Track is centered
                angle = 0;
            else if (trackX == centerX && trackY > centerY) //Track moves North
                angle = 0;
            else if (trackX < centerX && trackY == centerY) //Track moves West
                angle = 90;
            else if (trackX == centerX && trackY < centerY) //Track moves South
                angle = 180;
            else if (trackX > centerX && trackY == centerY) //Track moves East
                angle = 270;
            else
            {
                angle = Math.Acos((-(Math.Pow(yDis, 2)) + Math.Pow(xDis, 2) + Math.Pow(hypo, 2)) / (2 * xDis * hypo)) * 360 / (2 * Math.PI);

                if (trackX < centerX && trackY >= centerY)
                    angle = 90 - angle;
                else if (trackX < centerX && trackY < centerY)
                    angle += 90;
                else if (trackX >= centerX && trackY < centerY)
                    angle = 270 - angle;
                else if (trackX >= centerX && trackY >= centerY)
                    angle += 270;
            }

            double Compass = angle;
            return Math.Round(Compass, 2);
        }
    }
}
