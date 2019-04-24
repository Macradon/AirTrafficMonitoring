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
        Airspace airspace = new Airspace();
        public TrackCalculator()
        {
            
        }

        public double calculateVelocity(int formerX, int formerY, int newX, int newY)
        {
            double Velocity = Math.Sqrt((Math.Pow((newX - formerX), 2)) + (Math.Pow((newY - formerY), 2)));
            return Math.Round(Velocity, 2);
        }

        public double calculateCompass(int trackX, int trackY)
        {
            double xDis = Math.Abs((airspace.neCornerX - airspace.swCornerX) - trackX);
            double yDis = Math.Abs((airspace.neCornerY - airspace.swCornerY) - trackY);
            double hypo = Math.Sqrt(Math.Pow(xDis, 2) + Math.Pow(yDis, 2));

            double angle;
            if (trackX == (airspace.neCornerX - airspace.swCornerX) && trackY == (airspace.neCornerY - airspace.swCornerY))     //Track is centered
                angle = 0;
            else if (trackX == (airspace.neCornerX - airspace.swCornerX) && trackY > (airspace.neCornerY - airspace.swCornerY)) //Track moves North
                angle = 0;
            else if (trackX < (airspace.neCornerX - airspace.swCornerX) && trackY == (airspace.neCornerY - airspace.swCornerY)) //Track moves West
                angle = 90;
            else if (trackX == (airspace.neCornerX - airspace.swCornerX) && trackY < (airspace.neCornerY - airspace.swCornerY)) //Track moves South
                angle = 180;
            else if (trackX > (airspace.neCornerX - airspace.swCornerX) && trackY == (airspace.neCornerY - airspace.swCornerY)) //Track moves East
                angle = 270;
            else
            {
                angle = Math.Acos((-(Math.Pow(yDis, 2)) + Math.Pow(xDis, 2) + Math.Pow(hypo, 2)) / (2 * xDis * hypo)) * 360 / (2 * Math.PI);

                if (trackX < (airspace.neCornerX - airspace.swCornerX) && trackY >= (airspace.neCornerY - airspace.swCornerY))
                    angle = 90 - angle;
                else if (trackX < (airspace.neCornerX - airspace.swCornerX) && trackY < (airspace.neCornerY - airspace.swCornerY))
                    angle += 90;
                else if (trackX >= (airspace.neCornerX - airspace.swCornerX) && trackY < (airspace.neCornerY - airspace.swCornerY))
                    angle = 270 - angle;
                else if (trackX >= (airspace.neCornerX - airspace.swCornerX) && trackY >= (airspace.neCornerY - airspace.swCornerY))
                    angle += 270;
            }

            double Compass = angle;
            return Math.Round(Compass, 2);
        }
    }
}
