using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    internal class AbstractFactory
    {
    }
    public interface IDessert
    {
        void ShowInfo();
    }
    public class Tiramisu : IDessert
    {
        public void ShowInfo()
        {
            Console.WriteLine("这是：提拉米苏");
        }
    }
    public class MatchMousse : IDessert
    {
        public void ShowInfo()
        {
            Console.WriteLine("这是：抹茶慕斯");
        }
    }
    public interface IFactory
    {
        ICoffee MakeCoffee();
        IDessert MakeDessert();
    }
    public class AmericaFactory : IFactory
    {
        public ICoffee MakeCoffee()
        {
            Console.WriteLine("美国工厂生产了美式咖啡");
            return new Americano();
        }

        public IDessert MakeDessert()
        {
            Console.WriteLine("美国工厂生产了提拉米苏");
            return new Tiramisu();
        }
    }
    public class ItalyFactory : IFactory
    {
        public ICoffee MakeCoffee()
        {
            Console.WriteLine("意大利工厂生产了拿铁咖啡");
            return new LatteCoffee();
        }

        public IDessert MakeDessert()
        {
            Console.WriteLine("意大利工厂生产了抹茶慕斯");
            return new MatchMousse();
        }
    }
}
