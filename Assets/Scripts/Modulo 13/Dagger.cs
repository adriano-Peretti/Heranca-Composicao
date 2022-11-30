using UnityEngine;

namespace Modulo13
{
    public class Dagger : Weapon, ISharpen
    {
        public float CritChance { get; private set; }

        public Dagger(float critChance) : base("Dagger", 6)
        {
            CritChance = critChance;
        }

        void ISharpen.Sharpen()
        {
            var newRank = Weapon.GetRank(Damage);

            Damage++;

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
}