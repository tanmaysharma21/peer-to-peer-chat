using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace chatApp
{
    public class NetworkHost
    {

        string message;

        public void Listen()
        {
            IPAddress iPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
            TcpListener listener = new TcpListener(iPAddress, 13000);

            listener.Start();
            //int check = 0;

            

            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Another user trying to connect with you ...");
            Thread.Sleep(4000);
            Console.WriteLine("Another user connected");

            Console.WriteLine("Connection established");

            NetworkStream stream = client.GetStream();
            Thread thread = new Thread(o => ListenerReceive((NetworkStream)o));
            thread.Start(stream);
            while (!string.IsNullOrEmpty((message = Console.ReadLine())) && message != "exit")
            {
                Displayer.ShowSentMessage(message);
                byte[] buffer = MessageEncoderDecoder.EncodeMessage(message);
                
                stream.Write(buffer, 0, buffer.Length);
            }

        }

        public void ListenerReceive(NetworkStream stream)
        {
            Byte[] bytes = new Byte[256];
            String data = null;
            int bytesCount;
            while ((bytesCount = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = MessageEncoderDecoder.DecodeMessage(bytes, bytesCount);
                Displayer.ShowReceivedMessage(data);

                
            }

        }


    }
}
