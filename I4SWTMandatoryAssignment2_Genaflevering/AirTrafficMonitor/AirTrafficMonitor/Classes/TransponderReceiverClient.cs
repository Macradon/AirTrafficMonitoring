using System;
using AirTrafficMonitor;
using TransponderReceiver;
using AirTrafficMonitor.Classes;
using System.Collections.Generic;

namespace TransponderReceiver
{
    public class AnswerEventArgs : EventArgs
    {
        public List<string> liste;
    }
    
    public class TransponderReceiverClient
    {
        public delegate void TrackListe(List<string> optaget);

        public event TrackListe OnTrackListe;

        private ITransponderReceiver receiver;

        List<string> eks;

        public TransponderReceiverClient()
        {

        }
        

        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            Console.Clear();
            // Just display data
            foreach (var data in e.TransponderData)
            {
                //System.Console.WriteLine($"Transponderdata {data}");
                eks.Add(data);
            }
            OnTrackListe(eks);
        }
    }
}
