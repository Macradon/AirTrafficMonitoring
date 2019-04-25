using System;
using AirTrafficMonitor;
using TransponderReceiver;
using AirTrafficMonitor.Classes;
using System.Collections.Generic;

namespace TransponderReceiver
{
    public class TransponderReceiverEventArgs : EventArgs
    {
        public List<string> liste { get; set; }

        public TransponderReceiverEventArgs(List<string> transString)
        {
            liste = transString;
        }
    }

    
    public class TransponderReceiverClient : iTransponderReceiverClient
    {
        //public event EventHandler<TransponderReceiverEventArgs> OnTrackListe;
        public delegate void TracklisteHandler(object source, EventArgs args);
        public event TracklisteHandler TrackListe;
        public List<string> eks;
        private ITransponderReceiver receiver;

        // Using constructor injection for dependency/ies
        public TransponderReceiverClient(ITransponderReceiver receiver)
        {
            // This will store the real or the fake transponder data receiver
            this.receiver = receiver;

            eks = new List<string>();

            // Attach to the event of the real or the fake TDR
            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        public TransponderReceiverClient()
        {
        }

        

       private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            //eks.Clear();
            Console.Clear();
            // Just display data
            foreach (var data in e.TransponderData)
            {
                Console.WriteLine($"Transponderdata {data}");
                eks.Add(data);
            }
            var handler = TrackListe;
            if (TrackListe != null)
                handler?.Invoke(this, new TransponderReceiverEventArgs(eks));
        }
    }
}
