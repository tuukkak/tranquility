using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public static class Network
{
    static string IpAddress = "127.0.0.1";
    static int Port = 3000;

    static UdpClient Client = new UdpClient(0);
    static IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

    public static ConcurrentQueue<byte[]> PacketQueue = new ConcurrentQueue<byte[]>();

    static Network()
    {
        Thread SocketThread = new Thread(ListenUdp);
        SocketThread.IsBackground = true;
        SocketThread.Start();
    }

    static void ListenUdp()
    {
        while (true)
        {
            byte[] receiveBytes = Client.Receive(ref RemoteIpEndPoint);
            PacketQueue.Enqueue(receiveBytes);
            Debug.Log("Packet received");
        }
    }

    static void SendPacket(byte[] packetData)
    {
        Debug.Log("sending");
        Client.Send(packetData, packetData.Length, IpAddress, Port);
    }

    public static void Login(string name)
    {
        byte[] PacketData = new byte[13];
        PacketData[0] = 1;
        Encoding.UTF8.GetBytes(name, 0, name.Length, PacketData, 1);
        SendPacket(PacketData);
    }

    public static void Join()
    {
        byte[] PacketData = new byte[2];
        PacketData[0] = 2;
        PacketData[1] = (byte)State.CurrentPlayerId;
        SendPacket(PacketData);
    }

    public static void UpdateMovement()
    {
        byte[] PacketData = new byte[16];
        PacketData[0] = 3;
        PacketData[1] = State.CurrentPlayer.Id;
        Buffer.BlockCopy(BitConverter.GetBytes(State.CurrentPlayer.Movement.CordX), 0, PacketData, 2, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(State.CurrentPlayer.Movement.CordZ), 0, PacketData, 6, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(State.CurrentPlayer.Movement.Rotation), 0, PacketData, 10, 4);
        PacketData[14] = (byte)State.CurrentPlayer.Movement.InputX;
        PacketData[15] = (byte)State.CurrentPlayer.Movement.InputZ;
        SendPacket(PacketData);
    }
}
