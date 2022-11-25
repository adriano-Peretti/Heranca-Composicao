using System;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    private Character _player1;
    private Character _player2;
    private List<Character> listPlayers = new List<Character>();
    public static event Action<List<Character>> OnCharacter;

    void Start()
    {
        var sword = new Sword();
        var dagger = new Dagger(0.1f);

        var armorGold = new Armor("Gold Armor", 30);
        var armorSilver = new Armor("Silver Armor", 20);

        _player1 = new Character("Adriano", 100, sword, armorSilver);
        _player2 = new Character("Alan", 100, dagger, armorGold);

        listPlayers.Add(_player1);
        listPlayers.Add(_player2);

        OnCharacter?.Invoke(listPlayers);
    }

    void Update()
    {
        Player1Commands();
        Player2Commands();
    }


    public void Player1Commands()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _player1.Attack(_player2);
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _player1.SharpenWeapon();
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _player1.UnequipWeapon();
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _player1.EquipWeapon(GetRandomWeapon());
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _player1.UnequipArmor();
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _player1.EquipArmor(new Armor("Random Armor", UnityEngine.Random.Range(5, 30))); ;
            OnCharacter?.Invoke(listPlayers);
        }
    }

    public void Player2Commands()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _player2.Attack(_player1);
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _player2.SharpenWeapon();
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _player2.UnequipWeapon();
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _player2.EquipWeapon(GetRandomWeapon());
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _player2.UnequipArmor();
            OnCharacter?.Invoke(listPlayers);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _player2.EquipArmor(new Armor("Random Armor", UnityEngine.Random.Range(5, 30)));
            OnCharacter?.Invoke(listPlayers);
        }
    }

    private Weapon GetRandomWeapon()
    {
        var randomWeapon = UnityEngine.Random.Range(0, 2);

        switch (randomWeapon)
        {
            default:
            case 0:
                return new Sword();

            case 1:
                return new Dagger(0.1f);
        }
    }
}