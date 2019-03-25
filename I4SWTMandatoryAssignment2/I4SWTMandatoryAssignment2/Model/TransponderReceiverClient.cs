using TransponderReceiver;
using I4SWTMandatoryAssignment2.Model;
using I4SWTMandatoryAssignment2;

namespace TransponderReceiverUser
{
    public class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;

        private int formerX = 0;
        private int formerY = 0;

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
            Decrypting decrypt = new Decrypting("");
            Print print = new Print();
            Rendering render = new Rendering(print);
            Airspace airspace = new Airspace();
            Track newTrack = new Track();
            Track formerTrack = new Track();
            

            // Just display data
            foreach (var data in e.TransponderData)
            {
                newTrack = decrypt.decryptTrack(data.ToString());
                if (airspace.checkAirspace(newTrack) == true)
                    count.addTrack();
            }

            System.Console.Write("Number of Tracks: {0}\n", count.getTracks());

            foreach (var data in e.TransponderData)
            {
                formerTrack.Xcoor = formerX;
                formerTrack.Ycoor = formerY;

                formerX = newTrack.Xcoor;
                formerY = newTrack.Ycoor;

                newTrack = decrypt.decryptTrack(data.ToString());
                //if (airspace.checkAirspace(newTrack) == true)
                {
                    newTrack = decrypt.decryptTrackVelocity(formerTrack, newTrack);
                    render.TracksRender(newTrack);
                }
            }
        }
    }
}
