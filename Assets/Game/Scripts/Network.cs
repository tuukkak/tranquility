using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public static class Network
{
    static string IpAddress = "127.0.0.1";
    static int Port = 3000;

    static void SendPacket(byte[] packetData)
    {
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
        Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Socket.SendTo(packetData, EndPoint);
    }

    public static void UpdateMovement()
    {
        byte[] PacketData = new byte[16];
        PacketData[0] = 1;
        PacketData[1] = State.CurrentPlayer.Id;
        Buffer.BlockCopy(BitConverter.GetBytes(State.CurrentPlayer.Movement.CordX), 0, PacketData, 2, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(State.CurrentPlayer.Movement.CordZ), 0, PacketData, 6, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(State.CurrentPlayer.Movement.Rotation), 0, PacketData, 10, 4);
        PacketData[14] = (byte)State.CurrentPlayer.Movement.InputX;
        PacketData[15] = (byte)State.CurrentPlayer.Movement.InputZ;
        SendPacket(PacketData);
    }
}
