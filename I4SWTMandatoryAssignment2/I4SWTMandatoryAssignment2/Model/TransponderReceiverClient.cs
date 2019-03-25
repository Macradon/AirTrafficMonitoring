using System;
using TransponderReceiver;
using I4SWTMandatoryAssignment2.Model;
using I4SWTMandatoryAssignment2;

namespace TransponderReceiverUser
{
    public class TransponderReceiverClient
    {
        private ITransponderReceiver receiver;

        static int[] formerX = new int[30];
        static int[] formerY = new int[30];

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
            Track centerPos = new Track()
            {
                Xcoor = (airspace.neCornerX - airspace.swCornerX) / 2,
                Ycoor = (airspace.neCornerY - airspace.swCornerY) / 2
            };
            

            // Just display data
            Track[] index = new Track[30];
            

            for (int i = 0; i < 30; i++)
            {
                index[i] = decrypt.decryptTrack("000000;0000;0000;0000;20190321000000000");
            }


            foreach (var data in e.TransponderData)
            {
                newTrack = decrypt.decryptTrack(data);
                //if (airspace.checkAirspace(newTrack) == true)
                {
                    formerTrack.Xcoor = formerX[count.getTracks()];
                    formerTrack.Ycoor = formerY[count.getTracks()];

                    formerX[count.getTracks()] = newTrack.Xcoor;
                    formerY[count.getTracks()] = newTrack.Ycoor;

                    newTrack = decrypt.decryptTrackVelocity(formerTrack, newTrack);
                    newTrack = decrypt.decryptTrackCompass(centerPos, newTrack);
                    render.TracksRender(newTrack);
                    index[count.getTracks()] = newTrack;
                    for (int i = 0; i < count.getTracks(); i++)
                    {
                        if (newTrack.checkConflict(index[count.getTracks() - 1], index[i]) == true)
                        {
                            print.print("   Conflict between " + index[count.getTracks()].Tag + " & " + index[i].Tag +
                                "   " + index[i].TimeStamp.Day + "/" + index[i].TimeStamp.Month + "-" + index[i].TimeStamp.Year +
                                " " + index[i].TimeStamp.Hour + ":" + index[i].TimeStamp.Minute + ":" + index[i].TimeStamp.Second +
                                "." + index[i].TimeStamp.Millisecond);
                        }
                    }
                    count.addTrack();
                }   
            }
            System.Console.Write("Number of Tracks: {0}\n", count.getTracks());
        }
    }
}
