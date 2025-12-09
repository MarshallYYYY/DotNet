using System.Threading;

namespace Multithreading.Demos
{
    public static class ThreadBasicDemo
    {
        public static void MakeDinner()
        {
            ThreadLogger.WriteLine("开始制作晚餐！");

            // 创建一个线程执行煮米饭任务
            Thread cookRiceThread = new Thread(CookRice);
            // 创建一个线程执行炒菜任务
            Thread fryVegetablesThread = new Thread(FryVegetables);

            // 启动线程
            cookRiceThread.Start();
            fryVegetablesThread.Start();

            // 等待两个线程完成
            // 如果不加这两行代码，会直接输出最后面的信息，
            // 然后等待两个子线程结束（因为默认是前台线程）。
            cookRiceThread.Join();
            fryVegetablesThread.Join();

            ThreadLogger.WriteLine("晚餐准备好了！");
        }
        private static void CookRice()
        {
            ThreadLogger.WriteLine("开始煮米饭...（需要3秒）");
            // 假装煮米饭需要3秒钟
            // Thread.Sleep() 不会创建新线程
            Thread.Sleep(3000);
            ThreadLogger.WriteLine("米饭煮好了！");
        }
        private static void FryVegetables()
        {
            ThreadLogger.WriteLine("开始炒菜...（需要2秒）");
            // 假装炒菜需要2秒钟
            Thread.Sleep(2000);
            ThreadLogger.WriteLine("菜炒好了！");
        }
    }
}
