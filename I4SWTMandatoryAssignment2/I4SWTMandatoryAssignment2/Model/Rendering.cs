using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I4SWTMandatoryAssignment2.Model;


namespace I4SWTMandatoryAssignment2
{
    public class Rendering : iRendering
    { 
        private Print _print;

        public Rendering(Print print)
        {
            _print = print;
        }

    
        //Funktionen "MASKER" sig op til vores iPrint -> kig i interfaces 
        public void TracksRender(Track track)
        {
            _print.print("Tag: " + track.Tag + ", X: " + track.Xcoor + ", Y: " + track.Ycoor + ", Altitude: " + track.Altitude + ", Velocity: " + track.Velocity + ", Course: " + track.Compass);
        }

    }
}
