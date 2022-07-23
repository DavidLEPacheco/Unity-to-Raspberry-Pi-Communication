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
    public String Host = "192.168.1.103";
    public Int32 Port = 12345;

    void Start()
    {
        setupSocket(); //this code sets up the socket AND connects to the server
        Debug.Log("Socket set up");

        Byte[] sendBytes = Encoding.UTF8.GetBytes("This is the client"); //Encodes message in a UTF8 byte format to allow it to send over socket
        theStream.Write(sendBytes, 0, sendBytes.Length); //Send message to server with offset and length

        Debug.Log("Sent message. Waiting for response");

        //Read response from server
        Byte[] readBytes = new byte[1024];
        StringBuilder myCompleteMessage = new StringBuilder();
        int numberOfBytesRead = 0;
        numberOfBytesRead = theStream.Read(readBytes, 0, readBytes.Length);
        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(readBytes, 0, numberOfBytesRead));
        Debug.Log("You received the following message: " + myCompleteMessage);

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
