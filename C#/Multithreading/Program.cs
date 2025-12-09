using Multithreading.Demos;
using System;

namespace Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    ThreadBasicDemo.MakeDinner();
                    break;

                case 11:
                    ThreadPoolDemo.OneWork();
                    break;
                case 12:
                    ThreadPoolDemo.MultipleWork();
                    break;

                case 21:
                    ThreadTerminationDemo.ByBoolVariable();
                    break;
                case 22:
                    ThreadTerminationDemo.ByCancellationToken();
                    break;

                case 31:
                    ThreadSynchronizationDemo.ByLock();
                    break;
                case 32:
                    ThreadSynchronizationDemo.ByMonitor();
                    break;
                case 33:
                    ThreadSynchronizationDemo.ByMutex();
                    break;
                case 39:
                    ThreadSynchronizationDemo.ByMutex2();
                    break;
                case 34:
                    ThreadSynchronizationDemo.BySemaphore();
                    break;
                case 35:
                    ThreadSynchronizationDemo.ByAutoResetEvent();
                    break;

                default:
                    break;
            }
        }
    }
}