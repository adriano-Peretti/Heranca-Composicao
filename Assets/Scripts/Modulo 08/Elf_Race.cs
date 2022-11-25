public class Elf_Race : Character
{
    public new int Life;
    public int Healing;

    public Elf_Race(string name, int life, Weapon weapon, Armor armor) : base(name, life, weapon, armor)
    {
        Life = life;
    }

    public void Healling()
    {
        Life += (Healing / 100);
    }
}