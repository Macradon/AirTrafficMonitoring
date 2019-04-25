using System;
using AirTrafficMonitor;
using TransponderReceiver;
using AirTrafficMonitor.Classes;
using System.Collections.Generic;

namespace AirTrafficMonitor
{
    public delegate void KnowAnswer(object sender, AnswerEventArgs eks);

    public class AnswerEventArgs : EventArgs
    {
        public List<string> answer = new List<string>();
    }

    

    public class TransponderReceiverClient : iTransponderReceiverClient
    {
        private ITransponderReceiver receiver;

        public event KnowAnswer OnKnowAnswer;
        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        public TransponderReceiverClient()
        {

        }

        public void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            AnswerEventArgs eks = new AnswerEventArgs();
            //eks.Clear();
            Console.Clear();
            // Just display data
            foreach (var data in e.TransponderData)
            {
                Console.WriteLine($"Transponderdata {data}");
                eks.answer.Add(data);
            }
            OnKnowAnswer(this, eks);
        }
    }
}
