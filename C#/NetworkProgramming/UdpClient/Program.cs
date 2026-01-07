using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("选择客户端的实现方式，输入数字 1 - n：");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ClientOne();
                    break;
            }
            Console.ReadKey();
        }
        private static void ClientOne()
        {
            Console.WriteLine("======= 客户端 =======");
            Socket udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 31, 120 });
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 7788);

            string message = "你好，udp客户端上线了";
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.SendTo(data, ipEndPoint);
            Console.WriteLine($"{DateTime.Now} - 客户端发送信息：{message}");

            udpClient.Close();
        }
    }
}