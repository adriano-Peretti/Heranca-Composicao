using UnityEngine;

namespace Modulo13
{
    public class Sword : Weapon, ISharpen
    {
        public Sword() : base("Sword", 8) { }

        public Sword(int damage) : base("Sword", damage) { }

        public override int Swing()
        {
            Debug.Log("Slash! Slash!");
            return Damage;
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
    }
}