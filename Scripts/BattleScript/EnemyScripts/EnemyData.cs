using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public EnemyStats[] stats;
}

[System.Serializable]
public class EnemyStats
{
    public int level;
    public float atk;
    public float maxHP;
    public float HPRegen;
    public float defense;
    public float gold;
    public float buffChance;
}