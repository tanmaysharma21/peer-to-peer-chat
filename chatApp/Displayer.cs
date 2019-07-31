using System;
using System.Collections.Generic;
using System.Text;

namespace chatApp
{
    public class Displayer
    {
        public static void ShowReceivedMessage(string message)
        {            
            Console.WriteLine("Received: {0}", message);
        }

        public static void ShowSentMessage(string message)
        {
            Console.WriteLine("Sent : " + message);
        }

    }
}
