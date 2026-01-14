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
            ThreadLogger.WriteLine("选择要执行的函数：");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=======");
            switch (choice)
            {
                case 1:
                    _ = FunBasic();
                    break;
                case 2:
                    FunTask();
                    break;
                case 3:
                    _ = FunAwait();
                    break;
            }
            Thread.Sleep(2000);

            Console.WriteLine("=======");
            ThreadLogger.WriteLine("Main函数结束");
        }
        private static async Task FunBasic()
        {
            // ①：线程1
            ThreadLogger.WriteLine("Start");
            // await 会让方法暂停，并在异步操作完成后从暂停点继续执行
            await Test();
            // ④：线程4
            ThreadLogger.WriteLine("End");

            async Task Test()
            {
                // ②：线程1
                ThreadLogger.WriteLine("Test() Start");
                await Task.Delay(1000);
                // Test() 方法中的 await 后面的代码是先恢复执行的
                // ③：线程4
                ThreadLogger.WriteLine("Test() End");
            }
        }
        private static void FunTask()
        {
            // ①：线程1
            ThreadLogger.WriteLine("主线程（线程1）开始");
            // 开启新线程
            Task task = Task.Run(() =>
            {
                // 切换到线程池线程
                for (int i = 0; i < 5; i++)
                {
                    // ③-⑦：线程3
                    ThreadLogger.WriteLine($"Task running: {i}");
                }
            });
            // ②：线程1
            ThreadLogger.WriteLine("主线程（线程1）阻塞等待新线程任务完成");
            task.Wait();
            // ⑧：线程1
            ThreadLogger.WriteLine("Task completed.");
        }
        private static async Task FunAwait()
        {
            // ①：线程1
            ThreadLogger.WriteLine("主线程（线程1）开始");
            await Task.Run(() =>
            {
                // 切换到线程池线程
                for (int i = 0; i < 5; i++)
                {
                    // ②-⑥：线程3
                    ThreadLogger.WriteLine($"Task running: {i}");
                }
            });
            // await 之后：尝试回到原始上下文
            // 但由于是控制台程序，没有SynchronizationContext
            // 所以可能继续在线程池线程执行！
            // 可能还是线程3

            // ⑦：线程3
            ThreadLogger.WriteLine("Task completed.");
        }
    }
}
