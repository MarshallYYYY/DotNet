// 这个项目里的关于工厂和产品的接口、抽象类、类，散落在各个.cs文件中，
// 是随着工厂模式的不断演化而逐步新增的。

namespace FactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //简单工厂：简单实用，但违反开放封闭
            TestSimpleFactory();
            //反射工厂：可以最大限度的解耦
            TestReflectFactory();
            //工厂方法：开放封闭，单一产品
            TestFactoryMethod();
            //抽象工厂：开放封闭，多个产品
            TestAbstractFactory();
        }

        private static void TestSimpleFactory()
        {
            Console.WriteLine("简单工厂模式：");
            AbstractCoffee coffee1 = SimpleFactory.MakeCoffee(CoffeeEnum.Americano);
            coffee1.ShowInfo();
            AbstractCoffee coffee2 = SimpleFactory.MakeCoffee(CoffeeEnum.LatteCoffee);
            coffee2.ShowInfo();
            Console.WriteLine("-------");
        }
        private static void TestReflectFactory()
        {
            Console.WriteLine("反射工厂模式：");
            AbstractCoffee coffee1 = ReflectFactory.MakeCoffee($"FactoryPattern.{CoffeeEnum.Americano}")!;
            coffee1.ShowInfo();
            AbstractCoffee coffee2 = ReflectFactory.MakeCoffee($"FactoryPattern.{CoffeeEnum.LatteCoffee}")!;
            coffee2.ShowInfo();
            Console.WriteLine("-------");
        }

        private static void TestFactoryMethod()
        {
            Console.WriteLine("工厂方法模式：");

            ICoffeeFactory factory1 = new AmericaCoffeeFactory();
            AbstractCoffee coffee1 = factory1.MakeCoffee();
            coffee1.ShowInfo();

            ICoffeeFactory factory2 = new ItalyCoffeeFactory();
            AbstractCoffee coffee2 = factory2.MakeCoffee();
            coffee2.ShowInfo();

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
