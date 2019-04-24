using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AirTrafficMonitor.Unit_Test
{

    [TestFixture]
    class TrackCalculatorTest
    {
        private TrackCalculator uut;
        private string  tra;
        private Track track;


        [SetUp]
        public void Setup()
        {
            uut = new TrackCalculator();
            tra = "Boe747;12345;54321;2222;20190321123456789";

        }
        //Minimum tilladt x, y og z værdi

        [Test]
        public void CorrectVelocity(int x, int y, Track track)
        {
            track = new Track()
            {
                Xcoor = x,
                Ycoor = y
                
            };
            Assert.That(uut.calculateVelocity(x, y, track), Is.EqualTo(true));
            
        }





        //x, y og z værdier for lave
        [TestCase(4999, 40000, 10000)]
        [TestCase(40000, 4999, 15000)]
        [TestCase(30000, 20000, 499)]
        //x, y og z værdier for høje
        [TestCase(85001, 40000, 10000)]
        [TestCase(40000, 85001, 15000)]
        [TestCase(30000, 20000, 20001)]
        //Alle værdier er uden for boundary
        [TestCase(4999, 4999, 499)]
        [TestCase(85001, 85001, 20001)]
        public void tracksWithinAirspaceFalse(int x, int y, int z)
        {
            track = new Track()
            {
                Xcoor = x,
                Ycoor = y,
                Altitude = z
            };

            Assert.That(uut.checkPosition(track), Is.EqualTo(false));
        }
    }
}
