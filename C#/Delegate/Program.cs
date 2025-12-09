namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== delegate =====");
            FunBasic();
            Console.WriteLine("===== Action =====");
            FunAction();
            Console.WriteLine("===== Func =====");
            FunFunc();
            Console.WriteLine("===== Predict =====");
            FunPredict();
            Console.WriteLine("===== 多播委托 =====");
            FunMulticastDelegate();
        }

        #region delegate
        // 比较年龄
        private static bool Younger(Student s1, Student s2) => s1.Age <= s2.Age;
        // 比较学号
        private static bool NumSmaller(Student s1, Student s2) => s1.Num <= s2.Num;

        private delegate bool CompareDelegate(Student first, Student second);

        private static void FunBasic()
        {
            Student s1 = new() { Name = "小红", Age = 10, Num = 1001 };
            Student s2 = new() { Name = "小华", Age = 9, Num = 1002 };
            List<Student> stus = new();
            stus.Add(s1);
            stus.Add(s2);

            // 以下两种方法等价
            CompareDelegate younger1 = new CompareDelegate(Younger);
            // 委托推断
            CompareDelegate younger2 = Younger;
            SortStudents(stus, younger1);

            Console.WriteLine("-------------");

            // 委托的实例化与使用
            // 采用比较学号的方法
            //CompareDelegate numSmaller = NumSmaller;
            //SortStudents(stus, numSmaller);

            //使用委托推断，与上两行等价
            SortStudents(stus, NumSmaller);
        }
        private static void SortStudents(List<Student> stus, CompareDelegate compareDelegate)
        {
            // compareDelegate(stus[0], stus[1]) 等价于 compareDelegate.Invoke(stus[0],  List[1])
            if (compareDelegate(stus[0], stus[1]) is false)
            {
                //交换位置
                stus.Reverse();
            }
            // 获取排名采用的比较方法的名称
            Console.WriteLine($"按照 {compareDelegate.Method.Name} 排名：");
            // 打印排序后的链表
            foreach (Student stu in stus)
                Console.WriteLine($"{stu.Name} {stu.Age} {stu.Num} ");
        }
        #endregion

        #region Action
        private static void FunAction1() =>
            Console.WriteLine("无参，无返回值。");
        private static void FunAction2(int a, string b) =>
            Console.WriteLine($"两个参数，无返回值，参数一：{a}，参数二：{b}。");
        private static void FunAction()
        {
            Action a1 = new Action(FunAction1);
            Action<int, string> a2 = FunAction2;
            // 两种调用方式
            a1();
            a2.Invoke(7, "XQQ");
        }
        #endregion

        #region Func
        private static string FunFunc1() => "Fun函数";
        private static string FunFunc2(int a, int b) => (a + b).ToString();
        private static void FunFunc()
        {
            Func<string> func1 = FunFunc1;
            Func<int, int, string> func2 = FunFunc2;
            string res1 = func1.Invoke();
            string res2 = func2(2, 7);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
        #endregion

        #region Predicate
        private static bool IsMore(int num) => num > 7;
        private static void FunPredict()
        {
            // Predicate泛型委托需要传入一个T类型的参数，并且需要返回一个bool类型的返回值。
            Predicate<int> predicate = IsMore;
            bool res = predicate(8);
            Console.WriteLine(res);
        }
        #endregion

        #region Multicast Delegate
        private delegate int AddDelegate(int a);
        private static void FunMulticastDelegate()
        {
            // Lambda表达式：
            // 当一个形参的时候，形参的圆括号写与不写都可以：i => i + 10 等价于 (i) => i + 10
            // 但当形参数量为0或多个时，就必须写圆括号。
            AddDelegate myAddDelegate = new(i => i + 10);
            myAddDelegate += i => i - 10;

            Type? type = typeof(AddDelegate);
            Console.WriteLine($"AddDelegate委托的基类为{type.BaseType?.FullName}");

            Console.WriteLine(myAddDelegate?.Invoke(10));

            //逐个调用
            Console.WriteLine("逐个调用：");
            foreach (AddDelegate fun in myAddDelegate!.GetInvocationList())
                Console.WriteLine(fun.Invoke(10));
        }
        #endregion
    }
    public class Student
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Num { get; set; }
    }
}