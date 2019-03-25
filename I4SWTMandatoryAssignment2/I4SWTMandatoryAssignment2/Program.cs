using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Threading;
using I4SWTMandatoryAssignment2.Model;

namespace I4SWTMandatoryAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            var system = new TransponderReceiverUser.TransponderReceiverClient(receiver);

            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
