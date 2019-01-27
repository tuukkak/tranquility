using UnityEngine;

public class Player
{
    public byte Id { get; private set; }
    public string Name { get; private set; }
    public byte Team { get; private set; }
    public Hero Hero { get; private set; }
    public Movement Movement { get; private set; }
    public GameObject GameObject { get; set; }
    public Player Target { get; set; }
    public int Health { get; set; }

    public Player(byte id, string name, byte team, int heroId)
    {
        Id = id;
        Name = name;
        Team = team;
        Hero = State.Heroes.Find(h => h.Id == heroId);
        Movement = new Movement();
        Health = Hero.BaseHealth;
    }
}
