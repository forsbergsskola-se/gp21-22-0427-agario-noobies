using System;
using System.Net.Sockets;
using System.IO;

public class DaytimeClient : TcpClient
{
    public DaytimeClient(string host)
    {
        base.Connect(host, 13);
    }

    public static void Main(string[] args)
    {
        DaytimeClient dtReceiver = null;
        StreamReader sr = null;

        try
        {
            string host = args.Length == 1 ? args[0] : "127.0.0.1";
            dtReceiver = new DaytimeClient(host);
            sr = new StreamReader(dtReceiver.GetStream());  

            string returnData = sr.ReadToEnd();
            Console.WriteLine("Time at " + host + " : " + returnData);

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex + " " + ex.StackTrace);
        }
        finally
        {
            if(sr != null) sr.Close();
            if(dtReceiver != null) dtReceiver.Close();
        }

    }
}