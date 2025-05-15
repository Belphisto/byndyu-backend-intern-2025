using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class SolveTests
{
    [TestCase(new double[] { 4, 0, 3, 19, 492, -10, 1 }, ExpectedResult = -10)]
    [TestCase(new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = 3)]
    [TestCase(new double[] { -5, -2, -1, 0 }, ExpectedResult = -7)]
    [TestCase(new double[] { 100, 50, 50, 50 }, ExpectedResult = 100)]
    [TestCase(new double[] { 0, 0, 0, 0 }, ExpectedResult = 0)]
    [TestCase(new double[] { -5, 5 }, ExpectedResult = 0)]
    [TestCase(new double[] { 1.0, 1.0, 1.0, 2.0, 3.0 }, ExpectedResult = 2.0)]

    // тестирование граничных условий:
    [TestCase(new double[] { double.MinValue, double.MaxValue }, ExpectedResult = 0)]
    [TestCase(new double[] { double.MinValue, double.MinValue }, ExpectedResult = double.MinValue * 2)]
    public double TestSumTwoMinElements(double[] inputArray)
    {
        var list = new List<double>(inputArray);
        return Solver.Solve(list);
    }

    [Test]
    // Тест проверки условий: массив пустой или содержит меньше двух элементов
    public void Test_ThrowsException_WhenArrayHasLessThanTwoElements()
    {
        Assert.Throws<InvalidOperationException>(() => Solver.Solve(new List<string>()));
        Assert.Throws<InvalidOperationException>(() => Solver.Solve(new List<string> { "1" }));

        Assert.Throws<InvalidOperationException>(() => Solver.Solve(new List<double>()));
        Assert.Throws<InvalidOperationException>(() => Solver.Solve(new List<double> { 1 }));
    }

    [Test]
    // Тест проверки выброса исключения, если в строке на вход подаются некорректные данные
    public void Test_ThrowsFormatException_WhenInputContainsNonNumericStrings()
    {
        var invalidInput = new List<string> { "10", "abc", "5" };
        Assert.Throws<FormatException>(() => Solver.Solve(invalidInput));
    }
}
