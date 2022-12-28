using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

public class OpenWordClient : TcpClient
{
    public static void Main(string[] args)
    {
        var server = new IPEndPoint(IPAddress.Loopback, 1313);
        var client = new IPEndPoint(IPAddress.Loopback, 1314);

        while (true)
        {
            var udpClient = new UdpClient(client);
            Console.WriteLine("Please enter a string, between 1-20 characters");
            string inputTMP = Console.ReadLine();
            if (inputTMP != null)
            {
                var msg = Encoding.ASCII.GetBytes(inputTMP);
                udpClient.Send(msg, msg.Length, server);
            }
            udpClient.Close();
        }
    }
}