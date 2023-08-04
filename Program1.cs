using System;
using System.Threading;

public class Program
{
    private static int count = 0;
    private static int version = 0;

    private static void IncrementCount()
    {
        int oldVersion = version;
        int oldCount = count;

        // Try to increment the count and update the version.
        if (Interlocked.CompareExchange(ref count, oldCount + 1, oldCount) == oldCount)
        {
            version++;
        }
        else
        {
            // The count was updated by another thread.
            // Do nothing.
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
        Console.WriteLine(version);
    }
}
