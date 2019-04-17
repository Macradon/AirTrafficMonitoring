using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace I4SWTMandatoryAssignment2.Model
{
   public class Logger
    {
        private string[] lines = new string[30];
        private int lineNmb = 0;
        public Logger()
        {
            
        }

         public void printToLog(string tag1, string tag2, DateTime tid)
        {
            lines[lineNmb] = "Conflict between " + tag1 + " & " + tag2 + " at" +
            tid.Hour + ":" + tid.Minute + ":" + tid.Second + "." + tid.Millisecond + " " + tid.Day + "/" + tid.Month + "-" + tid.Year;
            System.IO.File.WriteAllLines(@"C:\Users\Admin\Desktop\Logs.txt", lines);
            lineNmb++;
 
        }
    }


    
}
