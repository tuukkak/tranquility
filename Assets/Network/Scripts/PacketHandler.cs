using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacketHandler : MonoBehaviour
{
    enum Type : byte { Ack, Login, Start, Movement, Spell };
    byte[] Packet;

    void Update()
    {
        while(Network.PacketQueue.TryDequeue(out Packet))
        {
            Unpack(Packet);
        }
    }

    public static void Unpack(byte[] packetData)
    {
        switch (packetData[0])
        {
            case (byte)Type.Login:
                State.CurrentPlayerId = (int)packetData[1];
                SceneManager.LoadScene("MenuScene");
                break;

            case (byte)Type.Start:
                int index = 2;
                for (int i = 0; i < (int)packetData[1]; i++)
                {
                    byte id = packetData[index++];
                    string name = Encoding.UTF8.GetString(packetData, index, 12).TrimEnd('\0');
                    index += 12;
                    byte team = packetData[index++];
                    State.Players.Add(new Player(id: id, name: name, team: team, heroId: 1));
                }
                State.CurrentPlayer = State.Players.Find(p => p.Id == State.CurrentPlayerId);
                SceneManager.LoadScene("GameScene");
                break;

            case (byte)Type.Movement:
                Player player = State.Players.Find(p => p.Id == packetData[1]);
                player.GameObject.transform.position = new Vector3(
                    BitConverter.ToSingle(packetData, 2),
                    player.GameObject.transform.position.y,
                    BitConverter.ToSingle(packetData, 6)
                );
                player.Movement.Rotation = BitConverter.ToSingle(packetData, 10);
                player.Movement.InputX = (sbyte)packetData[14];
                player.Movement.InputZ = (sbyte)packetData[15];
                break;
        }
    }
}
