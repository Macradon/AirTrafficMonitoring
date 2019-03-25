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
    class TrackUnitTests
    {
        
        private Track uut;
        private Track track1;
        private Track track2;

        [SetUp]
        public void Setup()
        {
            uut = new Track();
        }

        [TestCase(50000, 40000, 10000, 50000, 35001, 9701)]
        [TestCase(5000, 70000, 19701, 9999, 70000, 20000)]
        [TestCase(5000, 60000, 19700, 6000, 61000, 19999)]
        public void checkTagYesConflict(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            track1 = new Track()
            {    
                Xcoor = x1,
                Ycoor = y1,
                Altitude = z1
            };

            track2 = new Track()
            {
                Xcoor = x2,
                Ycoor = y2,
                Altitude = z2
            };

              Assert.That(uut.checkConflict(track1, track2), Is.EqualTo(true));
        }

        [TestCase(50000, 40000, 10000, 50000, 35000, 9700)]
        [TestCase(5000, 70000, 19701, 10000, 70000, 20001)]
        [TestCase(10000, 70000, 19701, 14000, 74000, 20000)]
        [TestCase(10000, 70000, 19701, 11000, 71000, 20001)]
        public void checkTagNoConflict(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            track1 = new Track()
            {
                Xcoor = x1,
                Ycoor = y1,
                Altitude = z1
            };

            track2 = new Track()
            {
                Xcoor = x2,
                Ycoor = y2,
                Altitude = z2
            };

            Assert.That(uut.checkConflict(track1, track2), Is.EqualTo(false));
        }


    }
}
