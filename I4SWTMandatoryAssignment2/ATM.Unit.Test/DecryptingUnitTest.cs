using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using I4SWTMandatoryAssignment2.Model;
using TransponderReceiver;




namespace ATM.Unit.Test
{
    [TestFixture]
    class DecryptingUnitTest
    {
        private Decrypting uut;
        private string transponder;
        private string formerPosition;
        private string newPosition;


        [SetUp]
        public void setup()
        {

            uut = new Decrypting("");
            transponder = "Boe747;12345;54321;2222;20190321123456789";
            formerPosition = "Boe747;10000;10000;2222;20190321123456789";
            newPosition = "Boe747;40000;50000;2222;20190321123456789";
        }
        
        [Test]
        public void CorrectTrackTag()
        {
            Assert.That(uut.decryptTrack(transponder).Tag, Is.EqualTo("Boe747"));
        }

        [Test]
        public void CorrectTrackXcoor()
        {
            Assert.That(uut.decryptTrack(transponder).Xcoor, Is.EqualTo(12345));
        }

        [Test]
        public void CorrectTrackYcoor()
        {
            Assert.That(uut.decryptTrack(transponder).Ycoor, Is.EqualTo(54321));
        }

        [Test]
        public void CorrectTrackAltitude()
        {
            Assert.That(uut.decryptTrack(transponder).Altitude, Is.EqualTo(2222));
        }

        [Test]
        public void CorrectTrackTimestampYear()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Year, Is.EqualTo(2019));
        }

        [Test]
        public void CorrectTrackTimestampMonth()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Month, Is.EqualTo(3));
        }

        [Test]
        public void CorrectTrackTimestampDay()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Day, Is.EqualTo(21));
        }

        [Test]
        public void CorrectTrackTimestampHour()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Hour, Is.EqualTo(12));
        }

        [Test]
        public void CorrectTrackTimestampMinute()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Minute, Is.EqualTo(34));
        }

        [Test]
        public void CorrectTrackTimestampSecond()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Second, Is.EqualTo(56));
        }

        [Test]
        public void CorrectTrackTimestampMillisecond()
        {
            Assert.That(uut.decryptTrack(transponder).TimeStamp.Millisecond, Is.EqualTo(789));
        }

        [Test]
        public void CorrectTrackVelocity()
        {
            Assert.That(uut.decryptTrack(transponder).Velocity, Is.EqualTo(0));
        }

        [Test]
        public void CorrectTrackCompass()
        {
            Assert.That(uut.decryptTrack(transponder).Compass, Is.EqualTo(0));
        }

        [Test]
        public void newCalculatedVelocity()
        {
            Track formerTrack = new Track();
            Track newTrack = new Track();
            formerTrack = uut.decryptTrack(formerPosition);
            newTrack = uut.decryptTrack(newPosition);
            Assert.That(uut.decryptTrackVelocity(formerTrack, newTrack).Velocity, Is.EqualTo(50000)); //Pythagoras: 30000^2 + 40000^2 = 50000^2
        }


    }
}
