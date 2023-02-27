using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practises
{
    public class Computer
    {
        public int CountProccesors;
        internal int Ram;
        public string Os;
        internal double WAT;
        public double Flops;

        public void InitInfo()
        {
            CountProccesors = 10;
            Ram = 8192;
            Os = "Windows 11";
            WAT = 921.45;
            Flops = 1000.21;
        }

        internal string GetInfo()
        {
           return $"CountProccesors:{CountProccesors}\nRam:{Ram}\nOs:{Os}\nWAT:{WAT}\nFlops:{Flops}";
        }

        internal void ChangeOs(string Os)
        {
            this.Os = Os;
        }
    }
}
