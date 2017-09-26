using System;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class StreamClient
    {
        private Socket Client;
        public StreamClient(Socket client)
        {
            Client = client;
        }

        public void service()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[64];
                    Waiting(buffer);
                    Answering(buffer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Terrminated");
            }
        }

        private void Waiting(byte[] buffer)
        {
            
            Console.WriteLine("Waiting for an answer");
            Client.Receive(buffer, 0, buffer.Length, 0);
            string message = Encoding.UTF8.GetString(buffer);
            Console.WriteLine("Answer: " + message);
        }

        private void Answering(byte[] buffer)
        {
            string answer = "Actualy date is " + DateTime.Now;
            buffer = Encoding.UTF8.GetBytes(answer);
            Console.WriteLine("Sending {0}", answer);
            Client.Send(buffer);
        }
        
        
        
    }
}