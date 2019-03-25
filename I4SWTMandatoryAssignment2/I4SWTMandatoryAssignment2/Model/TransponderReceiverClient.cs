using System;
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
        private bool[] condition = new bool[20] { false, false, false, false, false, false, false, false, false, false,
                                                  false, false, false, false, false, false, false, false, false, false };

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
            Track[] index = new Track[20];
            Track[] conditions = new Track[20];
            
            for (int i = 0; i < 20; i++)
            {
                index[i] = decrypt.decryptTrack("000000;0000;0000;0000;20190321000000000");
                conditions[i] = decrypt.decryptTrack("000000;0000;0000;0000;20190321000000000");
            }


            foreach (var data in e.TransponderData)
            {
                

                formerTrack.Xcoor = formerX;
                formerTrack.Ycoor = formerY;

                formerX = newTrack.Xcoor;
                formerY = newTrack.Ycoor;

                newTrack = decrypt.decryptTrack(data);
                //if (airspace.checkAirspace(newTrack) == true)
                {
                    
                    newTrack = decrypt.decryptTrackVelocity(formerTrack, newTrack);
                    newTrack = decrypt.decryptTrackCompass(centerPos, newTrack);
                    render.TracksRender(newTrack);
                    index[count.getTracks()] = newTrack;
                    for (int i = 0; i < count.getTracks(); i++)
                    {
                        if (newTrack.checkConflict(index[count.getTracks() - 1], index[i + 1]) == true)
                        {
                            if (condition[i] == false)
                            {
                                conditions[i].TimeStamp = index[i].TimeStamp;
                                condition[i] = true;
                            }
                            print.print("   Conflict between " + index[count.getTracks() - 0].Tag + " & " + index[i].Tag +
                                "   " + conditions[i].TimeStamp.Day + "/" + conditions[i].TimeStamp.Month + "-" + conditions[i].TimeStamp.Year +
                                " " + conditions[i].TimeStamp.Hour + ":" + conditions[i].TimeStamp.Minute + ":" + conditions[i].TimeStamp.Second +
                                "." + conditions[i].TimeStamp.Millisecond);
                        }
                        else
                        {
                            condition[i] = false;
                        }
                    }
                    count.addTrack();
                }   
            }
            System.Console.Write("Number of Tracks: {0}\n", count.getTracks());
        }
    }
}
