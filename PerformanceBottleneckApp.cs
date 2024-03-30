using System;
using System.Collections.Generic;

namespace PerformanceBottleneckApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify a mode: 'cpu' or 'memory'");
                return;
            }

            switch (args[0].ToLower())
            {
                case "cpu":
                    CreateCpuBottleneck();
                    break;
                case "memory":
                    CreateMemoryBottleneck();
                    break;
                default:
                    Console.WriteLine("Invalid mode. Please specify 'cpu' or 'memory'.");
                    break;
            }
        }

        static void CreateCpuBottleneck()
        {
            Console.WriteLine("Creating CPU bottleneck...");
            while (true)
            {
                // Perform a CPU-intensive task.
                double result = 0;
                for (int i = 1; i < 1000000; i++)
                {
                    result += Math.Sqrt(i) * Math.Tan(i);
                }
            }
        }

        static void CreateMemoryBottleneck()
        {
            Console.WriteLine("Creating memory bottleneck...");
            List<byte[]> memoryList = new List<byte[]>();
            while (true)
            {
                // Allocate 100 MB of memory repeatedly.
                byte[] buffer = new byte[100 * 1024 * 1024];
                memoryList.Add(buffer);

                System.Threading.Thread.Sleep(1000); // Slow down the allocation rate.
            }
        }
    }
}

