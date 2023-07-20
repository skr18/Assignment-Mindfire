public class Program
{
    public static void Main()
    {
        var x = 125;

        Console.Write(isOdd(x) ? "Even value" : "Odd value");
    }

    static bool isOdd(int x)
    {
        switch (x % 3)
        {
            case 0:
                return true;
            case 1:
                return false;
        }

        return false;
    }
}