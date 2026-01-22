

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestSimpleFactory();
            TestReflectFactory();
            TestFactoryMethod();
            TestAbstractFactory();
        }

        private static void TestSimpleFactory()
        {
            Console.WriteLine("简单工厂模式：");
            ICoffee? coffee1 = SimpleFactory.MakeCoffee(CoffeeEnum.Americano);
            coffee1?.ShowInfo();
            ICoffee? coffee2 = SimpleFactory.MakeCoffee(CoffeeEnum.LatteCoffee);
            coffee2?.ShowInfo();
            Console.WriteLine("-------");
        }
        private static void TestReflectFactory()
        {
            Console.WriteLine("反射工厂模式：");
            ICoffee coffee1 = ReflectFactory.MakeCoffee($"FactoryPattern.{CoffeeEnum.Americano}")!;
            coffee1.ShowInfo();
            ICoffee coffee2 = ReflectFactory.MakeCoffee($"FactoryPattern.{CoffeeEnum.LatteCoffee}")!;
            coffee2.ShowInfo();
            Console.WriteLine("-------");
        }

        private static void TestFactoryMethod()
        {
            Console.WriteLine("工厂方法模式：");
            ICoffeeFactory factory1 = new AmericaCoffeeFactory();
            ICoffee? coffee1 = factory1.MakeCoffee();
            coffee1?.ShowInfo();
            ICoffeeFactory factory2 = new ItalyCoffeeFactory();
            ICoffee? coffee2 = factory2.MakeCoffee();
            coffee2?.ShowInfo();
            Console.WriteLine("-------");
        }
        private static void TestAbstractFactory()
        {
            Console.WriteLine("抽象工厂模式：");

            IFactory factory1 = new AmericaFactory();
            factory1.MakeCoffee().ShowInfo();
            factory1.MakeDessert().ShowInfo();

            IFactory factory2 = new ItalyFactory();
            factory2.MakeCoffee().ShowInfo();
            factory2.MakeDessert().ShowInfo();
        }
    }
}
