using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    private PlayerEquipment playerEquipment;
    private static Vector2 spawnpoint = new Vector2(0.0f, -2.5f);
    private static Vector2 deathpoint = new Vector2(0.0f, -10.0f);
    
    private PlayerData playerData;

    public static float killCount;

    //For respawn
    public bool isAlive;
    public int lives;
    public float currHP;

    //Base Stats
    public float atk;
    public float firerate;
    public float critChance;
    public float critDmg;
    public float maxHP;
    public float HPRegen;
    public float defense;
    public float goldBonus;
    public float luck;

    //Multipliers
    public float atkMult;
    public float firerateMult;
    public float maxHPMult;
    public float defenseMult;

    //Final stats: base * multiplier + equipment
    public float atkFinal;
    public float firerateFinal;
    public float critChanceFinal;
    public float critDmgFinal;
    public float maxHPFinal;
    public float HPRegenFinal;
    public float defenseFinal;

    //Perks
    public int tycoon;
    public int legionnaire;
    public int steelblood;
    public int mage;

    //Gold
    public float gold;

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

    // Update is called once per frame
    void Update()
    {
        
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

    //Take damage
    public void takeDamage(float dmg) {
        if (dmg > 0) {
            if (dmg > defenseFinal) {
                currHP -= (dmg - defenseFinal);
                if (currHP <= 0 && isAlive) {
                    die();
                }
            }
        }
    }

    void regen() {
        if (currHP + HPRegenFinal >= maxHPFinal) {
            currHP = maxHPFinal;
        } else {
            currHP += HPRegenFinal;
        }
    }

    //Die
    void die() {
        lives -= 1;
        isAlive = false;
        transform.position = deathpoint;
        CancelInvoke("regen");
        
        if (lives <= 0) {
            GameObject.Find("GameManager").GetComponent<GameManager>().lose();
        }
    }

    //Spawn
    public void spawn() {
        currHP = maxHPFinal;
        isAlive = true;
        transform.position = spawnpoint;
        InvokeRepeating("regen", 0, 1.0f);
    }

    //Gold
    public void earnGold(float amt) {
        gold += (goldBonus + 1) * amt;
    }

    public void spendGold(float amt) {
        gold -= amt;
    }
}
