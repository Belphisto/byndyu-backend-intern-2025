
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        OutputEncoding = Encoding.UTF8;

        TestLargeInput();

        WriteLine("Введите массив чисел через пробел:");
        string? input = ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            WriteLine("Ошибка: входная строка пуста.");
            ReadKey();
            return;
        }
        try
        {
            var inputs = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            double result = Solver.Solve(inputs);
            WriteLine($"Сумма двух минимальных элементов: {result}");
        }
        catch (FormatException)
        {
            WriteLine("Ошибка: все элементы должны быть числами.");
        }
        catch (InvalidOperationException ex)
        {
            WriteLine($"Ошибка: {ex.Message}");
        }

        WriteLine("Нажмите любую клавишу для выхода...");
        ReadKey();
    }

    // замер времени на тестовый случай из условия: 100 млн. элементов.
    public static void TestLargeInput()
    {
        const int size = 100_000_000;
        var random = new Random();
        var inputs = new List<double>(size);

        // 100 млн случайных целых чисел
        for (int i = 0; i < size; i++)
        {
            inputs.Add(random.NextInt64(-1_000_000, 1_000_001));
        }

        var stopwatch = Stopwatch.StartNew();
        double result = Solver.Solve(inputs);
        stopwatch.Stop();
        WriteLine($"Тестовый сценарий на 100 млн сгенерированных элементов");
        WriteLine($"Сумма двух минимальных элементов: {result}");
        WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
    }

}