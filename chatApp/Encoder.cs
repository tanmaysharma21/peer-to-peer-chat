using System;
using System.Collections.Generic;
using System.Text;

namespace chatApp
{
    public class MessageEncoderDecoder
    {
        public static byte[] EncodeMessage(string message)
        {
            byte[] bytes = new byte[128];
            bytes = Encoding.ASCII.GetBytes(message);
            return bytes;
        }

        public static string DecodeMessage(byte[] bytes, int byteCount)
        {
            string message = Encoding.ASCII.GetString(bytes, 0, byteCount);
            return message;
        }

    }
}
