namespace FactoryPattern
{
    /// <summary>
    /// 反射工厂模式
    /// 是针对简单工厂模式的一种改进
    /// </summary>
    public static class ReflectFactory
    {
        public static ICoffee MakeCoffee(string coffeeName)
        {
            Type type = Type.GetType(coffeeName)!;
            ICoffee? coffee = type.Assembly.CreateInstance(coffeeName) as ICoffee;
            return coffee!;
        }
    }
}
