using System;
using System.Threading;

public class Program
{
    private static int count = 0;

    private static void IncrementCount()
    {
        int oldValue = Interlocked.CompareExchange(ref count, count + 1, count);
        if (oldValue != count)
        {
            Console.WriteLine("inc failed");
        }
    }

    public static void Main()
    {
        Thread thread1 = new Thread(IncrementCount);
        Thread thread2 = new Thread(IncrementCount);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine(count);
    }
}
