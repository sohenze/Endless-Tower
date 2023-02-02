using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    private PlayerEquipment playerEquipment;
    private PlayerData playerData;

    private static Vector2 spawnpoint = new Vector2(0.0f, -2.5f);
    private static Vector2 deathpoint = new Vector2(0.0f, -10.0f);

    void Awake() {
        playerEquipment = gameObject.GetComponent<PlayerEquipment>();

        //Loading save data
        playerData = SaveFileHandler.load();

        //Initialising stats
        atk = playerData.stats.atk;
        firerate = playerData.stats.firerate;
        critChance = playerData.stats.critChance;
        critDmg = playerData.stats.critDmg;
        maxHP = playerData.stats.maxHP;
        HPRegen = playerData.stats.HPRegen;
        defense = playerData.stats.defense;
        goldBonus = playerData.stats.goldBonus; 
        luck = playerData.stats.luck;

        atkMult = 1.0f; 
        firerateMult = 1.0f;   
        maxHPMult = 1.0f;   
        defenseMult = 1.0f;

        tycoon = playerData.perks.tycoon;
        legionnaire = playerData.perks.legionnaire;
        steelblood = playerData.perks.steelblood;
        mage = playerData.perks.mage;

        gold = 0f;

        isAlive = true;
        lives = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        gold += tycoon * 1000;
        killCount = 0;
        updateStats();
        currHP = maxHPFinal;
        
        InvokeRepeating("regen", 0, 1.0f);
        InvokeRepeating("updateStats", 0, 0.1f);
    }

    public void updateAtk() {
        atkFinal = atk * atkMult + playerEquipment.atk + (killCount * legionnaire / 2);
    }

    //Update current stats adding equipment stats + perks
    public void updateStats() {
        float legionnaireBonus = legionnaire > 0 ? (killCount * legionnaire / 2) : 0;
        float steelbloodBonus = steelblood > 0 ? (killCount * steelblood / 2) : 0;

        atkFinal = atk * atkMult + playerEquipment.atk + legionnaireBonus;
        firerateFinal = firerate * firerateMult + playerEquipment.firerate;
        if (firerateFinal > 20) {
            firerateFinal = 20;
        }
        critChanceFinal = critChance + playerEquipment.critChance;
        critDmgFinal = critDmg + playerEquipment.critDmg;
        maxHPFinal =  maxHP * maxHPMult + playerEquipment.maxHP;
        HPRegenFinal = HPRegen + playerEquipment.HPRegen;
        defenseFinal =  defense * defenseMult + playerEquipment.defense + steelbloodBonus;
    }

    void regen() {
        if (currHP + HPRegenFinal >= maxHPFinal) {
            currHP = maxHPFinal;
        } else {
            currHP += HPRegenFinal;
        }
    }

    //Gold
    public void earnGold(float amt) {
        gold += (goldBonus + 1) * amt;
    }

    public void spendGold(float amt) {
        gold -= amt;
    }
}
