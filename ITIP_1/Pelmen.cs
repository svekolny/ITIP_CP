using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal sealed class Pelmen : Dumpling
    {
        bool isFried;

        override public uint Size
        {
            get { return size; }
            set
            {
                if (!isCooked) size = value;
                else Console.WriteLine("К сожалению, изменить размер готового пельменя можно только съев его.");
            }
        }

        public Pelmen() : base()
        {
            size = 3;
            weight = 15;
            hasCoriander = false;
            isFried = false;
        }

        public Pelmen(uint size, uint weight) : base(size, weight) { isFried = false; }
        public Pelmen(uint size, uint weight, bool hasCoriander) : base(size, weight, hasCoriander) { isFried = false; }

        override public bool Boil()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Ваш пельмень уже готов! Зачем Вам варить его ещё раз?");
                return false;
            }

            Random random = new Random(Environment.TickCount);
            int cookingSuccessChance = random.Next(1, 101);

            if (cookingSuccessChance > 15)
            {
                Console.WriteLine("Вы успешно сварили пельмень! Теперь вы можете его съесть!");
                isCooked = true;
                return true;
            }
            Console.WriteLine("Похоже, Ваш пельмень ещё не доварился. Попробуйте приготовить его ещё раз!");
            return false;
        }

        public bool Fry()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Ваш пельмень уже готов! Зачем Вам жарить его ещё раз?");
                return false;
            }

            Random random = new Random(Environment.TickCount);
            int cookingSuccessChance = random.Next(1, 101);

            if (cookingSuccessChance > 15)
            {
                Console.WriteLine("Вы успешно пожарили пельмень! Теперь вы можете его съесть!");
                isCooked = true;
                isFried = true;
                return true;
            }
            Console.WriteLine("Похоже, Ваш пельмень ещё не дожарился. Попробуйте приготовить его ещё раз!");
            return false;
        }

        public override bool Eat()
        {
            if (isCooked == true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Вы съели этот ");
                if (isFried == true) sb.Append("жареный");
                else sb.Append("варёный");
                sb.Append(" пельмень!");

                Console.WriteLine(sb.ToString());
                Console.WriteLine("Теперь его больше нет :(");

                Random random = new Random(Environment.TickCount);
                int eventChance = random.Next(1, 101);

                if (eventChance < 20) Console.WriteLine("Вы обожгли язык! Впредь будьте аккуратнее!");

                GC.SuppressFinalize(this);
                GC.Collect();

                return true;
            }

            Console.WriteLine("Чтобы съесть пельмень сначала нужно его приготовить!");
            return false;
        }

        public override void CheckContent()
        {
            Console.WriteLine($"Ваш пельмень весит {weight} грамм и составляет {size} сантиметров в высоту.");
            if (hasCoriander) Console.WriteLine("А ещё в нём есть ароматная кинза!");
            if (isCooked && isFried) Console.WriteLine("Этот пельмень был пожарен! Самое время его съесть!");
            else if (isCooked) Console.WriteLine("Этот пельмень был сварен! Самое время его съесть!");
            else Console.WriteLine("Самое время его приготовить!");
        }
        public override uint GetCookingTime() { return 90; }
        public override string GetDishDescription()
        {
            return "Пельме́ни (ед. ч. пельме́нь, от коми пель нянь «хлебное ухо»)" +
                   " — блюдо русской кухни из пресного теста с начинкой из рубленого " +
                    "мяса, употребляемое в варёном виде. Было заимствовано русскими " +
                    "жителями Прикамья, Урала и Сибири у финно-угорских народов, " +
                    "получив широкое распространение в русской и советской кухнях.";
        }
        public override float GetRating() { return 10.0f; }
    }
}
