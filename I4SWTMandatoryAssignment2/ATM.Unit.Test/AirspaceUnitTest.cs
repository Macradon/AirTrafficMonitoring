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
        //Minimum tilladt x, y og z værdi
        [TestCase(0, 40000, 10000)]
        [TestCase(40000, 0, 15000)]
        [TestCase(30000, 20000, 500)]
        //Maximum tilladt for x, y og z værdi
        [TestCase(80000, 40000, 10000)]
        [TestCase(40000, 80000, 15000)]
        [TestCase(30000, 20000, 20000)]
        public void tracksWithinAirspaceTrue(int x, int y, int z)
        {
            track = new Track()
            {
                Xcoor = x,
                Ycoor = y,
                Altitude = z
            };

            Assert.That(uut.positionTrack(track), Is.EqualTo(true));
        }

        //x, y og z værdier for lave
        [TestCase(-1, 40000, 10000)]
        [TestCase(40000, -1, 15000)]
        [TestCase(30000, 20000, 499)]
        //x, y og z værdier for høje
        [TestCase(80001, 40000, 10000)]
        [TestCase(40000, 80001, 15000)]
        [TestCase(30000, 20000, 20001)]
        public void tracksWithinAirspaceFalse(int x, int y, int z)
        {
            track = new Track()
            {
                Xcoor = x,
                Ycoor = y,
                Altitude = z
            };

            Assert.That(uut.positionTrack(track), Is.EqualTo(false));
        }




    }
}
