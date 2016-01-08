namespace ConsoleArrayPerformance
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Console application to test performance when using arrays
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of the console application
        /// </summary>
        /// <param name="args">String array</param>
        public static void Main(string[] args)
        {
            // Generate data
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
                    {
                        sum += data[c];
                    }
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