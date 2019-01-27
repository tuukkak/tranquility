public class Hero
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public float Speed { get; private set; }
    public int BaseHealth { get; private set; }

    public Hero(int id, string name, float speed, int baseHealth)
    {
        Id = id;
        Name = name;
        Speed = speed;
        BaseHealth = baseHealth;
    }
}
