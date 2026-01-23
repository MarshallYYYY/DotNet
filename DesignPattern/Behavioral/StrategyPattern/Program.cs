namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderContext order = new(new NoDiscountStrategy());

            decimal price = 100m;
            Console.WriteLine(order.GetFinalPrice(price)); // 100

            order.SetDiscountStrategy(new VipDiscountStrategy());
            Console.WriteLine(order.GetFinalPrice(price)); // 90

            order.SetDiscountStrategy(new SuperVipDiscountStrategy());
            Console.WriteLine(order.GetFinalPrice(price)); // 80
        }
    }
    /// <summary>
    /// 抽象策略接口
    /// </summary>
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal originalPrice);
    }
    #region 具体策略实现
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice;
        }
    }
    public class VipDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice * 0.9m;
        }
    }
    public class SuperVipDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice * 0.8m;
        }
    }
    #endregion
    /// <summary>
    /// 上下文（策略使用者）
    /// </summary>
    public class OrderContext
    {
        private IDiscountStrategy _discountStrategy;

        public OrderContext(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal GetFinalPrice(decimal originalPrice)
        {
            return _discountStrategy.ApplyDiscount(originalPrice);
        }
    }

}
