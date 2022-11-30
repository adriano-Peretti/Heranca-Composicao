public class Ork : Character
{
    public int Force { get; private set; }

    public Ork(string name, int life, Weapon weapon, Armor armor, int force) : base(name, life, weapon, armor)
    {
        Force = force;
    }

    public void BoostDamage()
    {
        Weapon.Damage += (Force / 100);
    }
}