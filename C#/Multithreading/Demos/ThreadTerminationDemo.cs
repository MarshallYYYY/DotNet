using System.Threading;

namespace Multithreading.Demos
{
    public static class ThreadTerminationDemo
    {
        private static bool isStop = false;
        /// <summary>
        /// 通过bool变量值的改变，来通知工作线程停止
        /// </summary>
        public static void ByBoolVariable()
        {
            ThreadLogger.WriteLine("主线程启动");

            Thread workerThread = new Thread(DoWork1);
            workerThread.Start();

            ThreadLogger.WriteLine("主线程等待 3 秒，然后通知工作线程停止");
            Thread.Sleep(3000);
            ThreadLogger.WriteLine("3秒已到，主线程通知工作线程停止");
            isStop = true;

            // 等待工作线程结束
            workerThread.Join();

            ThreadLogger.WriteLine("主线程：工作线程已经终止。");
        }
        private static void DoWork1()
        {
            ThreadLogger.WriteLine("工作线程：开始");
            while (isStop is false)
            {
                ThreadLogger.WriteLine("工作线程：正在工作...");
                Thread.Sleep(500); // 模拟工作
            }
            ThreadLogger.WriteLine("工作线程：准备停止。");
        }

        public static void ByCancellationToken()
        {
            ThreadLogger.WriteLine("主线程启动");
            CancellationTokenSource cts = new CancellationTokenSource();

            // 启动线程并传递 CancellationToken
            Thread workerThread = new Thread(() => DoWork2(cts.Token));
            workerThread.Start();

            ThreadLogger.WriteLine("主线程等待 3 秒，然后请求取消");
            Thread.Sleep(3000);
            ThreadLogger.WriteLine("3秒已到，主线程发出取消请求");
            cts.Cancel();

            // 等待线程结束
            workerThread.Join();
            ThreadLogger.WriteLine("主线程：工作线程已经终止。");
        }
        // 检查是否被要求取消
        private static void DoWork2(CancellationToken token)
        {
            ThreadLogger.WriteLine("工作线程：开始");
            while (token.IsCancellationRequested is false)
            {
                ThreadLogger.WriteLine("工作线程：正在工作...");
                Thread.Sleep(500); // 模拟工作
            }
            ThreadLogger.WriteLine("工作线程：准备停止。");
        }
    }
}
