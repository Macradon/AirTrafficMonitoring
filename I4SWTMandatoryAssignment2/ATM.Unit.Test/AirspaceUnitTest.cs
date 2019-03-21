using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using I4SWTMandatoryAssignment2.Model;


namespace ATM.Test.Unit

{
    [TestFixture]
    class AirspaceUnitTests
    {
        private Airspace uut;
        private Track track;

        [SetUp]
        public void setup()
        {
            uut = new Airspace();
        }
        //Lav for x, y, og z
        [TestCase(0, 40000, 10000)]
        [TestCase(40000, 0, 15000)]
        [TestCase(30000, 20000, 500)]
        //Høj for x,y og z
        [TestCase(80000, 40000, 10000)]
        [TestCase(40000, 80000, 15000)]
        [TestCase(30000, 20000, 20000)]
        public void TrackInsideAirspace_ReturnTrue(int x, int y, int z)
        {
            track = new Track()
            {
                Xcoor = x,
                Ycoor = y,
                Altitude = z
            };

            Assert.That(uut.positionTrack(track), Is.EqualTo(true));
        }
            
        
    


    }
}
