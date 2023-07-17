
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 1313);

var server = new UdpClient(serverEndpoint);
Regex regex = new Regex(@"/^([01]?\d|20)$/");
string text = "";

while (true)
{
    IPEndPoint clientEndPoint = default;

    var clientData = server.Receive(ref clientEndPoint);
    var clientText = Encoding.ASCII.GetString(clientData).Trim();

    var error = Encoding.ASCII.GetBytes("Error! Message is over 20 characters or contains spaces, Please try again");

    try
    {
        if (!regex.IsMatch(clientText))
        {
            server.Send(error, clientEndPoint);
            throw new Exception("Error! Message is over 20 characters or contains spaces, Please try again");
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
    text += clientText + " ";
    var serverTextData = Encoding.ASCII.GetBytes(text);
    server.Send(serverTextData, clientEndPoint);
    server.Close();
}