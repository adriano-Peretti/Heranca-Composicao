using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Interation : MonoBehaviour
{
    public List<TextMeshProUGUI> players = new List<TextMeshProUGUI>();
    public TextMeshProUGUI Action;

    void Start()
    {
        SystemManager.OnCharacter += LifeEventHandler;
        Character.OnAction += ActionEvent;
    }

    //UI
    private void LifeEventHandler(List<Character> listPlayer)
    {
        int i = 0;
        foreach (TextMeshProUGUI infoPlayer in players)
        {
            infoPlayer.text = ($"{listPlayer[i].Name} \n") +
            (listPlayer[i].Life <= 0 ? "Morreu \n" : $"{listPlayer[i].Life} \n") +
            (listPlayer[i].Weapon == null ? "Sem arma \n" : $"Arma: {listPlayer[i].Weapon.Damage} Dano: {listPlayer[i].Weapon.Damage} \n") +
            (listPlayer[i].Armor == null ? "Sem armadura \n" : $"Armadura: {listPlayer[i].Armor.Name} \n Proteção: {listPlayer[i].Armor.Protection}");
            i++;
        }
    }

    private void ActionEvent(string action)
    {
        Action.text = action;
    }
}
