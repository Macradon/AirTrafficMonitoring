using System;
using AirTrafficMonitor;
using TransponderReceiver;
using AirTrafficMonitor.Classes;
using System.Collections.Generic;

namespace TransponderReceiverUser
{
    public delegate void TrackListe(object sender, Decrypting args);
    public class TransponderReceiverClient
    {
        public event TrackListe onTrackListe;
        private ITransponderReceiver receiver;
        Decrypting decrypt = new Decrypting();

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
            
            List<string> liste = new List<string>();
            Console.Clear();
            // Just display data
            foreach (var data in e.TransponderData)
            {
                //System.Console.WriteLine($"Transponderdata {data}");
                liste.Add(data);
            }
         
            }

        Decrypting e = new Decrypting();

    }
}
