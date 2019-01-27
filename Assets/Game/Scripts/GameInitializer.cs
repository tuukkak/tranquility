using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject CameraPrefab;

    void Start()
    {
        InitializeHeroes();
        InitializeSpells();
        InitializePlayers();
        StartInputHandler();
    }

    void InitializeHeroes()
    {
        State.Heroes = new List<Hero>() {
            new Hero(id: 1, name: "Mage", speed: 5f, baseHealth: 2000)
        };
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
        State.Players = new List<Player>() {
            new Player(id: 1, name: "Player 1", team: 1, heroId: 1),
            new Player(id: 2, name: "Player 2", team: 1, heroId: 1),
            new Player(id: 3, name: "Player 3", team: 2, heroId: 1),
            new Player(id: 4, name: "Player 4", team: 2, heroId: 1)
        };

        State.CurrentPlayer = State.Players.Find(p => p.Id == 1);

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
