namespace Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarDealer dealer = new();
            // 两种写法
            var Tom = new Consumer("Mike");
            Consumer Mary = new("Mary");

            // 两种写法
            dealer.NewCarEvent += new EventHandler<CarInfoEventArgs>(Tom.KonwsNewCarArrived);
            dealer.NewCarEvent += Mary.KonwsNewCarArrived;

            dealer.NewCarArrives("DasAuto");
        }
    }
    public class CarInfoEventArgs : EventArgs
    {
        public string Car { get; }
        public CarInfoEventArgs(string car)
        {
            Car = car;
        }
    }
    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs>? NewCarEvent;
        public void NewCarArrives(string car)
        {
            Console.WriteLine($"CarDealer: Attention, new car {car} arrives！！！");
            NewCarEvent?.Invoke(this, new CarInfoEventArgs(car));
        }
    }
    public class Consumer
    {
        private readonly string _name;
        public Consumer(string name)
        {
            _name = name;
        }

        public void KonwsNewCarArrived(object? sender, CarInfoEventArgs e)
        {
            Console.WriteLine($"  {_name}: OK, I learn that car {e.Car} arrived.");
        }
    }
}