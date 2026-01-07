using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpServer
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
                case 2:
                    ServerTwo();
                    break;
            }
        }
        private static void ServerOne()
        {
            Console.WriteLine("======= 服务器端 =======");
            // InterNetwork: IPv4, InterNetworkV6: IPv6
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // cmd, ipconfig, IPv4
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 31, 120 });
            // IP + Port
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 7788);

            tcpServer.Bind(ipEndPoint);
            tcpServer.Listen(100);

            Console.WriteLine($"{DateTime.Now} - 开始接收客户端...\n");
            while (true)
            {
                Accept();
            }
            //tcpServer.Close();

            void Accept()
            {
                // 开始监听
                Socket client = tcpServer.Accept();
                string info = client.RemoteEndPoint.ToString();
                Console.WriteLine($"------- '{info}' -------");
                Console.WriteLine($"{DateTime.Now}：一个客户端 '{info}' 连接过来了");
                Console.WriteLine();

                // 服务器端接收来自客户端的信息
                byte[] data = new byte[1024];
                int length = client.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine($"{DateTime.Now}：接收到了客户端 '{info}' 的消息：" + message);

                Thread.Sleep(1000);
                // 服务器端发送信息
                message = "来了，随便坐";
                client.Send(Encoding.UTF8.GetBytes(message));
                Console.WriteLine($"{DateTime.Now}：服务器端向客户端 '{info}' 发送信息：{message}");

                client.Close();
                Console.WriteLine($"------- '{info}' -------");
            }
        }

        private static List<Socket> clients = new List<Socket>();
        private static List<string> userNames = new List<string>();
        private static Socket server;
        private static void ServerTwo()
        {
            // IPv4 v6，套接字类型，流式套接字， 协议
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, 12345));
            server.Listen(10);
            Console.WriteLine("服务端已经开启成功了,等待用户的连接....");

            while (true)
            {
                Socket client = server.Accept();
                clients.Add(client);
                Console.WriteLine($"新的用户连接{client.RemoteEndPoint}");
                Thread th = new Thread(() => HandleClient(client));
                th.Start();
            }
        }
        static void HandleClient(Socket client)
        {
            byte[] buffer = new byte[1024];
            string name = "";
            try
            {
                int num = client.Receive(buffer);
                name = Encoding.UTF8.GetString(buffer, 0, num);
                Console.WriteLine($"{client.RemoteEndPoint}注册为{name}");
                BoardCasts($"{client.RemoteEndPoint}注册为{name}", client);
                userNames.Add(name);

                while (true)
                {
                    num = client.Receive(buffer);
                    if (num == 0)
                        break;
                    string message = Encoding.UTF8.GetString(buffer, 0, num);
                    BoardCasts(name + ": " + message, client);
                    Console.WriteLine(name + ": " + message);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                client.Close();
                clients.Remove(client);
                userNames.Remove(name);
                BoardCasts(name + "已下线", client);
                Console.WriteLine(name + "已下线");
            }

        }
        private static void BoardCasts(string msg, Socket client)
        {
            foreach (var i in clients)
            {
                if (i != client)
                {
                    i.Send(Encoding.UTF8.GetBytes(msg));
                }
            }
        }
    }
}
