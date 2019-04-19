using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    class Decrypting: iDecrypting
    {
        private iTransponderReciever TransponderRecive = new iTransponderReciever();

        public Decrypting(string data)
        {

        }

        public TransponderReciever Getx(string currentTrack)
        {
            var track = new iTrack();
        }
    }
}
