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
        public void Setup()
        {
            uut = new Airspace();
        }
        //Minimum tilladt x, y og z værdi
        [TestCase(5000, 40000, 10000)]
        [TestCase(40000, 5000, 15000)]
        [TestCase(30000, 20000, 500)]
        //Maximum tilladt for x, y og z værdi
        [TestCase(85000, 40000, 10000)]
        [TestCase(40000, 85000, 15000)]
        [TestCase(30000, 20000, 20000)]
        //Alle værdier er på grænsen
        [TestCase(5000, 5000, 500)]
        [TestCase(85000, 85000, 20000)]
        public void tracksWithinAirspaceTrue(int x, int y, int z)
        {
            track = new Track()
            {
                Xcoor = x,
                Ycoor = y,
                Altitude = z
            };

            Assert.That(uut.checkAirspace(track), Is.EqualTo(true));
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

            Assert.That(uut.checkAirspace(track), Is.EqualTo(false));
        }




    }
}
