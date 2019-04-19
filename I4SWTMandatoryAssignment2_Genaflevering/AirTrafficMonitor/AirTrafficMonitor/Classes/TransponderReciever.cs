using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    class TransponderReciever: iTransponderReciever
    {
        private iTransponderReciever receiver;

        static int[] formerX = new int[30];
        static int[] formerY = new int[30];
        static Track[] condition = new Track[30];
        static bool[] condiSet = new bool[50];

      
        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            System.Console.Clear();
            Counter count = new Counter();
            Decrypting decrypt = new Decrypting("");
            
            Rendering render = new Rendering();
            Airspace airspace = new Airspace();
            iTrack newTrack = new iTrack();
            iTrack formerTrack = new iTrack();
            iTrack centerPos = new iTrack()
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
                if (airspace.checkAirspace(newTrack) == true)
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
                            int set = 0;
                            while (condiSet[set] == true && set < count.getTracks())
                                set++;

                            if (condiSet[set] == false)
                            {
                                condition[set] = index[i];
                                condiSet[set] = true;
                            }


                            print.print("   Conflict between " + index[count.getTracks()].Tag + " & " + index[i].Tag +
                                "   " + condition[set].TimeStamp.Day + "/" + condition[set].TimeStamp.Month + "-" + condition[set].TimeStamp.Year +
                                " " + condition[set].TimeStamp.Hour + ":" + condition[set].TimeStamp.Minute + ":" + condition[set].TimeStamp.Second +
                                "." + condition[set].TimeStamp.Millisecond);
                        }
                    }
                    count.addTrack();
                }
            }
            System.Console.Write("Number of Tracks: {0}\n", count.getTracks());
        }
    }
}
