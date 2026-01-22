namespace FactoryPattern
{
    public abstract class AbstractDessert
    {
        public abstract void ShowInfo();
    }
    public class Tiramisu : AbstractDessert
    {
        public override void ShowInfo()
        {
            Console.WriteLine("这是：提拉米苏");
        }
    }
    public class MatchMousse : AbstractDessert
    {
        public override void ShowInfo()
        {
            Console.WriteLine("这是：抹茶慕斯");
        }
    }
    /// <summary>
    /// 抽象工厂模式：
    /// 抽象工厂是应对产品族概念的，
    /// 比如说，每个公司可能要同时生产咖啡、甜点，那么每一个工厂都要有制作咖啡和甜点的方法。
    /// 应对产品族概念而生，增加新的产品线很容易，但是无法增加新的产品。
    /// </summary>
    public interface IFactory
    {
        AbstractCoffee MakeCoffee();
        AbstractDessert MakeDessert();
    }
    public class AmericaFactory : IFactory
    {
        public AbstractCoffee MakeCoffee()
        {
            Console.WriteLine("美国工厂生产了美式咖啡");
            return new Americano();
        }

        public AbstractDessert MakeDessert()
        {
            Console.WriteLine("美国工厂生产了提拉米苏");
            return new Tiramisu();
        }
    }
    public class ItalyFactory : IFactory
    {
        public AbstractCoffee MakeCoffee()
        {
            Console.WriteLine("意大利工厂生产了拿铁咖啡");
            return new LatteCoffee();
        }

        public AbstractDessert MakeDessert()
        {
            Console.WriteLine("意大利工厂生产了抹茶慕斯");
            return new MatchMousse();
        }
    }
}
