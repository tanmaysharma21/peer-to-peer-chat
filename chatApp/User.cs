using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace chatApp
{
    public class User
    {
        public IPAddress ipAddress;
        public string Name { get; set; }

        public void Instantiate()
        {
            Console.WriteLine("do yo want to call another user");
            string ans = Console.ReadLine();

            if (ans.ToLowerInvariant().Equals("no"))
            {
                
                NetworkHost networkHost = new NetworkHost();
                networkHost.Listen();
            }
            else
            {
                ClientHost clientHost = new ClientHost();
                Console.WriteLine("Enter the IP address of user with whom you want to connect ");
                string ip = Console.ReadLine();
                clientHost.Connect();
            }
        }

    }
}
