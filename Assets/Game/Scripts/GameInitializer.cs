using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject CameraPrefab;

    void Start()
    {
        InitializeSpells();
        InitializePlayers();
        StartInputHandler();
    }

    void InitializeSpells()
    {
        State.Spells = new List<Spell>() {
            new Spell(id: 1, heroId: 1, keyCode: "Alpha1", name: "Frostbolt", range: 30f, castTime: 2.3f, speed: 13f),
            new Spell(id: 2, heroId: 1, keyCode: "Alpha2", name: "Counter Spell", range: 20f)
        };
    }

    void InitializePlayers()
    {
        Player CurrentPlayer = State.Players.Find(p => p.Id == State.CurrentPlayer.Id);
        GameObject PlayerObject = SetupPlayer(CurrentPlayer);
        GameObject PlayerCamera = Instantiate(CameraPrefab, PlayerObject.transform);
        PlayerCamera.name = "PlayerCamera";
        State.Players.Remove(CurrentPlayer);

        foreach (Player Player in State.Players)
        {
            SetupPlayer(Player);
        }
    }

    GameObject SetupPlayer(Player Player)
    {
        GameObject PlayerObject = Instantiate(PlayerPrefab);
        Player.GameObject = PlayerObject;
        PlayerObject.GetComponent<PlayerController>().Player = Player;

        PlayerObject.transform.Find("Canvas/Text").gameObject.GetComponent<Text>().text = Player.Name;

        return PlayerObject;
    }

    void StartInputHandler()
    {
        gameObject.AddComponent<InputHandler>();
    }
}
