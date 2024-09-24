using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ITIP_1
{
    //Отвечает за меню управления различными классами еды и выполнение соответствующих действий через него
    internal class FoodManager
    {
        public FoodManager() { }

        public void TestKhinkali()
        {
            Khinkali? khinkali = null;

            uint choice = SuggestActionsKhinkali();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        khinkali = CreateKhinkali();
                        break;

                    case 2:
                        if (khinkali is null)
                        {
                            Console.WriteLine("Сначала хинкали нужно создать!");
                            break;
                        }
                        khinkali.CheckContent();
                        break;

                    case 3:
                        if (khinkali is null)
                        {
                            Console.WriteLine("Сначала хинкали нужно создать!");
                            break;
                        }
                        khinkali.Boil();
                        break;

                    case 4:
                        if (khinkali is null)
                        {
                            Console.WriteLine("Сначала хинкали нужно создать!");
                            break;
                        }
                        bool isEaten = khinkali.Eat();
                        if (isEaten) khinkali = null;
                        break;

                    case 5:
                        Khinkali.GetPerfectRecipe();
                        break;

                    case 0:
                        Console.WriteLine("Выход из программы...");
                        break;

                    default:
                        Console.WriteLine("Неизвестный пункт меню тестирования хинкали");
                        break;
                }
                choice = SuggestActionsKhinkali();
            }
        }
        public void TestHierarchy()
        {
            Dumpling? dumpling = null;

            uint choice = SuggestActionsHierarchy();

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        dumpling = CreateDumpling();
                        break;

                    case 2:
                        if (dumpling is null)
                        {
                            Console.WriteLine("Сначала дамплинг нужно создать!");
                            break;
                        }
                        dumpling.CheckContent();
                        break;

                    case 3:
                        if (dumpling is null)
                        {
                            Console.WriteLine("Сначала дамплинг нужно создать!");
                            break;
                        }
                        dumpling.Boil();
                        break;

                    case 4:
                        if (dumpling is null)
                        {
                            Console.WriteLine("Сначала дамплинг нужно создать!");
                            break;
                        }
                        bool isEaten = dumpling.Eat();
                        if (isEaten) dumpling = null;
                        break;

                    case 5:
                        if (dumpling is null)
                        {
                            Console.WriteLine("Сначала дамплинг нужно создать!");
                            break;
                        }
                        string type = dumpling.GetType().Name;
                        if (type == "Khinkali")
                        {
                            Khinkali.GetPerfectRecipe();
                        }
                        else if (type == "Pelmen")
                        {
                            Pelmen pelmen = (Pelmen)dumpling;
                            pelmen.Fry();
                        }
                        else if (type == "Ravioli")
                        {
                            Ravioli ravioli = (Ravioli)dumpling;
                            ravioli.AdmireItalianCuisine();
                        }
                        else if (type == "Varenik")
                        {
                            Varenik varenik = (Varenik)dumpling;
                            string quality = varenik.GetFillingQuality();
                            Console.WriteLine($"Вам кажется, что у этого вареника {quality} качество");
                        }
                        else Console.WriteLine("Ошибочка вышла");
                        break;
                    case 6:
                        if (dumpling is null)
                        {
                            Console.WriteLine("Сначала дамплинг нужно создать!");
                            break;
                        }
                        dumpling.GetClassName();
                        break;

                    case 0:
                        Console.WriteLine("Выход из программы...");
                        break;

                    default:
                        Console.WriteLine("Неизвестный пункт меню тестирования иерархии");
                        break;
                }
                choice = SuggestActionsHierarchy();
            }
        }
        public void TestInterface()
        {
            IEatable?[] eatables = new IEatable[7];
            Array.Fill(eatables, null);
            uint freePosition = 0;

            IEatable? chosenElement = ChooseInterfaceElement();
            uint choiceAction;

            eatables[ChoosePlace(eatables)] = chosenElement;

            while (chosenElement is not null)
            {
                choiceAction = SuggestActionsInterface();
                switch (choiceAction)
                {
                    case 1:
                        chosenElement = ChooseInterfaceElement();
                        eatables[ChoosePlace(eatables)] = chosenElement;
                        break;
                    case 2:
                        uint place = ChoosePlace(eatables);
                        if (eatables[place] is null) { Console.WriteLine("Ячейка пуста"); break; }
                        ShowCookingTime(eatables[place]);
                        break;
                    case 3:
                        place = ChoosePlace(eatables);
                        if (eatables[place] is null) { Console.WriteLine("Ячейка пуста"); break; }
                        ShowDishDescription(eatables[place]);
                        break;
                    case 4:
                        place = ChoosePlace(eatables);
                        if (eatables[place] is null) { Console.WriteLine("Ячейка пуста"); break; }
                        ShowDishRating(eatables[place]);
                        break;
                    case 5:
                        place = ChoosePlace(eatables);
                        if (eatables[place] is null) { Console.WriteLine("Ячейка пуста"); break; }
                        Console.WriteLine($"Производитель этого кулинарного шедевра - компания \"{eatables[place].manufacturerName}\"");
                        break;
                    default:
                        Console.WriteLine("Ошибка в осносном цикле");
                        break;
                }
            }
        }
        public uint SuggestActionsKhinkali()
        {
            string text = "\nВыберите действие с хинкали, которое вы хотите совершить:\n" +
                            "1. Создать новый\n" +
                            "2. Просмотреть характеристики\n" +
                            "3. Приготовить\n" +
                            "4. Съесть\n" +
                            "5. Получить идеальный рецепт\n" +
                            "0. Выйти из программы";
            Console.WriteLine(text);

            string? input;
            uint choice;

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choice) || (choice > 5));

            return choice;
        }

        public uint SuggestActionsHierarchy()
        {
            string text = "\nВыберите действие с дамплингом, которое вы хотите совершить:\n" +
                            "1. Создать новый\n" +
                            "2. Получить свойства\n" +
                            "3. Приготовить\n" +
                            "4. Съесть\n" +
                            "5. Выполнить уникальный метод\n" +
                            "6. Получить имя класса\n" +
                            "0. Выйти из программы";
            Console.WriteLine(text);

            string? input;
            uint choice;

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choice) || (choice > 6));

            return choice;
        }

        public uint SuggestActionsInterface()
        {
            string text = "\nВыберите действие с объектом интерфейса, которое вы хотите совершить:\n" +
                            "1. Создать новый\n" +
                            "2. Получить время приготовления блюда [реализация интерфейса]\n" +
                            "3. Получить описание блюда [реализация интерфейса]\n" +
                            "4. Получить рейтинг блюда [реализация интерфейса]\n" +
                            "5. Получить свойста(-о) блюда";
            Console.WriteLine(text);

            string? input;
            uint choice;

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choice) || (choice < 1) || (choice > 5));

            return choice;
        }

        public IEatable? ChooseInterfaceElement()
        {
            string text = "\nВыберите объект интерфейса, который Вы хотите добавить в список:\n" +
                            "1. Хинкали\n" +
                            "2. Пельмень\n" +
                            "3. Равиоли\n" +
                            "4. Вареник\n" +
                            "5. Пицца\n" +
                            "0. Выйти из программы";
            Console.WriteLine(text);

            string? input;
            uint choice;

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choice) || (choice > 5));

            switch (choice)
            {
                case 1:
                    return new Khinkali();
                case 2:
                    return new Pelmen();
                case 3:
                    return new Ravioli();
                case 4:
                    return new Varenik();
                case 5:
                    return new Pizza_pepperoni();
            }
            return null;
        }

        public uint ChoosePlace(IEatable?[] eatables)
        {
            Console.WriteLine("Ваш список:");
            uint i = 0;
            foreach (var e in eatables)
            {
                Console.Write($"[{i+1}]: ");
                Console.WriteLine(e == null ? "[ПУСТО]" : e.GetType().Name);
                i++;
            }
            Console.WriteLine("Выберите ячейку, с которой выполнить действие");
            string? input;
            uint choice;
            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choice) || (choice < 1) || (choice > 7));

            return choice - 1;
        }

        public Khinkali? CreateKhinkali()
        {
            string text = "Выберите вид конструктора, который вы хотите использовать:\n" +
                        "1. Базовый\n" +
                        "2. С частью аргументов\n" +
                        "3. Со всеми аргументами\n";
            Console.WriteLine(text);

            string? input;
            uint constructorChoice;

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out constructorChoice) || (constructorChoice < 1) || (constructorChoice > 3));

            switch (constructorChoice)
            {
                case 1:
                    return new Khinkali();
                case 2:
                    Console.WriteLine("Введите размер нового хинкали (в см)");
                    uint size;
                    do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                    Console.WriteLine("Введите массу нового хинкали (в граммах)");
                    uint weight;
                    do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                    return new Khinkali(size, weight);
                case 3:
                    Console.WriteLine("Введите размер нового хинкали (в см)");
                    do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                    Console.WriteLine("Введите массу нового хинкали (в граммах)");
                    do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                    Console.WriteLine("Выберите количество мяса в хинкали в % (1-99)");
                    uint meatAmount;
                    do { input = Console.ReadLine(); } while (!uint.TryParse(input, out meatAmount) || (meatAmount < 1) || (meatAmount > 99));

                    Console.WriteLine("Хотите ли вы добавить в хинкали кинзу? (y/n)");
                    bool hasCoriander = false;
                    do { input = Console.ReadLine(); } while ((input != "y") && (input != "Y") && (input != "n") && (input != "N"));
                    if (input == "y" || input == "Y") hasCoriander = true;

                    return new Khinkali(size, weight, meatAmount, hasCoriander);
            }
            return null;
        }

        public Dumpling? CreateDumpling()
        {
            uint choiceDumpling;
            uint choiceConstructor;
            string? input;

            string text = "Выберите вид дамплинга, который вы хотите использовать:\n" +
                        "1. Хинкали\n" +
                        "2. Пельмень\n" +
                        "3. Равиоли\n" +
                        "4. Вареник\n";
            Console.WriteLine(text);

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choiceDumpling) || (choiceDumpling < 1) || (choiceDumpling > 4));

            text = "Выберите вид конструктора, который вы хотите использовать:\n" +
                        "1. Базовый\n" +
                        "2. С частью аргументов\n" +
                        "3. Со всему аргументами\n";
            Console.WriteLine(text);

            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out choiceConstructor) || (choiceConstructor < 1) || (choiceConstructor > 3));

            switch (choiceDumpling)
            {
                case 1:
                    switch (choiceConstructor)
                    {
                        case 1:
                            return new Khinkali();
                        case 2:
                            Console.WriteLine("Введите размер нового хинкали (в см)");
                            uint size;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового хинкали (в граммах)");
                            uint weight;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            return new Khinkali(size, weight);
                        case 3:
                            Console.WriteLine("Введите размер нового хинкали (в см)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового хинкали (в граммах)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            Console.WriteLine("Выберите количество мяса в хинкали в % (1-99)");
                            uint meatAmount;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out meatAmount) || (meatAmount < 1) || (meatAmount > 99));

                            Console.WriteLine("Хотите ли вы добавить в хинкали кинзу? (y/n)");
                            bool hasCoriander = false;
                            do { input = Console.ReadLine(); } while ((input != "y") && (input != "Y") && (input != "n") && (input != "N"));
                            if (input == "y" || input == "Y") hasCoriander = true;

                            return new Khinkali(size, weight, meatAmount, hasCoriander);
                    }
                    break;
                case 2:
                    switch (choiceConstructor)
                    {
                        case 1:
                            return new Pelmen();
                        case 2:
                            Console.WriteLine("Введите размер нового пельменя (в см)");
                            uint size;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового пельменя (в граммах)");
                            uint weight;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            return new Pelmen(size, weight);
                        case 3:
                            Console.WriteLine("Введите размер нового пельменя (в см)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового пельменя (в граммах)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            Console.WriteLine("Хотите ли вы добавить в пельмень кинзу? (y/n)");
                            bool hasCoriander = false;
                            do { input = Console.ReadLine(); } while ((input != "y") && (input != "Y") && (input != "n") && (input != "N"));
                            if (input == "y" || input == "Y") hasCoriander = true;

                            return new Pelmen(size, weight, hasCoriander);
                    }
                    break;
                case 3:
                    switch (choiceConstructor)
                    {
                        case 1:
                            return new Ravioli();
                        case 2:
                            Console.WriteLine("Введите размер нового равиоли (в см)");
                            uint size;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового равиоли (в граммах)");
                            uint weight;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            return new Ravioli(size, weight);
                        case 3:
                            Console.WriteLine("Введите размер нового равиоли (в см)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового равиоли (в граммах)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            Console.WriteLine("Введите текст, которым вы хотите восхвалить итальянскую кухню");
                            string? raptureText;
                            do { raptureText = Console.ReadLine(); } while (raptureText is null);

                            Console.WriteLine("Хотите ли вы добавить в равиоли кинзу? (y/n)");
                            bool hasCoriander = false;
                            do { input = Console.ReadLine(); } while ((input != "y") && (input != "Y") && (input != "n") && (input != "N"));
                            if (input == "y" || input == "Y") hasCoriander = true;

                            return new Ravioli(size, weight, raptureText, hasCoriander);
                    }
                    break;
                case 4:
                    switch (choiceConstructor)
                    {
                        case 1:
                            return new Varenik();
                        case 2:
                            Console.WriteLine("Введите размер нового вареника (в см)");
                            uint size;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового вареника (в граммах)");
                            uint weight;
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            return new Varenik(size, weight);
                        case 3:
                            Console.WriteLine("Введите размер нового вареника (в см)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out size) || (size < 1));

                            Console.WriteLine("Введите массу нового вареника (в граммах)");
                            do { input = Console.ReadLine(); } while (!uint.TryParse(input, out weight) || (weight < 1));

                            Console.WriteLine("Введите желаемую начинку вареника:\n" +
                                            "1. Картошка\n" +
                                            "2. Капуста\n" +
                                            "3. Мясо");
                            Varenik.Filling filling;
                            do { input = Console.ReadLine(); } while (!Varenik.Filling.TryParse(input, out filling));

                            Console.WriteLine("Хотите ли вы добавить в вареник кинзу? (y/n)");
                            bool hasCoriander = false;
                            do { input = Console.ReadLine(); } while ((input != "y") && (input != "Y") && (input != "n") && (input != "N"));
                            if (input == "y" || input == "Y") hasCoriander = true;

                            return new Varenik(size, weight, filling, hasCoriander);
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестный пункт меню создания дамплинга");
                    break;
            }
            return null;
        }
        public void ShowCookingTime(IEatable eatable) { Console.WriteLine($"Время приготовления этого блюда составляет {eatable.GetCookingTime()} минут."); }
        public void ShowDishDescription(IEatable eatable) { Console.WriteLine(eatable.GetDishDescription()); }
        public void ShowDishRating(IEatable eatable) { Console.WriteLine($"Критики оценивают это блюдо на {eatable.GetRating()} из 10"); }

    }


}
