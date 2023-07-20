using System;

public class Program
{
    static int counter = 0;
    string name = "Demo Program";

    public static void Main()
    {
        StopWatch sw1 = new StopWatch();
        StopWatch sw2 = new StopWatch();
        Console.WriteLine(StopWatch.NoOfInstances);

        StopWatch sw3 = new StopWatch();
        StopWatch sw4 = new StopWatch();
        Console.WriteLine(StopWatch.NoOfInstances);

    }

}

public class StopWatch
{
    public static int NoOfInstances = 0;

    public StopWatch()
    {
        StopWatch.NoOfInstances++;
    }
}
