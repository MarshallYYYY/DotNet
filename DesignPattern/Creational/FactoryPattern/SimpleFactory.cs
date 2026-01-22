namespace FactoryPattern
{
    public interface ICoffee
    {
        void ShowInfo();
    }
    /// <summary>
    /// 美式咖啡
    /// </summary>
    public class Americano : ICoffee
    {
        public void ShowInfo()
        {
            Console.WriteLine("这是：美式咖啡");
        }
    }
    /// <summary>
    /// 拿铁咖啡
    /// </summary>
    public class LatteCoffee : ICoffee
    {
        public void ShowInfo()
        {
            Console.WriteLine("这是：拿铁咖啡");
        }
    }
    public enum CoffeeEnum
    {
        Americano,
        LatteCoffee,
    }
    /// <summary>
    /// 简单工厂模式：
    /// 简单工厂模式的工厂类一般是使用静态方法，通过接收的参数的不同来返回不同的对象实例。
    /// 不修改代码的话，是无法扩展的。（如果增加新的产品，需要增加工厂的switch分支）
    /// 不符合【开放封闭原则】
    /// </summary>
    public class SimpleFactory
    {
        public static ICoffee? MakeCoffee(CoffeeEnum coffee)
        {
            switch (coffee)
            {
                case CoffeeEnum.Americano:
                    return new Americano();
                case CoffeeEnum.LatteCoffee:
                    return new LatteCoffee();
                default:
                    return null;
            }
        }
    }
}
