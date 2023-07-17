using System;
using System.Net.Sockets;
using System.IO;

TcpListener server = null;
try
{
    int portNum = 1313; //Daytime Server port Time
    server = new TcpListener(portNum);
    server.Start();

    for(; ; )
    {
        Console.WriteLine("Waiting for connection");
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Connected!");
        var stream = client.GetStream();
        string response = DateTime.Now.ToString();
        StreamWriter sw = new StreamWriter(client.GetStream());
        sw.WriteLine(response);
        Console.WriteLine(response);
        stream.Write(Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
        sw.Close();
        client.Close();
    }
}catch(Exception exception)
{
    Console.WriteLine(exception + " " + exception.StackTrace);
}
finally
{
    server.Stop();
}
