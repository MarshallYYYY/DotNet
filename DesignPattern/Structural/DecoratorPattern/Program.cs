namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("装饰器模式：");
            IMessageSender sender = new TextMessageSender();
            Console.WriteLine("-------");

            Console.WriteLine("未使用装饰器：");
            sender.Send("Hello Decorator");
            Console.WriteLine("-------");

            Console.WriteLine("使用了装饰器：");
            // 动态叠加装饰
            sender = new LoggingDecorator(sender);
            sender = new EncryptionDecorator(sender);
            sender.Send("Hello Decorator");
        }
    }
    /// <summary>
    /// 抽象组件
    /// </summary>
    public interface IMessageSender
    {
        void Send(string message);
    }
    /// <summary>
    /// 具体组件（被装饰的对象）
    /// </summary>
    public class TextMessageSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"发送消息：{message}");
        }
    }
    /// <summary>
    /// 抽象装饰器（关键）
    /// 1. 装饰器 实现同一接口
    /// 2. 持有被装饰对象的引用
    /// 3. 默认行为是“委托调用”
    /// </summary>
    public abstract class MessageSenderDecorator : IMessageSender
    {
        // 每一个装饰器对象：
        // 不是替换旧对象，而是 “包住”旧对象
        protected readonly IMessageSender _innerSender;

        protected MessageSenderDecorator(IMessageSender innerSender)
        {
            _innerSender = innerSender;
        }

        public virtual void Send(string message)
        {
            _innerSender.Send(message);
        }
    }
    /// <summary>
    /// 具体装饰器：日志功能
    /// </summary>
    public class LoggingDecorator : MessageSenderDecorator
    {
        // 基类构造函数一定先执行，无论你写不写 base(...)：
        // 都会先执行一个基类构造函数，如果你不显式指定，编译器会尝试调用 无参构造函数
        public LoggingDecorator(IMessageSender innerSender) : base(innerSender)
        {
        }

        public override void Send(string message)
        {
            Console.WriteLine("【日志】准备发送消息");
            base.Send(message);
            Console.WriteLine("【日志】消息发送完成");
        }
    }
    /// <summary>
    /// 具体装饰器：加密功能
    /// </summary>
    public class EncryptionDecorator : MessageSenderDecorator
    {
        public EncryptionDecorator(IMessageSender innerSender) : base(innerSender)
        {
        }

        public override void Send(string message)
        {
            string encryptedMessage = Encrypt(message);
            base.Send(encryptedMessage);
        }

        private string Encrypt(string message)
        {
            // 简单示例：反转字符串模拟“加密”
            return new string(message.Reverse().ToArray());
        }
    }
}