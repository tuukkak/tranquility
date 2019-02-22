using System.Collections.Generic;

public static class State
{
    public static int CurrentPlayerId;
    public static Player CurrentPlayer;
    public static List<Hero> Heroes = new List<Hero>() { new Hero(id: 1, name: "Mage", speed: 5f, baseHealth: 2000) };
    public static List<Spell> Spells;
    public static List<Player> Players = new List<Player>();
    public static List<SpellAction> SpellActions = new List<SpellAction>();
}
