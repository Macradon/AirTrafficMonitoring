﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using AirTrafficMonitor.Classes;


namespace AirTrafficMonitor
{
    public class Logger
    {
        iConflictDetection ConflictDetect = new ConflictDetection();

        private string[] lines { get; set; }
        private int lineNmb { get; set; }

        public void printToLog(string tag1, string tag2, DateTime tid)
        {

        }
    }
}
