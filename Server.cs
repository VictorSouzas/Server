using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BinaryTree;

namespace Server
{
    public class Server 
    {
        private IPEndPoint EndPoint;
        private Socket ServerSocket;
        private BinaryTreeThread binaryTree;
        public Server()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            EndPoint = new IPEndPoint(IPAddress.Any, 8888);
            ServerSocket.Bind(EndPoint);
            ServerSocket.Listen(backlog:Int32.MaxValue);
            binaryTree = new BinaryTreeThread();
        }

        public void Start()
        {
            Console.WriteLine("waiting");
            Socket client = ServerSocket.Accept();
            Console.WriteLine("----------------connected------------------------");
            StreamClient stream = new StreamClient(client);
            Thread t = new Thread(stream.service);
            t.Start();
            binaryTree.Add(t);  
        }
        
        
    }
}