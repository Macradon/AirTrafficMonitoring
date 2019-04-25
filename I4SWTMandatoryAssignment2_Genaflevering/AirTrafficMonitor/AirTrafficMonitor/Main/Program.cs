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
            var system = new TransponderReceiverClient(receiver);
            var airspace = new Airspace();


            while (true)
            {
                //Thread.Sleep(1000);
            }
        }
    }
}
