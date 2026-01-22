namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("单例模式：");
            Console.WriteLine();

            TestStaticSingleton();
            TestLasyInitialSingleton();
            TestDoubleLockSingleton();
        }

        private static void TestStaticSingleton()
        {
            Console.WriteLine("饿汉模式：静态变量初始化实例");

            Singleton1 singleton1 = Singleton1.Instance();
            singleton1.GetInfo();

            Console.WriteLine("-------");
        }

        private static void TestLasyInitialSingleton()
        {
            Console.WriteLine("懒汉模式：延迟初始化实例");

            Singleton2 singleton2 = Singleton2.Instance();
            singleton2.GetInfo();
            singleton2.Reset();

            Console.WriteLine("-------");
        }

        private static void TestDoubleLockSingleton()
        {
            Console.WriteLine("双重检查锁：锁机制确保多线程只产生一个实例");

            for (int i = 0; i < 2; i++)
            {
                Thread thread = new(DoWork);
                thread.Start();
            }
        }


        private static void DoWork()
        {
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);

            Singleton3 singleton3 = Singleton3.Instance();
            singleton3.GetInfo();
            Console.WriteLine(singleton3.GetHashCode());
        }
    }
}
