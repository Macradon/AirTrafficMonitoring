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
        private string[] lines;
        private int lineNmb = 0;
        public Logger()
        {
            
        }

         public void printToLog(string tag1, string tag2, DateTime tid)
        {

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Admin\Desktop\Logs.txt"))
            {
                lines[lineNmb] = "Conflict between " + tag1 + " & " + tag2 + " at" +
                    tid.Hour + ":" + tid.Minute + ":" + tid.Second + "." + tid.Millisecond + " " + tid.Day + "/" + tid.Month + "-" + tid.Year;
                file.WriteLine(lines);
                lineNmb++;
            }
        }
    }


    
}
