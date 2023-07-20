using System;

public class Program
{
    public static void Main()
    {
        var result = Calculator.Sum(10, 25); // calling static method
        Calculator.Store(result);
        Console.WriteLine(result);

        var calcType = Calculator.Type; // accessing static variable
        Calculator.Type = "Scientific"; // assign value to static variable
        Calculator.display();
    }
}

public static class Calculator
{
    private static int _resultStorage = 0;

    public static string Type = "Arithmetic";

    public static int Sum(int num1, int num2)
    {
        return num1 + num2;
    }

    public static void Store(int result)
    {
        _resultStorage = result;
    }
    public static void display()
    {
        Console.WriteLine(Type + " " + _resultStorage);
    }
}
