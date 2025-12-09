using System.Threading;

namespace Multithreading.Demos
{
    public static class ThreadPoolDemo
    {
        /// <summary>
        /// 向线程池中排入一个工作
        /// </summary>
        public static void OneWork()
        {
            ThreadLogger.WriteLine("主线程开始");
            // 将工作任务提交给线程池
            bool isQueue = ThreadPool.QueueUserWorkItem(Work1);
            ThreadLogger.WriteLine(isQueue.ToString());
            ThreadLogger.WriteLine("主线程继续执行...");
            ThreadLogger.WriteLine("主线程等待子线程3s");
            // 等待子线程完成
            Thread.Sleep(3000);
            ThreadLogger.WriteLine("主线程结束");
        }
        private static void Work1(object state)
        {
            ThreadLogger.WriteLine("线程池线程开始工作（需2s）");
            Thread.Sleep(2000);
            ThreadLogger.WriteLine("线程池线程工作完成！");
        }
        /// <summary>
        /// 向线程池中排入多个工作
        /// </summary>
        public static void MultipleWork()
        {
            ThreadLogger.WriteLine("主线程开始");

            // 向线程池提交任务
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(Work2, i + 1);
            }

            ThreadLogger.WriteLine("主线程等待2s以确保所有线程池任务完成");
            Thread.Sleep(2000);

            ThreadLogger.WriteLine("主线程结束");
        }
        private static void Work2(object state)
        {
            int taskNum = (int)state;
            ThreadLogger.WriteLine($"Task {taskNum} 开始");

            // 模拟任务处理
            Thread.Sleep(1000);

            ThreadLogger.WriteLine($"Task {taskNum} 结束");
        }
    }
}