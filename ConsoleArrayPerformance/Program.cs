namespace ConsoleArrayPerformance
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 32768;
            int[] data = new int[arraySize];
            Random random = new Random(0);

            for (int c = 0; c < arraySize; c++)
            {
                data[c] = random.Next() % 256;
            }

            // With this, the next loop runs faster
            Array.Sort(data);

            // Test 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long sum = 0;

            for (int i = 0; i < 100000; ++i)
            {
                // Primary loop
                for (int c = 0; c < arraySize; c++)
                {
                    if (data[c] >= 128)
                        sum += data[c];
                }
            }

            stopWatch.Stop();

            if (!stopWatch.IsRunning)
            {
                Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds.ToString());
                Console.WriteLine("sum = " + sum);
            }
        }
    }
}