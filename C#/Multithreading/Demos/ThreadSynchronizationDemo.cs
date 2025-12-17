using System;
using System.Threading;

namespace Multithreading.Demos
{
    public static class ThreadSynchronizationDemo
    {
        #region lock
        /// <summary>
        /// 一个锁对象，用于线程同步，确保同一时间只有一个线程可以进入锁定代码块
        /// </summary>
        private static readonly object _lock1 = new object();
        /// <summary>
        /// 共享的计数器变量，用于多线程访问和修改
        /// </summary>
        private static int _counter1 = 0;
        public static void ByLock()
        {
            // 创建两个线程，指定它们执行相同的方法 IncrementCounter1
            Thread thread1 = new Thread(IncrementCounter1);
            Thread thread2 = new Thread(IncrementCounter1);

            // 启动线程，开始执行 IncrementCounter1 方法
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            // 所有线程执行完毕后，输出最终的计数器值
            ThreadLogger.WriteLine($"最终计数器的值: {_counter1}");
        }
        /// <summary>
        /// 线程将要执行的方法，用于增加计数器的值
        /// </summary>
        static void IncrementCounter1()
        {
            // 循环n次，每次循环都将计数器加1
            for (int i = 0; i < Math.Pow(10, 6); i++)
            {
                // 锁定代码块，确保在同一时刻只有一个线程可以执行这段代码
                // 这样可以防止多个线程同时修改计数器，导致数据不一致
                lock (_lock1)
                {
                    _counter1++;
                    // ThreadLogger.ThreadLogger.WriteLine 内部有锁, 这个锁实际上意外地同步了你的线程。
                    // I/O操作会隐藏多线程bug - 这是典型的"海森堡bug"
                    // 所以不要打印过程中的counter：
                    //ThreadLogger.WriteLine(Thread.CurrentThread.ManagedThreadId + "  " + _counter1);
                }
            }
        }
        public static void ByLock2()
        {
            Thread thread1 = new Thread(ShowIndex1);
            Thread thread2 = new Thread(ShowIndex1);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
        static void ShowIndex1()
        {
            // 不加锁的时候，两个线程交替打印；
            // 加锁后，一个线程打印完成后，另外一个线程才开始打印。
            lock (_lock1)
            {
                for (int i = 0; i < Math.Pow(10, 2); i++)
                {
                    ThreadLogger.WriteLine(Thread.CurrentThread.ManagedThreadId + "  " + (i + 1));
                }
            }
        }
        #endregion lock

        #region Monitor 
        // 创建一个私有静态只读对象，用于锁定资源的同步
        private static readonly object _lock2 = new object();
        // 定义共享资源 _counter2，多个线程将同时访问和修改它
        private static int _counter2 = 0;
        public static void ByMonitor()
        {
            // 创建两个线程，每个线程将执行 IncrementCounter2 方法
            Thread thread1 = new Thread(IncrementCounter2);
            Thread thread2 = new Thread(IncrementCounter2);
            // 启动两个线程
            thread1.Start();
            thread2.Start();
            // 使用 Join 方法，确保主线程等待两个子线程执行完毕
            thread1.Join();
            thread2.Join();
            // 输出最终的 _counter2 值
            ThreadLogger.WriteLine($"Final balance: {_counter2}");
        }
        // 该方法将由多个线程同时调用，更新共享资源 _counter2
        private static void IncrementCounter2()
        {
            for (int i = 0; i < Math.Pow(10, 6); i++)
            {
                // 进入 Monitor 锁定，确保以下代码块一次只能由一个线程执行
                Monitor.Enter(_lock2);
                try
                {
                    // 增加共享资源 _counter2 的值
                    _counter2++;
                }
                finally
                {
                    // 退出 Monitor 锁定，释放资源供其他线程使用
                    Monitor.Exit(_lock2);
                }
            }
        }
        public static void ByMonitor2()
        {
            Thread thread1 = new Thread(ShowIndex2);
            Thread thread2 = new Thread(ShowIndex2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
        static void ShowIndex2()
        {
            Monitor.Enter(_lock2);
            for (int i = 0; i < Math.Pow(10, 2); i++)
            {
                ThreadLogger.WriteLine(Thread.CurrentThread.ManagedThreadId + "  " + (i + 1));
            }
            Monitor.Exit(_lock2);
        }
        #endregion Monitor

        #region Mutex 互斥锁，互斥量，互斥
        // 创建一个 Mutex 对象，确保线程之间的同步
        private static readonly Mutex mutex = new Mutex();
        // 定义共享资源 _counter3
        private static int _counter3 = 0;
        public static void ByMutex()
        {
            // 创建两个线程来执行 IncrementCounter3 方法
            Thread thread1 = new Thread(IncrementCounter3);
            Thread thread2 = new Thread(IncrementCounter3);
            // 启动线程 1 和线程 2
            thread1.Start();
            thread2.Start();
            // 使用 Join 方法，确保主线程等待两个子线程执行完毕
            thread1.Join();
            thread2.Join();
            // 输出最终的 _counter3 值
            ThreadLogger.WriteLine($"Final: {_counter3}");

        }
        /// <summary>
        /// 更新 _counter3 的线程方法；
        /// 这个明显比lock和Monitor慢很多。
        /// </summary>
        private static void IncrementCounter3()
        {
            for (int i = 0; i < Math.Pow(10, 6); i++)
            {
                // 请求获取 Mutex 锁定，确保下面的代码块一次只有一个线程可以执行
                mutex.WaitOne();
                try
                {
                    // 增加共享资源 _counter3 的值
                    _counter3++;
                }
                finally
                {
                    // 释放 Mutex 锁定，允许其他线程进入代码块
                    mutex.ReleaseMutex();
                }
            }
        }
        public static void ByMutex2()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(DoWork);
                thread.Start();
            }
        }
        private static void DoWork()
        {
            ThreadLogger.WriteLine("请求/等待Mutex");
            // 等待互斥锁
            mutex.WaitOne();

            ThreadLogger.WriteLine("★ 进入Mutex");

            // 执行临界区代码
            //_counter3 = Environment.CurrentManagedThreadId;
            //ThreadLogger.WriteLine(_counter3.ToString());
            ThreadLogger.WriteLine("★ " + Environment.CurrentManagedThreadId.ToString());
            Thread.Sleep(1000);

            ThreadLogger.WriteLine("★ 离开Mutex");

            // 释放互斥锁
            mutex.ReleaseMutex();
            //ThreadLogger.WriteLine("已经释放Mutex");
        }
        #endregion Mutex

        #region Semaphore 信号量
        // 最多允许两个线程同时访问
        private static readonly Semaphore semaphore =
            new Semaphore(initialCount: 2, maximumCount: 2);
        private static int _counter4 = 0;
        public static void BySemaphore()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(IncrementCounter4);
                thread.Start();
            }
            Thread.Sleep(5000);
            ThreadLogger.WriteLine($"Final: {_counter4}");
        }
        private static void IncrementCounter4()
        {
            // 阻止当前线程，直到当前WaitHandle收到信号。
            semaphore.WaitOne();
            try
            {
                ThreadLogger.WriteLine($"在增加counter");
                _counter4 += 100;
                // 模拟操作时间
                Thread.Sleep(1000);
            }
            finally
            {
                ThreadLogger.WriteLine($"已经完成");
                // 释放信号量
                semaphore.Release();
            }
        }
        #endregion Semaphore

