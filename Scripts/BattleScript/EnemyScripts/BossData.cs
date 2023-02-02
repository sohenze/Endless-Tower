using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossData
{
    public BossStats[] stats;
}

[System.Serializable]
public class BossStats
{
    public int level;
    public float atk;
    public float firerate;
    public float critChance;
    public float critDmg;
    public float maxHP;
    public float HPRegen;
    public float defense;
}
