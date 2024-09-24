using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal interface IEatable
    {
        public string manufacturerName { get; }
        abstract public uint GetCookingTime();
        abstract public string GetDishDescription();
        abstract public float GetRating();
    }
}
