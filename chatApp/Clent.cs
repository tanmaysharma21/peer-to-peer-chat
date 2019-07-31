using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace chatApp
{
    public class ClientHost
    {
        public void Connect()
        {
            IPAddress iPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
            TcpClient client = new TcpClient();
            Console.WriteLine("Trying to connect with another user...");
            Thread.Sleep(4000);
            Console.WriteLine("You are connected with another user");

            client.Connect(iPAddress, 13000);

            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);
            string message;
            while (!string.IsNullOrEmpty((message = Console.ReadLine())) && message != "exit")
            {
                Displayer.ShowSentMessage(message);
                byte[] buffer = Encoding.ASCII.GetBytes($"{message}");
                ns.Write(buffer, 0, buffer.Length);
            }

        }

        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byteCount;

            while ((byteCount = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                String message = MessageEncoderDecoder.DecodeMessage(receivedBytes, byteCount);
                Displayer.ShowReceivedMessage(message);
            }
        }

    }
}
