using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    abstract internal class Dumpling: IEatable
    {
        protected uint size;
        protected uint weight;
        protected bool isCooked;
        protected bool hasCoriander;

        public bool IsCooked { get { return isCooked; } }
        virtual public uint Weight { get { return weight; } }
        virtual public uint Size { get { return size; } set { size = value; } }
        virtual public bool HasCoriander { get { return hasCoriander; } }
        public string manufacturerName { get { return "Местный пельменный завод"; } }

        public Dumpling() { isCooked = false; }

        public Dumpling(uint size, uint weight) : this()
        {
            this.size = size;
            this.weight = weight;
        }

        public Dumpling (uint size, uint weight, bool hasCoriander): this(size, weight)
        {
            this.hasCoriander = hasCoriander;
        }

        public void GetClassName()
        {
            Console.WriteLine(this.GetType().Name);
        }

        abstract public bool Eat();
        abstract public bool Boil();
        abstract public void CheckContent();
        abstract public uint GetCookingTime();
        abstract public string GetDishDescription();
        abstract public float GetRating();
    }
}
