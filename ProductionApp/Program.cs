using System.Globalization;
using System.Text;
using CoreLib;
using WSUniversalLib;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

var calculation = new Calculation();
var utils = new Utils();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Производство ===");
    Console.WriteLine("1. Рассчитать количество сырья");
    Console.WriteLine("2. Сгенерировать номер заказа");
    Console.WriteLine("0. Выход");
    Console.Write("Выбор: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1": CalculateMaterials(); break;
        case "2": GenerateOrder(); break;
        case "0": return;
        default: Console.WriteLine("Неизвестный пункт меню."); break;
    }
}

void CalculateMaterials()
{
    int productType = ReadInt("Тип продукции (1-3): ");
    int materialType = ReadInt("Тип материала (1-2): ");
    int count = ReadInt("Количество продукции: ");
    float width = ReadFloat("Ширина: ");
    float length = ReadFloat("Длина: ");

    int result = calculation.GetQuantityForProduct(productType, materialType, count, width, length);

    Console.WriteLine(result == -1
        ? "Ошибка: переданы некорректные данные (результат -1)."
        : $"Необходимое количество сырья: {result}");
}

void GenerateOrder()
{
    Console.Write("Фамилия: ");
    string last = Console.ReadLine() ?? "";
    Console.Write("Имя: ");
    string first = Console.ReadLine() ?? "";
    Console.Write("Отчество (можно пропустить): ");
    string? patronymic = Console.ReadLine();

    try
    {
        var client = new Client(last, first, patronymic);
        Console.WriteLine($"Номер заказа: {utils.GenerateOrderNumber(client, DateTime.Now)}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int v))
            return v;
        Console.WriteLine("Введите целое число.");
    }
}

float ReadFloat(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string s = (Console.ReadLine() ?? "").Replace(',', '.');
        if (float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out float v))
            return v;
        Console.WriteLine("Введите число.");
    }
}
