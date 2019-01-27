public class SpellAction {
    public enum ActionType { Start, Instant, Finish }
    public ActionType Type { get; private set; }
    public Player Caster { get; private set; }
    public Player Target { get; private set; }
    public Spell Spell { get; private set; }
    public int Damage { get; private set; }

    public SpellAction(ActionType type, Player caster, Player target, Spell spell, int damage = 0) {
        Type = type;
        Caster = caster;
        Target = target;
        Spell = spell;
        Damage = damage;
    }
}
