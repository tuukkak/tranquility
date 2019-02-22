using System;
using UnityEngine;

public static class Unpacker
{
    enum Type : byte { Ack, Login, Start, Movement, Spell };

    public static void Unpack(byte[] packetData)
    {
        switch (packetData[0])
        {
            case (byte)Type.Login:
                State.CurrentPlayerId = (int)packetData[1];
                Game.LoadScene = "MenuScene";
                break;

            case (byte)Type.Start:
                int index = 2;
                for (int i = 0; i < (int)packetData[1]; i++)
                {
                    State.Players.Add(new Player(id: packetData[index++], name: "Player 1", team: packetData[index++], heroId: 1));
                }
                State.CurrentPlayer = State.Players.Find(p => p.Id == State.CurrentPlayerId);
                Game.LoadScene = "GameScene";
                break;

            case (byte)Type.Movement:
                Debug.Log("Terve");
                Player player = State.Players.Find(p => p.Id == packetData[1]);
                player.Movement.CordX = BitConverter.ToSingle(packetData, 2);
                player.Movement.CordZ = BitConverter.ToSingle(packetData, 6);
                player.Movement.Rotation = BitConverter.ToSingle(packetData, 10);
                player.Movement.InputX = (sbyte)packetData[14];
                player.Movement.InputZ = (sbyte)packetData[15];
                break;
        }
    }
}
