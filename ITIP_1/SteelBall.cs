using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal class SteelBall: IRound
    {
        public double diameter { get { return 1.6; } }
        public SteelBall() { }
        public string Roll () { return "Шарик куда-то покатился..."; }
    }
}
