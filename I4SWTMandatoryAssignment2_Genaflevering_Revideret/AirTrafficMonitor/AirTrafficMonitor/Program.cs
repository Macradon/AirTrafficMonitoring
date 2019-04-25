using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            var decrypting = new Decrypting(receiver);
            var airspace = new Airspace(decrypting);
            var trackCalculator = new TrackCalculator(airspace);
            var rendering = new Rendering(trackCalculator);
            var conflictDetection = new ConflictDetection();

            while (true)
            {

            }
        }
    }
}
