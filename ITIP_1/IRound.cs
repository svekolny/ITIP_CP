using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal interface IRound
    {
        public double diameter { get; }
        public string Roll();
    }
}
