namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherStation station = new WeatherStation();

            IObserver phone = new PhoneDisplay();
            IObserver window = new WindowDisplay();

            station.Attach(phone);
            station.Attach(window);

            station.SetTemperature(26.5f);
            station.SetTemperature(28.0f);

            station.Detach(phone);

            station.SetTemperature(30.0f);
        }
    }
    /// <summary>
    /// 抽象观察者
    /// </summary>
    public interface IObserver
    {
        void Update(float temperature);
    }
    /// <summary>
    /// 抽象主题
    /// </summary>
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
    /// <summary>
    /// 具体主题（被观察者）
    /// </summary>
    public class WeatherStation : ISubject
    {
        private readonly List<IObserver> _observers = [];
        private float _temperature;

        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(_temperature);
            }
        }
    }
    #region 具体观察者
    public class PhoneDisplay : IObserver
    {
        public void Update(float temperature)
        {
            Console.WriteLine($"手机显示温度：{temperature}°C");
        }
    }
    public class WindowDisplay : IObserver
    {
        public void Update(float temperature)
        {
            Console.WriteLine($"窗口显示温度：{temperature}°C");
        }
    }
    #endregion
}