        #region AutoResetEvent
        private static readonly AutoResetEvent autoEvent = new AutoResetEvent(false);
        public static void ByAutoResetEvent()
        {
            Thread thread1 = new Thread(Thread1Work);
            Thread thread2 = new Thread(Thread2Work);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            ThreadLogger.WriteLine("主线程结束");
        }
        private static void Thread1Work()
        {
            ThreadLogger.WriteLine("Thread 1 工作中...");
            Thread.Sleep(1000);
            ThreadLogger.WriteLine("Thread 1 发信号给 Thread 2.");
            // 发送信号，允许 Thread2 继续执行
            autoEvent.Set();
            ThreadLogger.WriteLine("Thread 1 结束工作");
        }
        private static void Thread2Work()
        {
            ThreadLogger.WriteLine("Thread 2 等待信号中...");
            // 等待信号
            autoEvent.WaitOne();
            ThreadLogger.WriteLine("Thread 2 收到信号并继续工作...");
            ThreadLogger.WriteLine("Thread 2 结束工作");
        }
        #endregion AutoResetEvent

        #region ManualResetEvent
        // manualResetEvent用于手动阻止和释放线程。它是在无信号状态下创建的。
        private readonly static ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        public static void ByManualResetEvent()
        {
            Console.WriteLine("启动在ManualResetEvent上阻塞的3个命名线程\n");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\n当三个线程都启动后，按Enter键调用Set()以释放所有线程\n");
            Console.ReadLine();

            manualResetEvent.Set();

            Thread.Sleep(500);
            Console.WriteLine("\n当ManualResetEvent发出信号时，调用WaitOne()的线程不会阻塞，按Enter键显示此内容。\n");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\n按Enter键调用Reset()，以便线程在调用WaitOne()时再次阻塞。\n");
            Console.ReadLine();

            manualResetEvent.Reset();

            // Start a thread that waits on the ManualResetEvent.
            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Thread_5";
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\n按Enter键调用Set()并结束演示。");
            Console.ReadLine();

            manualResetEvent.Set();

            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }
        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls manualResetEvent.WaitOne()");

            manualResetEvent.WaitOne();

            Console.WriteLine(name + " ends.");
        }
        #endregion
    }
}