using Multithreading.Demos;
using System;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                $"1. {nameof(FunThreadBasicDemo)}\n" +
                $"2. {nameof(FunThreadPoolDemo)}\n" +
                $"3. {nameof(FunThreadTerminationDemo)}\n" +
                $"4. {nameof(FunThreadSynchronizationDemo)}"
                );
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    FunThreadBasicDemo();
                    break;
                case 2:
                    FunThreadPoolDemo();
                    break;
                case 3:
                    FunThreadTerminationDemo();
                    break;
                case 4:
                    FunThreadSynchronizationDemo();
                    break;

                default:
                    break;
            }
        }
        // 1
        private static void FunThreadBasicDemo()
        {
            Console.WriteLine(
                $"1. {nameof(ThreadBasicDemo.MakeDinner)}");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    ThreadBasicDemo.MakeDinner();
                    break;
            }
        }
        // 2
        private static void FunThreadPoolDemo()
        {
            Console.WriteLine(
                $"1. {nameof(ThreadPoolDemo.OneWork)}\n" +
                $"2. {nameof(ThreadPoolDemo.MultipleWork)}");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    ThreadPoolDemo.OneWork();
                    break;
                case 2:
                    ThreadPoolDemo.MultipleWork();
                    break;
            }
        }
        // 3
        private static void FunThreadTerminationDemo()
        {
            Console.WriteLine(
                $"1. {nameof(ThreadTerminationDemo.ByBoolVariable)}\n" +
                $"2. {nameof(ThreadTerminationDemo.ByCancellationToken)}");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    ThreadTerminationDemo.ByBoolVariable();
                    break;
                case 2:
                    ThreadTerminationDemo.ByCancellationToken();
                    break;
            }
        }
        // 4
        private static void FunThreadSynchronizationDemo()
        {
            Console.WriteLine(
                $"11. {nameof(ThreadSynchronizationDemo.ByLock)}\n" +
                $"12. {nameof(ThreadSynchronizationDemo.ByLock2)}\n" +

                $"21. {nameof(ThreadSynchronizationDemo.ByMonitor)}\n" +
                $"22. {nameof(ThreadSynchronizationDemo.ByMonitor2)}\n" +

                $"31. {nameof(ThreadSynchronizationDemo.ByMutex)}\n" +
                $"32. {nameof(ThreadSynchronizationDemo.ByMutex2)}\n" +

                $"41. {nameof(ThreadSynchronizationDemo.BySemaphore)}\n" +

                $"51. {nameof(ThreadSynchronizationDemo.ByAutoResetEvent)}\n" +

                $"61. {nameof(ThreadSynchronizationDemo.ByManualResetEvent)}"
                );
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 11:
                    ThreadSynchronizationDemo.ByLock();
                    break;
                case 12:
                    ThreadSynchronizationDemo.ByLock2();
                    break;

                case 21:
                    ThreadSynchronizationDemo.ByMonitor();
                    break;
                case 22:
                    ThreadSynchronizationDemo.ByMonitor2();
                    break;

                case 31:
                    ThreadSynchronizationDemo.ByMutex();
                    break;
                case 32:
                    ThreadSynchronizationDemo.ByMutex2();
                    break;

                case 41:
                    ThreadSynchronizationDemo.BySemaphore();
                    break;

                case 51:
                    ThreadSynchronizationDemo.ByAutoResetEvent();
                    break;

                case 61:
                    ThreadSynchronizationDemo.ByManualResetEvent();
                    break;
            }
        }

    }
}