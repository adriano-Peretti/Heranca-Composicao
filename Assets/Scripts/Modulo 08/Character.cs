using System;
using UnityEngine;
public class Character
{
    public string Name { get; private set; }
    public int Life { get; private set; }
    public Weapon Weapon { get; private set; }
    public Armor Armor { get; private set; }
    public bool IsAlive { get => Life > 0; }

    public static event Action<string> OnAction;

    public Character(string name, int life, Weapon weapon, Armor armor)
    {
        Name = name;
        Life = life;
        Weapon = weapon;
        Armor = armor;
    }

    //Attack Enemy
    public void Attack(Character enemy)
    {
        if (!CheckAlive()) return;

        if (!enemy.IsAlive)
        {
            Debug.Log($"{enemy.Name} está morto.");
            OnAction?.Invoke($"{enemy.Name} está morto."); //Action
            return;
        }

        if (!HasWeapon()) return;

        Debug.Log($"{Name} atacou {enemy.Name} com sua {Weapon.Name}.");
        enemy.DealDamage(Weapon.Damage);
    }

    //Sharp weapon
    public void SharpenWeapon()
    {
        if (!CheckAlive()) return;

        if (!HasWeapon()) return;

        Debug.Log($"{Name} afiou sua {Weapon.Name}.");
        OnAction?.Invoke($"{Name} afiou sua {Weapon.Name}."); //Action
        Weapon.Sharpen();
    }

    //Unequip weapon
    public void UnequipWeapon()
    {
        if (!CheckAlive()) return;

        if (!HasWeapon()) return;

        Debug.Log($"{Name} desequipou sua {Weapon.Name}.");
        OnAction?.Invoke($"{Name} desequipou sua {Weapon.Name}."); //Action
        Weapon = null;
    }

    //Equip weapon
    public void EquipWeapon(Weapon weapon)
    {
        if (!CheckAlive()) return;

        if (Weapon != null)
        {
            Debug.Log($"{Name} já está com uma {Weapon.Name} equipada.");
            OnAction?.Invoke($"{Name} já está com uma {Weapon.Name} equipada."); //Action
        }
        else
        {
            Weapon = weapon;
            OnAction?.Invoke($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank})."); //Action
            Debug.Log($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank}).");
        }
    }

    //Unequip Armor
    public void UnequipArmor()
    {
        if (!CheckAlive()) return;
        if (!HasArmor()) return;

        Debug.Log($"{Name} retirou sua {Armor.Name}.");
        OnAction?.Invoke($"{Name} retirou sua {Armor.Name}."); //Action
        Armor = null;
    }

    //Equip Armor
    public void EquipArmor(Armor armor)
    {
        if (!CheckAlive()) return;
        if (Armor != null)
        {
            Debug.Log($"{Name} já está com uma {Armor.Name} equipada.");
            OnAction?.Invoke($"{Name} já está com uma {Armor.Name} equipada."); //Action
        }
        else
        {
            Armor = armor;
            Debug.Log($"{Name} equipou uma {Armor.Name} (Proteção: {Armor.Protection} - Rank: {Armor.Rank}).");
            OnAction?.Invoke($"{Name} equipou uma {Armor.Name} (Proteção: {Armor.Protection} - Rank: {Armor.Rank})."); //Action
        }
    }

    //Deal Damage to the enemy
    private void DealDamage(int damage)
    {
        if (Armor != null)
        {
            Armor.TakeDamage(damage);
            // If the armor is broken and there is still damage to be taken
            if (Armor.Protection <= 0)
            {
                Life += Armor.Protection;
                OnAction?.Invoke($"Sua {Armor.Name} foi quebrada."); //Action
                Armor = null;
            }

            int armorProtect = Armor == null ? 0 : Armor.Protection;

            OnAction?.Invoke($"{Name} levou {damage} de dano."); //Action
        }
        else
        {
            Life -= damage;
            OnAction?.Invoke($"{Name} levou {damage} de dano."); //Action
        }
        CheckAlive();
    }

    //Check if the player is still alive
    private bool CheckAlive()
    {
        if (!IsAlive)
        {
            Debug.Log($"{Name} já está morto.");
            OnAction?.Invoke($"{Name} já está morto."); //Action
        }

        return IsAlive;
    }

    //Check if has a weapon equiped
    private bool HasWeapon()
    {
        if (Weapon == null)
        {
            Debug.Log($"{Name} não está com nenhuma arma equipada.");
            OnAction?.Invoke($"{Name} não está com nenhuma arma equipada."); //Action
        }

        return Weapon != null;
    }

    //Check if has a armor equiped
    private bool HasArmor()
    {
        if (Armor == null)
        {
            Debug.Log($"{Name} não está com nenhuma armadura equipada.");
            OnAction?.Invoke($"{Name} não está com nenhuma armadura equipada."); //Action
        }

        return Armor != null;
    }
}