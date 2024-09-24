using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal sealed class Ravioli : Dumpling
    {
        //Текст восхищения итальянской кухней
        string raptureText;

        override public uint Size
        {
            get { return size; }
            set
            {
                if (!isCooked) size = value;
                else Console.WriteLine("К сожалению, изменить размер готового равиоли можно только съев его.");
            }
        }

        public Ravioli() : base()
        {
            size = 2;
            weight = 8;
            hasCoriander = false;
            raptureText = "La cucina italiana è davvero magnifica!";
        }

        public Ravioli(uint size, uint weight) : base(size, weight) { raptureText = "La cucina italiana è davvero magnifica!"; }
        public Ravioli(uint size, uint weight, string raptureText, bool hasCoriander) : base(size, weight, hasCoriander) { this.raptureText = raptureText; }

        override public bool Boil()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Ваш равиоли уже готов! Зачем Вам варить его ещё раз?");
                return false;
            }

            Random random = new Random(Environment.TickCount);
            int cookingSuccessChance = random.Next(1, 101);

            if (cookingSuccessChance > 5)
            {
                Console.WriteLine("Вы успешно сварили равиоли! Теперь вы можете его съесть!");
                isCooked = true;
                return true;
            }
            Console.WriteLine("Похоже, Ваш равиоли ещё не доварился. Попробуйте приготовить его ещё раз!");
            return false;
        }

        public override bool Eat()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Вы съели равиоли!");
                Console.WriteLine("Теперь его больше нет :(");

                Random random = new Random(Environment.TickCount);
                int eventChance = random.Next(1, 101);

                if (eventChance > 40)


                    GC.SuppressFinalize(this);
                GC.Collect();

                return true;
            }

            Console.WriteLine("Чтобы съесть равиоли сначала нужно его приготовить!");
            return false;
        }

        //Объявляет о Вашем неподдельном восхищении итальянской кухней
        public void AdmireItalianCuisine()
        {
            Console.WriteLine("Вас переполняет чувство восхищения итальянской кухней. Вам прямо так и хочется прокричать:");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\"");
            sb.AppendLine(raptureText);
            sb.AppendLine("\"");

            Console.WriteLine(sb.ToString());
        }
        public override void CheckContent()
        {
            Console.WriteLine($"Ваш равиоли весит {weight} грамм и составляет {size} сантиметров в высоту.");
            if (hasCoriander) Console.WriteLine("А ещё в нём есть ароматная кинза!");
            if (isCooked) Console.WriteLine("Самое время его съесть!");
            else Console.WriteLine("Самое время его приготовить!");
            Console.Write("Внезапно ");
            AdmireItalianCuisine();
        }

        public override uint GetCookingTime() { return 43; }
        public override string GetDishDescription()
        {
            return "Равио́ли (итал. ravioli) — итальянские макаронные изделия " +
                    "из теста с различной начинкой. Изготавливаются из пресного " +
                    "теста в виде полумесяца, эллипса или квадрата с фигурным " +
                    "обрезом края. Затем могут либо отвариваться, либо обжариваться " +
                    "в масле, во втором случае их подают к бульонам или супам. " +
                    "Начинка может быть мясной, рыбной, из птицы, овощей или фруктов.";
        }
        public override float GetRating() { return 9.6f; }
    }
}