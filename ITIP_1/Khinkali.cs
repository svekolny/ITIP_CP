using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    internal sealed class Khinkali: Dumpling
    {

        readonly public uint meatAmount;

        override public uint Size
        {
            get { return size; }
            set
            {
                if (!isCooked) size = value;
                else Console.WriteLine("К сожалению, изменить размер готового хинкали можно только съев его.");
            }
        }

        public Khinkali(): base()
        {
            size = 8;
            weight = 100;
            meatAmount = 80;
            hasCoriander = false;
        }

        public Khinkali(uint size, uint weight): base(size, weight)
        {
            Random random = new Random(Environment.TickCount);

            meatAmount = (uint)random.Next(1, 100);
            if (random.Next(1, 101) > 50) hasCoriander = true;
            else hasCoriander = false;
        }

        public Khinkali(uint size, uint weight, uint meatAmount, bool hasCoriander) : base(size, weight, hasCoriander)
        {
            if (meatAmount > 0 && meatAmount < 100) this.meatAmount = meatAmount; else this.meatAmount = 80;
        }

        override public bool Eat()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Вы съели этот хинкали!");
                Console.WriteLine("Теперь его больше нет :(");

                GC.SuppressFinalize(this);
                GC.Collect();

                return true;
            }

            Console.WriteLine("Чтобы съесть хинкали сначала нужно его приготовить!");
            return false;
        }

        override public bool Boil()
        {
            if (isCooked == true)
            {
                Console.WriteLine("Ваш хинкали уже готов! Зачем Вам готовить его ещё раз?");
                return false;
            }

            Random random = new Random(Environment.TickCount);
            int cookingSuccessChance = random.Next(1, 101);

            if (cookingSuccessChance > 30)
            {
                Console.WriteLine("Вы успешно приготовили хинкали! Теперь вы можете его съесть!");
                isCooked = true;
                return true;
            }
            Console.WriteLine("Похоже, Ваш хинкали ещё не доварился. Попробуйте приготовить его ещё раз!");
            return false;
        }

        override public void CheckContent()
        {
            Console.WriteLine($"Ваш хинкали весит {weight} грамм и составляет {size} сантиметров в высоту.");
            Console.WriteLine($"Ваш хинкали содержит {meatAmount} процентов мяса и {100 - meatAmount} процентов теста.");
            if (hasCoriander) Console.WriteLine("А ещё в нём есть ароматная кинза!");
            if (isCooked) Console.WriteLine("Самое время его съесть!");
            else Console.WriteLine("Самое время его приготовить!");
        }

        public static void GetPerfectRecipe()
        {
            string basePath = Environment.CurrentDirectory; // Получаем текущий рабочий каталог
            string filePath = Path.Combine(basePath, "..", "..", "..", "Content", "KhinkaliRecipe.txt"); // Построение относительного пути
            string recipeText = File.ReadAllText(filePath);
            Console.WriteLine(recipeText);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Хинкали: {weight} грамм, {size} см, ");
            if (isCooked) sb.Append("готов.");
            else sb.Append("не готов.");

            return sb.ToString();
        }

        public override uint GetCookingTime() { return 45; }
        public override string GetDishDescription()
        {
            return "Хинка́ли (груз. ხინკალი) — блюдо грузинской кухни из " +
                    "горных областей Пшави, Мтиулети и Хевсурети в Грузии, " +
                    "получившее распространение в других районах Кавказа и " +
                    "по всему бывшему СССР. Грузинские хинкали по составу " +
                    "и способу приготовления существенно отличаются от " +
                    "дагестанского и азербайджанского хинкала, который " +
                    "представляет собой иной тип блюда.";
        }
        public override float GetRating() { return 8.9f; }

        public static bool operator ==(Khinkali kh1, Khinkali kh2) { return kh1.weight == kh2.weight; }
        public static bool operator !=(Khinkali kh1, Khinkali kh2) { return kh1.weight != kh2.weight; }
        public static Khinkali operator +(Khinkali kh1, Khinkali kh2) { return new(kh1.size + kh2.size, kh1.weight + kh2.weight); }

    }
}
