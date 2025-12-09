using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadLogger.WriteLine("Main函数开始");

            _ = FunBasic();
            //FunTask();
            //_ = FunAwait();
            Thread.Sleep(2000);

            ThreadLogger.WriteLine("Main函数结束");
        }
        private static async Task FunBasic()
        {
            // 线程1
            ThreadLogger.WriteLine("Start");
            await Test();
            // 线程4
            ThreadLogger.WriteLine("End");

            async Task Test()
            {
                // 线程1
                ThreadLogger.WriteLine("Test() Start");
                await Task.Delay(1000);
                // 线程4
                ThreadLogger.WriteLine("Test() End");
            }
        }
        private static void FunTask()
        {
            ThreadLogger.WriteLine("主线程（线程1）开始");
            // 开启新线程
            Task task = Task.Run(() =>
            {
                // 切换到线程池线程
                for (int i = 0; i < 5; i++)
                {
                    // 线程3
                    ThreadLogger.WriteLine($"Task running: {i}");
                }
            });
            ThreadLogger.WriteLine("主线程（线程1）阻塞等待新线程任务完成");
            task.Wait();
            // 线程1
            ThreadLogger.WriteLine("Task completed.");
        }
        private static async Task FunAwait()
        {
            ThreadLogger.WriteLine("主线程（线程1）开始");
            await Task.Run(() =>
            {
                // 切换到线程池线程
                for (int i = 0; i < 5; i++)
                {
                    // 线程3
                    ThreadLogger.WriteLine($"Task running: {i}");
                }
            });
            // await 之后：尝试回到原始上下文
            // 但由于是控制台程序，没有SynchronizationContext
            // 所以可能继续在线程池线程执行！
            // 可能还是线程3
            ThreadLogger.WriteLine("Task completed.");
        }
    }
}
