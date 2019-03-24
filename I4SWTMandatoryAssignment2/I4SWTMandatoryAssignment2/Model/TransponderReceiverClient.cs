using TransponderReceiver;
using I4SWTMandatoryAssignment2.Model;

namespace TransponderReceiverUser
{
    public class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;

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
            System.Console.Clear();
            Counter count = new Counter();

            // Just display data
            foreach (var data in e.TransponderData)
            {
                count.addTrack();
            }

            System.Console.Write("Number of Tracks: {0}\n", count.getTracks());

            foreach (var data in e.TransponderData)
            {
                System.Console.WriteLine($"Transponderdata {data}");
            }
        }
    }
}
