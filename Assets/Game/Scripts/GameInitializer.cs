using System;
using System.Collections.Generic;
using UnityEngine;

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
        foreach (Player Player in State.Players)
        {
            GameObject PlayerObject = Instantiate(PlayerPrefab);
            Player.GameObject = PlayerObject;
            PlayerObject.GetComponent<PlayerController>().Player = Player;

            if (Player.Id == State.CurrentPlayer.Id)
            {
                Instantiate(CameraPrefab, PlayerObject.transform);
            }
        }
    }

    void StartInputHandler()
    {
        gameObject.AddComponent<InputHandler>();
    }
}
