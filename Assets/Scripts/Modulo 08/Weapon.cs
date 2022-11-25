using UnityEngine;
public abstract class Weapon
{
    public string Name { get; private set; }
    public int Damage { get; set; }
    public char Rank { get; private set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
        Rank = GetRank(damage);
    }
    public virtual void Sharpen()
    {
        var newRank = Weapon.GetRank(Damage);

        if (Damage == 10)
        {
            Debug.Log($"Sua {Name} já possui o maior dano possivel.");
        }
        else
        {
            Damage++;
            Damage = Mathf.Clamp(Damage, 0, 10);
            Debug.Log($"{Name} foi afiada! Dano aumentou para {Damage}.");
        }

        if (newRank != Rank)
        {
            Rank = newRank;
            Debug.Log($"Rank da {Name} aumentou para {Rank}!");
        }
    }

    public abstract int Swing();

    public static char GetRank(int damage)
    {
        if (damage >= 10)
        {
            return 'S';
        }
        else if (damage >= 7)
        {
            return 'A';
        }
        else if (damage >= 4)
        {
            return 'B';
        }

        return 'C';
    }
}
