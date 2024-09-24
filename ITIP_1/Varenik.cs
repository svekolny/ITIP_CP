using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal sealed class Varenik : Dumpling
    {
        public enum Filling { Potato, Cabbage, Meat }
        Filling filling;

        override public uint Size
        {
            get { return size; }
            set
            {
                if (!isCooked) size = value;
                else Console.WriteLine("К сожалению, изменить размер готового вареника можно только съев его.");
            }
        }

        public Varenik() : base()
        {
            size = 3;
            weight = 25;
            hasCoriander = false;
            filling = Filling.Potato;
        }

        public Varenik(uint size, uint weight) : base(size, weight) { filling = Filling.Potato; }
        public Varenik(uint size, uint weight, Filling filling, bool hasCoriander) : base(size, weight, hasCoriander) { this.filling = filling; }

        override public bool Boil()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Ваш вареник уже готов! Зачем Вам варить его ещё раз?");
                return false;
            }

            Random random = new Random(Environment.TickCount);
            int cookingSuccessChance = random.Next(1, 101);

            if (cookingSuccessChance > 10)
            {
                Console.WriteLine("Вы успешно сварили вареник! Теперь вы можете его съесть!");
                isCooked = true;
                return true;
            }
            Console.WriteLine("Похоже, Ваш вареник ещё не доварился. Попробуйте приготовить его ещё раз!");
            return false;
        }
        public string GetFillingQuality()
        {
            Random random = new Random(Environment.TickCount);
            int fillingQuality = random.Next(1, 101);
            if (fillingQuality < 20) return "плохое";
            else if (fillingQuality < 80) return "нормальное";
            return "хорошее";
        }

        public override bool Eat()
        {
            if (isCooked == true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Вы съели вареник с ");
                if (filling == Filling.Meat) sb.Append("мясом");
                else if (filling == Filling.Potato) sb.Append("картошкой");
                else sb.Append("капустой");

                Console.WriteLine(sb.ToString());
                Console.WriteLine("Теперь его больше нет :(");

                Random random = new Random(Environment.TickCount);
                int eventChance = random.Next(1, 101);

                if (GetFillingQuality() == "хорошее") Console.WriteLine("Вам очень понравилось!");

                GC.SuppressFinalize(this);
                GC.Collect();

                return true;
            }

            Console.WriteLine("Чтобы съесть вареник сначала нужно его приготовить!");
            return false;
        }
        public override void CheckContent()
        {
            Console.WriteLine($"Ваш вареник весит {weight} грамм и составляет {size} сантиметров в высоту.");
            Console.Write($"А ещё в нём начинка из ");
            if (filling == Filling.Potato) Console.WriteLine("картофеля");
            else if (filling == Filling.Cabbage) Console.WriteLine("капусты");
            else Console.WriteLine("мяса");
            if (hasCoriander) Console.WriteLine("А ещё в нём есть ароматная кинза!");
            if (isCooked) Console.WriteLine("Самое время его съесть!");
            else Console.WriteLine("Самое время его приготовить!");
        }

        public override uint GetCookingTime() { return 90; }
        public override string GetDishDescription()
        {
            return "Варе́ники (укр. вареники, [ʋɐˈrɛneke]) — украинское" +
                    "национальное блюдо в виде отварных изделий из пресного " +
                    "теста с начинкой из отварного мяса, овощей, грибов, фруктов, " +
                    "творога, картофеля и ягод. Вареники в XIX веке были известны " +
                    "также крестьянам Курской губернии. Сходно с марийским " +
                    "блюдом подкогыльо. Ленивые вареники могут рассматриваться " +
                    "как разновидность обычных вареников, не требующая долгой " +
                    "лепки, либо как отдельное блюдо. Для их приготовления начинку " +
                    "(чаще всего творог) смешивают с тестом, затем раскатывают в " +
                    "жгут и нарезают как на галушки, после чего варят.";
        }
        public override float GetRating() { return 8.9f; }

    }
}
