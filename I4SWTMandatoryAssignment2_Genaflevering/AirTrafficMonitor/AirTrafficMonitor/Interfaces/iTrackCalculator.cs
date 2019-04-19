﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    interface iTrackCalculator
    {
        public void calculateVelocity(Track, Track);
        public void calculateCompass(Track, Track);
    }
}
