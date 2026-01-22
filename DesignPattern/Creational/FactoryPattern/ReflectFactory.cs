namespace FactoryPattern
{
    /// <summary>
    /// 反射工厂模式
    /// 是针对简单工厂模式的一种改进
    /// </summary>
    public static class ReflectFactory
    {
        public static AbstractCoffee MakeCoffee(string coffeeName)
        {
            Type type = Type.GetType(coffeeName)!;
            AbstractCoffee? coffee = type.Assembly.CreateInstance(coffeeName) as AbstractCoffee;
            return coffee!;
        }
    }
}
