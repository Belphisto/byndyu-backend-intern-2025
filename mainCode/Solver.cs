public class Solver
{
    /// <summary>
    /// Парсит строки в числа и вызывает Solve(List<double>).
    /// </summary>
    /// <param name="inputs">Список строк, каждая из которых должна быть числом.</param>
    /// <returns>Сумма двух минимальных чисел.</returns>
    /// <exception cref="FormatException">Если хотя бы одна строка не является числом.</exception>
    /// <exception cref="InvalidOperationException">Если список пуст или содержит менее двух числовых элементов.</exception>
    public static double Solve(List<string> inputs)
    {
        if (inputs == null || inputs.Count < 2)
            throw new InvalidOperationException("Массив должен содержать как минимум два элемента.");

        var numbers = new List<double>();

        foreach (var s in inputs)
        {
            if (!double.TryParse(s, out double num))
                throw new FormatException($"Невозможно преобразовать '{s}' в число.");
            numbers.Add(num);
        }

        return Solve(numbers);
    }

    /// <summary>
    /// Возвращает сумму двух минимальных чисел из переданного списка.
    /// </summary>
    /// <param name="numbers">Список чисел.</param>
    /// <returns>Сумма двух минимальных чисел.</returns>
    /// <exception cref="InvalidOperationException">Если список пуст или содержит менее двух чисел.</exception>
    public static double Solve(List<double> numbers)
    {
        if (numbers == null || numbers.Count < 2)
            throw new InvalidOperationException("Массив должен содержать как минимум два числа.");

        double min1 = double.PositiveInfinity;
        double min2 = double.PositiveInfinity;

        foreach (var num in numbers)
        {
            if (num < min1)
            {
                min2 = min1;
                min1 = num;
            }
            else if (num < min2)
            {
                min2 = num;
            }
        }

        return min1 + min2;
    }
}
