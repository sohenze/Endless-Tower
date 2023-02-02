using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int versionCode;
    public int id;
    public int points;
    public PlayerStats stats;
    public PlayerLevels levels;
    public PlayerPerks perks;
}

[System.Serializable]
public class PlayerStats
{
    public float atk;
    public float firerate;
    public float critChance;
    public float critDmg;
    public float maxHP;
    public float HPRegen;
    public float defense;
    public float goldBonus;
    public float luck;

    public int atkCost;
    public int firerateCost;
    public int critChanceCost;
    public int critDmgCost;
    public int maxHPCost;
    public int HPRegenCost;
    public int defenseCost;
    public int goldBonusCost;
    public int luckCost;
}

[System.Serializable]
public class PlayerLevels
{
    public bool level0;
    public bool level1;
    public bool level2;
    public bool level3;
    public bool level4;
    public bool level5;
    public bool level6;
    public bool level7;
    public bool level8;
    public bool level9;
    public bool level10;
    public bool endless;
    public int endlessLevel;
}

[System.Serializable]
public class PlayerPerks
{
    public int tycoon; //for each level start with +1000 gold (NO LIMIT)
    public int legionnaire; //for each level +0.5atk for each kill (NO LIMIT)
    public int steelblood; //for each level +0.5def for each kill (NO LIMIT)
    public int mage; //start game with fireball, shadowball, pulse (LIMIT: 1)
    public int pointmeister; //for each level 20% bonus points (LIMIT: 5)
}