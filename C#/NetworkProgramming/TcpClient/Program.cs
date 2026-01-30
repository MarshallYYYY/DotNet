using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpClientDemo
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
                case 2:
                    ClientTwo();
                    break;
            }
            Console.ReadKey();
        }
        private static void ClientOne()
        {
            Console.WriteLine("======= 客户端 =======");
            Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 31, 120 });
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 7788);

            tcpClient.Connect(ipEndPoint);
            //Console.WriteLine(tcpClient.RemoteEndPoint);
            Console.WriteLine($"{DateTime.Now} - 连接上服务器端了");
            Console.WriteLine();

            Thread.Sleep(1000);
            // 客户端发送信息
            string message = "我上线了";
            tcpClient.Send(Encoding.UTF8.GetBytes(message));
            Console.WriteLine($"{DateTime.Now} - 客户端发送信息：{message}");

            // 客户端接收来自服务器端的信息
            byte[] data = new byte[1024];
            int length = tcpClient.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            Console.WriteLine($"{DateTime.Now} - 收到服务器端的消息：{message}");

            tcpClient.Close();
        }
        private static Socket client;
        private static void ClientTwo()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect("127.0.0.1", 12345);
            Console.Write("已连接服务端，请注册昵称：");
            string name = Console.ReadLine();
            client.Send(Encoding.UTF8.GetBytes(name));

            Thread thread = new Thread(ReceiveMsg);
            thread.Start();

            while (true)
            {
                string msg = Console.ReadLine();
                client.Send(Encoding.UTF8.GetBytes(msg));
            }
        }
        private static void ReceiveMsg()
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int num = client.Receive(buffer);
                    if (num == 0)
                        break;
                    string message = Encoding.UTF8.GetString(buffer, 0, num);
                    Console.WriteLine(message);
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                client.Close();
                Console.WriteLine("服务端已关闭");
            }
        }
    }
}
