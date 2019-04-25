using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.DAL;
using NUnit.Framework;

namespace AirTrafficMonitor.DAL
{



    [TestFixture]
    class DecryptingUnitTest
    {
        private Decrypting uut;
        private string transponder;
        private string formerPosition;
        private string newPosition;
        private string testtag;
        private string testtt;


        [SetUp]
        public void setup()
        {

            uut = new Decrypting();
            transponder = "Boe747;12345;54321;2222;20190321123456789";
            formerPosition = "Boe747;10000;10000;2222;20190321123456789";
            newPosition = "Boe747;40000;50000;2222;20190321123456789";
            testtag=uut.decryptData(transponder).Tag;
        }

        [Test]
        public void CorrectTrackTag()
        {
            Assert.AreEqual("Boe747",testtag);
            //Assert.That(uut.decryptData(transponder).Tag, Is.EqualTo("Boe747"));
        }
        [Test]
            public void CorrectTrackXcoor()
            {
                Assert.That(uut.decryptData(transponder).Xcoor, Is.EqualTo(12345));
            }

            [Test]
            public void CorrectTrackYcoor()
            {
                Assert.That(uut.decryptData(transponder).Ycoor, Is.EqualTo(54321));
            }

            [Test]
            public void CorrectTrackAltitude()
            {
               Assert.That(uut.decryptData(transponder).Altitude, Is.EqualTo(2222));
            }

            [Test]
            public void CorrectTrackTimestampYear()
            {
                
                Assert.That(uut.decryptData(transponder).TimeStamp.Year, Is.EqualTo(2019));
            }

            [Test]
            public void CorrectTrackTimestampMonth()
            {
                Assert.That(uut.decryptData(transponder).TimeStamp.Month, Is.EqualTo(3));
            }

            [Test]
            public void CorrectTrackTimestampDay()
            {
                Assert.That(uut.decryptData(transponder).TimeStamp.Day, Is.EqualTo(21));
            }

            [Test]
            public void CorrectTrackTimestampHour()
            {
                Assert.That(uut.decryptData(transponder).TimeStamp.Hour, Is.EqualTo(12));
            }

            [Test]
            public void CorrectTrackTimestampMinute()
            {
                Assert.That(uut.decryptData(transponder).TimeStamp.Minute, Is.EqualTo(34));
            }

            [Test]
            public void CorrectTrackTimestampSecond()
            {
                Assert.That(uut.decryptData(transponder).TimeStamp.Second, Is.EqualTo(56));
            }

            [Test]
            public void CorrectTrackTimestampMillisecond()
            {
                Assert.That(uut.decryptData(transponder).TimeStamp.Millisecond, Is.EqualTo(789));
            }

            [Test]
            public void CorrectTrackVelocity()
            {
                Assert.That(uut.decryptData(transponder).Velocity, Is.EqualTo(0));
            }

            [Test]
            public void CorrectTrackCompass()
            {
                Assert.That(uut.decryptData(transponder).Compass, Is.EqualTo(0));
            }

            [Test]
            /*public void newCalculatedVelocity()
            {
                Track formerTrack = new Track();
                Track newTrack = new Track();
                formerTrack = uut.decryptData(formerPosition);
                newTrack = uut.decryptData(newPosition);
                Assert.That(uut.decryptTrackVelocity(formerTrack, newTrack).Velocity, Is.EqualTo(50000)); //Pythagoras: 30000^2 + 40000^2 = 50000^2
            }
            */
            [TestCase(45000, 45000, 15000, 85000, 36.87)]  //Track moving NW
            [TestCase(45000, 45000, 15000, 5000, 143.13)]   //Track moving SW
            [TestCase(45000, 45000, 75000, 5000, 216.87)]   //Track moving SE
            [TestCase(45000, 45000, 75000, 85000, 323.13)]   //Track moving NE

            [TestCase(45000, 45000, 45000, 45000, 0)]       //Track not moving

            [TestCase(45000, 45000, 45000, 85000, 0)]      //Track moving North
            [TestCase(45000, 45000, 15000, 45000, 90)]      //Track moving West
            [TestCase(45000, 45000, 45000, 5000, 180)]       //Track moving South
            [TestCase(45000, 45000, 75000, 45000, 270)]      //Track moving East
            public void newCalculatedCompass(int x1, int y1, int x2, int y2, double result)
            {
                Track centerPos = new Track()
                {
                    Xcoor = x1,
                    Ycoor = y1,
                };

                Track newTrack = new Track()
                {
                    Xcoor = x2,
                    Ycoor = y2,
                };

                Assert.That(uut.decryptTrackCompass(centerPos, newTrack).Compass, Is.EqualTo(result));
            }

        }

    }

