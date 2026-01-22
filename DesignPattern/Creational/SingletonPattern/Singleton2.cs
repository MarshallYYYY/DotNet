namespace SingletonPattern
{
    /// <summary>
    /// 单例模式实现方式二：
    /// 懒汉模式：延迟初始化
    /// </summary>
    public class Singleton2
    {
        /// <summary>
        /// 定义为static，可以保证变量为线程安全的，即每个线程一个实例
        /// </summary>
        private static Singleton2? instance;

        private Singleton2()
        {

        }

        public static Singleton2 Instance()
        {
            //if (instance == null)
            //{
            //   instance = new Singleton2();
            //}
            //return instance;
            return instance ??= new Singleton2();
        }

        /// <summary>
        /// 使用此方法销毁已创建的实例
        /// </summary>
        public void Reset()
        {
            instance = null;
        }

        public void GetInfo()
        {
            Console.WriteLine(string.Format("I am {0}.", this.GetType().Name));
        }
    }
}
