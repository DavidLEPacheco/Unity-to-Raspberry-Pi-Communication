//Client socket. Initialize after Server socket is generated

using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Text; // To allow encoding

public class ClientSocket : MonoBehaviour
{

    bool socketReady = false;
    TcpClient mySocket;
    public NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    public String Host = "192.168.1.7";
    public Int32 Port = 12345;

    void Start()
    {
        setupSocket(); //this code sets up the socket AND connects to the server
        Debug.Log("Socket set up");

        Byte[] sendBytes = Encoding.UTF8.GetBytes("This is the client"); //THIS WORKED. FIND OUT HOW
        theStream.Write(sendBytes, 0, sendBytes.Length); //THIS WORKED. FIND OUT HOW

        theWriter.WriteLine("This is the client"); //THIS DOESN'T WORK. FIND OUT WHY
        theWriter.Write(sendBytes); //THIS DOESN'T WORK. FIND OUT WHY
        Debug.Log("Sent message. Waiting for response");
    }


    public void setupSocket()
    {                            // Socket setup here.
        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error:" + e);                // catch any exceptions
        }
    }
}
