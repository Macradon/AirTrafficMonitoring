﻿using System;
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
            Track centerPos = new Track()
            {
                Xcoor = (airspace.neCornerX - airspace.swCornerX) / 2,
                Ycoor = (airspace.neCornerY - airspace.swCornerY) / 2
            };
            

            // Just display data
            Track[] index = new Track[50];
            for (int i = 0; i < 50; i++)
                index[i] = decrypt.decryptTrack("000000;0000;0000;0000;20190321123456789");


            foreach (var data in e.TransponderData)
            {
                index[count.getTracks()] = newTrack;

                formerTrack.Xcoor = formerX;
                formerTrack.Ycoor = formerY;

                formerX = newTrack.Xcoor;
                formerY = newTrack.Ycoor;

                newTrack = decrypt.decryptTrack(data);
                if (airspace.checkAirspace(newTrack) == true)
                {
                    count.addTrack();
                    newTrack = decrypt.decryptTrackVelocity(formerTrack, newTrack);
                    newTrack = decrypt.decryptTrackCompass(centerPos, newTrack);
                    render.TracksRender(newTrack);
                    for (int i = 1; i < count.getTracks(); i++)
                    {
                        if (newTrack.checkConflict(index[count.getTracks() - 1], index[i - 1]) == false)
                            print.print("   Conflict between " + index[count.getTracks() - 1].Tag + " & " + index[i - 1].Tag +
                                "   " + index[i-1].TimeStamp.Day + "/" + index[i - 1].TimeStamp.Month + "-" + index[i - 1].TimeStamp.Year +
                                " " + index[i - 1].TimeStamp.Hour + ":" + index[i - 1].TimeStamp.Minute + ":" + index[i - 1].TimeStamp.Second +
                                "." + index[i - 1].TimeStamp.Millisecond);
                    }
                }
            }
            System.Console.Write("Number of Tracks: {0}\n", count.getTracks());
        }
    }
}
