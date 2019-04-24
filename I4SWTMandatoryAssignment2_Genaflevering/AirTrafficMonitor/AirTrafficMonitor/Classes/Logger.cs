using System;
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
        private string[] lines = new string[30];
        private int lineNmb = 0;

        public string[] Lines { get; set; }
        public int LineNmb { get; set; }

        public Logger()
        {

        }

        public void printToLog(string tag1, string tag2, DateTime time)
        {
            lines[lineNmb] = "Conflict between " + tag1 + " & " + tag2 + " at" +
                             time.Hour + ":" + time.Minute + ":" + time.Second + "." + 
                             time.Millisecond + " " + time.Day + "/" + time.Month + "-" + time.Year;
            System.IO.File.WriteAllLines(@"C:\Users\Admin\Desktop\Logs.txt", lines);
            lineNmb++;
        }
    }
}
