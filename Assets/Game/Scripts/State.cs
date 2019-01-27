using System.Collections.Generic;

public static class State
{
    public static Player CurrentPlayer;
    public static List<Hero> Heroes;
    public static List<Spell> Spells;
    public static List<Player> Players;
    public static List<SpellAction> SpellActions = new List<SpellAction>();
}
