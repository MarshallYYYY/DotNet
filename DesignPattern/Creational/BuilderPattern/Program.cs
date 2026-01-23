namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new();
            HpBulider hpBuilder = new();
            DellBulider dellBuilder = new();

            Console.WriteLine("组装一批惠普电脑");
            Computer hp = director.Construct(hpBuilder);
            hp.ShowSteps();

            Console.WriteLine("-------");

            Console.WriteLine("组装一批戴尔电脑");
            Computer dell = director.Construct(dellBuilder);
            dell.ShowSteps();
        }
    }
}