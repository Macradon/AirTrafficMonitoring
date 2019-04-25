using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor
{
    public class Print : iPrint
    {
        public void print(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Clear()
        {

            Console.Clear();
        }

    }
}
