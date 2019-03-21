using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using I4SWTMandatoryAssignment2.Model;


namespace ATM.Unit.Test
{
    [TestFixture]
    class DecryptingUnitTest
    {
        private Decrypting uut;
        private string transponder;

        [SetUp]
        public void setup()
        {
            uut = new Decrypting("");
            transponder = "Boe747;12345;54321;22222;20190321123456789";
        }
        
        [Test]
        public void CorrectTrackTag()
        {
            Assert.That(uut.displayTrack(transponder).Tag, Is.EqualTo("Boe747"));
        }

        [Test]
        public void CorrectTrackXcoor()
        {
            Assert.That(uut.displayTrack(transponder).Xcoor, Is.EqualTo(12345));
        }

        [Test]
        public void CorrectTrackYcoor()
        {
            Assert.That(uut.displayTrack(transponder).Ycoor, Is.EqualTo(54321));
        }

        [Test]
        public void CorrectTrackAltitude()
        {
            Assert.That(uut.displayTrack(transponder).Altitude, Is.EqualTo(22222));
        }

        [Test]
        public void CorrectTrackTimestampYear()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Year, Is.EqualTo(2019));
        }

        [Test]
        public void CorrectTrackTimestampMonth()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Month, Is.EqualTo(3));
        }

        [Test]
        public void CorrectTrackTimestampDay()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Day, Is.EqualTo(21));
        }

        [Test]
        public void CorrectTrackTimestampHour()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Hour, Is.EqualTo(12));
        }

        [Test]
        public void CorrectTrackTimestampMinute()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Minute, Is.EqualTo(34));
        }

        [Test]
        public void CorrectTrackTimestampSecond()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Second, Is.EqualTo(56));
        }

        [Test]
        public void CorrectTrackTimestampMillisecond()
        {
            Assert.That(uut.displayTrack(transponder).TimeStamp.Millisecond, Is.EqualTo(789));
        }

        [Test]
        public void CorrectTrackVelocity()
        {
            Assert.That(uut.displayTrack(transponder).Velocity, Is.EqualTo(0));
        }

        [Test]
        public void CorrectTrackCompass()
        {
            Assert.That(uut.displayTrack(transponder).Compass, Is.EqualTo(0));
        }
    }
}
