using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal class Pizza_pepperoni: IEatable
    {
        public string manufacturerName { get { return "Папа Карло"; } }
        public uint GetCookingTime() {  return 25; }
        public string GetDishDescription()
        {
            return "Пи́цца (итал. pizza) — традиционное итальянское блюдо," +
                    "изначально в виде круглой дрожжевой лепёшки, выпекаемой " +
                    "с уложенной сверху начинкой из томатного соуса, сыра и " +
                    "зачастую других ингредиентов, таких как мясо, овощи, " +
                    "грибы и прочие продукты. Небольшую пиццу иногда называют " +
                    "пиццеттой. Повар, специализирующийся на приготовлении " +
                    "пиццы, — пиццайоло.";
        }
        public float GetRating() { return 9.5f; }
    }
}
