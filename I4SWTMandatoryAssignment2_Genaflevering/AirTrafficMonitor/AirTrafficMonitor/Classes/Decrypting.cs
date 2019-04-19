using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Classes;

namespace AirTrafficMonitor
{
    public class Decrypting: iDecrypting
    {
        iTransponderReciever TransponderRecive = new iTransponderReciever();

        Track iDecrypting.decryptTrack(string);

        public Decrypting()
        {

        }

        public Decrypting(string data)
        {
            
        }

        public TransponderReciever Getx(string currentTrack)
        {
            var track = new iTrack();
        }
    }
}
