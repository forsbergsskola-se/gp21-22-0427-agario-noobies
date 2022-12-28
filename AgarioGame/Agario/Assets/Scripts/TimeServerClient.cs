using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;

public class TimeServerClient : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dateTimeText;


    private IPEndPoint _server = new IPEndPoint(IPAddress.Loopback, 1313);
    private IPEndPoint _client = new IPEndPoint(IPAddress.Loopback, 3210);


    public void SendRequestBTN()
    {
        SendRequestToServer();
    }
    private async Task SendRequestToServer()
    {
        Debug.Log("Sending...");
        var tcpClient = new TcpClient(_client);
        await tcpClient.ConnectAsync(_server.Address,_server.Port);

        Debug.Log("Connecting...");
        var stream = tcpClient.GetStream();
        byte[] buffer = new byte[100];
        stream.Read(buffer, 0, 100);
        var bytes = new byte[buffer.Length];
        Debug.Log("Recieving Data...");
        var text = Encoding.ASCII.GetString(buffer);
        _dateTimeText.text = text;
        Debug.Log("Time/Date: " + text);


        tcpClient.Close();
    }
}
