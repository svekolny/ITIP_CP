
using ITIP_1;

Console.WriteLine("Выберите, что будет демонстрировать программа:");
Console.WriteLine("1. Задание 1 - Отдельный класс");
Console.WriteLine("2. Задание 2 - Иерархия классов");
Console.WriteLine("3. Задание 3 - Интерфейс и его реализация");
Console.WriteLine("Введите выбранный вариант программы");

uint verChoice;
string? input;
do { input = Console.ReadLine();} while (!uint.TryParse(input, out verChoice) || (verChoice < 1) || (verChoice > 3));

FoodManager manager = new FoodManager();

switch (verChoice)
{
    case 1:
        Console.WriteLine("Тестирование класса Хинкали...");
        manager.TestKhinkali();
        break;

    case 2:
        Console.WriteLine("Тестирование Иерархии классов...");
        manager.TestHierarchy();
        break;

    case 3:
        Console.WriteLine("Тестирование Интерфейса...");
        manager.TestInterface();
        break;

    default:
        Console.WriteLine("Неизвестный пункт меню");
        break;
}
