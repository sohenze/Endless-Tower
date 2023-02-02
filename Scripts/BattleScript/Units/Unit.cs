using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private static Vector2 spawnpoint;
    private static Vector2 deathpoint;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
