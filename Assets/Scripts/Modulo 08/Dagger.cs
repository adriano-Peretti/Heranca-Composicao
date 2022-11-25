using UnityEngine;


public class Dagger : Weapon
{
    public float CritChance { get; private set; }

    public Dagger(float critChance) : base("Dagger", 6)
    {
        CritChance = critChance;
    }

    public Dagger(string name, int damage, float critChance) : base(name, damage)
    {
        CritChance = critChance;
    }

    public override int Swing()
    {
        Debug.Log("Stab! Stab!");

        var finalDamage = Damage;

        if (Random.Range(0f, 1f) < CritChance)
        {
            Debug.Log("Critical Hit!");
            finalDamage *= 2;
        }
        return finalDamage;
    }
}