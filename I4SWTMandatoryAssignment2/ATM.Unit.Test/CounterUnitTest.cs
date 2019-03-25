﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using I4SWTMandatoryAssignment2.Model;



namespace ATM.Unit.Test
{
    [TestFixture]

    class CounterUnitTest
    {
       
        private Track _track1;
        private Track _track2;
        private Counter uut;

        //Preprocessor valus
        private int nr1 = 1;
        private int nr2 = 2;


        [SetUp]
        public void Setup()
        {
            uut = new Counter();
           

            _track1 = new Track()
            {
                Tag = "Airbus",
                Xcoor = 40000,
                Ycoor = 40000,
                Altitude = 15000,
                Velocity = 200,
                Compass = 200,
                

        };

            _track2 = new Track()
            {
                Tag = "Boeing",
                Xcoor = 45000,
                Ycoor = 45000,
                Altitude = 10000,
                Velocity = 300,
                Compass = 300,
            };

            
        }

        [Test]
        public void countTracks_AddTracksCountedTest1()
        {
            
            uut.addTrack();
            Assert.That(uut.getTracks(), Is.EqualTo(nr1));
            
        }

        [Test]
        public void counTracks_AddTracksCountedTest2()
        {

            uut.addTrack();
            uut.addTrack();
            Assert.That(uut.getTracks(), Is.EqualTo(nr2));
        }

        [Test]
        public void counTracks_SubtrackTracksCountedTest1()
        {
            for (int i = 0; i < 2; i++)
            {
                uut.addTrack();
            }
            

            uut.subtractTrack();
            Assert.That(uut.getTracks(), Is.EqualTo(nr1));
        }


        [Test]
        public void counTracks_SubtrackTracksCountedTest2()
        {

            for (int i = 0; i < 3; i++)
            {
                uut.addTrack();
            }

            uut.subtractTrack();
            Assert.That(uut.getTracks(), Is.EqualTo(nr2));
        }

        [Test]
        public void counTracks_SubtrackFirstAddTracklater()
        {
            uut.subtractTrack();
            uut.addTrack();

            Assert.That(uut.getTracks(), Is.EqualTo(nr1));
        }

    }
}
