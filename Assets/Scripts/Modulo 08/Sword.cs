using UnityEngine;

public class Sword : Weapon
{
    public Sword() : base("Sword", 8) { }

    public Sword(int damage) : base("Sword", damage) { }

    public override int Swing()
    {
        Debug.Log("Slash! Slash!");
        return Damage;
    }

    public override void Sharpen()
    {
        Damage++;
        base.Sharpen();
    }

}