using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpServerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("选择服务器的实现方式，输入数字 1 - n：");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ServerOne();
                    break;
            }
        }
        private static void ServerOne()
        {
            Console.WriteLine("======= 服务器端 =======");
            Socket udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 31, 120 });
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 7788);
            udpServer.Bind(ipEndPoint);

            // 第二个参数 port 为 0，代表 可以接收任何类型的端口。
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
            EndPoint ep = (EndPoint)ipep;
            byte[] data = new byte[1024];
            int length = udpServer.ReceiveFrom(data, ref ep);

            Console.WriteLine($"{DateTime.Now} - 接收到数据：{Encoding.UTF8.GetString(data, 0, length)}");

            udpServer.Close();
        }
    }
}