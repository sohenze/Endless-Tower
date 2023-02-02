using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsText : MonoBehaviour
{
    private Player player;
    private TextMeshProUGUI text;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text =  
            "Attack: " + (player.atk * player.atkMult).ToString("F1") + 
            "\nFirerate: " + (player.firerate * player.firerateMult).ToString("F1") + 
            "\nCrit Chance: " + (player.critChance).ToString("P0") + 
            "\nCrit Damage: " + (player.critDmg).ToString("P0") + 
            "\nMaxHP: " + (player.maxHP * player.maxHPMult).ToString("0") + 
            "\nHP Regen: " + player.HPRegen.ToString("F1") + 
            "\nDefense: " + (player.defense * player.defenseMult).ToString("F1") + 
            "\nGold Bonus: " + (player.goldBonus).ToString("P0") +
            "\nLuck: " + (player.luck).ToString("P0");
        
    }
}
