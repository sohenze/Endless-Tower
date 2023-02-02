using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{

    private Player player;
    private const int tierMax = 5;

    //Sword
    public float atk;
    public float firerate;
    public float critChance;
    public float critDmg;

    public float atkNext;
    public float firerateNext;
    public float critChanceNext;
    public float critDmgNext;

    public int swordTier;
    public int swordLevel;
    public float swordCost;

    //Shield
    public float maxHP;
    public float HPRegen;
    public float defense;

    public float maxHPNext;
    public float HPRegenNext;
    public float defenseNext;

    public int shieldTier;
    public int shieldLevel;
    public float shieldCost;

    void Awake() {
        player = gameObject.GetComponent<Player>();

        //Sword
        atk = 10f;
        firerate = 0.1f;
        critChance = 0.00f;
        critDmg = 0.0f;

        atkNext = SwordT0.atk;
        firerateNext = SwordT0.firerate;
        critChanceNext = SwordT0.critChance;
        critDmgNext = SwordT0.critDmg;

        swordTier = 0;
        swordLevel = 0;
        swordCost = SwordT0.swordCost;

        //Shield
        maxHP = 20f;
        HPRegen = 1.0f;
        defense = 0f;

        maxHPNext = ShieldT0.maxHP;
        HPRegenNext = ShieldT0.HPRegen;
        defenseNext = ShieldT0.defense;
        

        shieldTier = 0;
        shieldLevel = 0;
        shieldCost = ShieldT0.shieldCost;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update() {
        
    }

    public void upgradeSword() {
        if (player.gold >= swordCost) {
            player.spendGold(swordCost);
            swordLevel++;
            
            switch (swordTier) {
                case 0:   
                    atk += SwordT0.atk;
                    firerate += SwordT0.firerate;
                    critChance += SwordT0.critChance;
                    critDmg += SwordT0.critDmg;
                    break;

                case 1:
                    atk += SwordT1.atk;
                    firerate += SwordT1.firerate;
                    critChance += SwordT1.critChance;
                    critDmg += SwordT1.critDmg;
                    break;
                
                case 2:
                    atk += SwordT2.atk;
                    firerate += SwordT2.firerate;
                    critChance += SwordT2.critChance;
                    critDmg += SwordT2.critDmg;
                    break;

                case 3:
                    atk += SwordT3.atk;
                    firerate += SwordT3.firerate;
                    critChance += SwordT3.critChance;
                    critDmg += SwordT3.critDmg;
                    break;

                case 4:
                    atk += SwordT4.atk;
                    firerate += SwordT4.firerate;
                    critChance += SwordT4.critChance;
                    critDmg += SwordT4.critDmg;
                    break;

                default:
                    atk += SwordTMax.atk;
                    firerate += SwordTMax.firerate;
                    critChance += SwordTMax.critChance;
                    critDmg += SwordTMax.critDmg;
                    
                    break;
            }

            if (swordTier < tierMax) {
                if (swordLevel >= 6) {
                    swordLevel = 0;
                    swordTier++;
                }
            }

            switch (swordTier) {
                case 0:
                    break;
                case 1:
                    atkNext = SwordT1.atk;
                    firerateNext = SwordT1.firerate;
                    critChanceNext = SwordT1.critChance;
                    critDmgNext = SwordT1.critDmg;
                    swordCost = SwordT1.swordCost;  
                    break;
                case 2:
                    atkNext = SwordT2.atk;
                    firerateNext = SwordT2.firerate;
                    critChanceNext = SwordT2.critChance;
                    critDmgNext = SwordT2.critDmg;
                    swordCost = SwordT2.swordCost;
                    break;
                case 3:
                    atkNext = SwordT3.atk;
                    firerateNext = SwordT3.firerate;
                    critChanceNext = SwordT3.critChance;
                    critDmgNext = SwordT3.critDmg;
                    swordCost = SwordT3.swordCost;
                    break;
                case 4:
                    atkNext = SwordT4.atk;
                    firerateNext = SwordT4.firerate;
                    critChanceNext = SwordT4.critChance;
                    critDmgNext = SwordT4.critDmg;
                    swordCost = SwordT4.swordCost;
                    break;
                default:
                    atkNext = SwordTMax.atk;
                    firerateNext = SwordTMax.firerate;
                    critChanceNext = SwordTMax.critChance;
                    critDmgNext = SwordTMax.critDmg;
                    swordCost = SwordTMax.swordCost;
                    break;

            }
            
        }

        
    }

    public void upgradeShield() {
        if (player.gold >= shieldCost) {
            player.spendGold(shieldCost);
            shieldLevel++;
            
            switch (shieldTier) {
                case 0:
                    maxHP += ShieldT0.maxHP;
                    HPRegen += ShieldT0.HPRegen;
                    defense += ShieldT0.defense; 
                    break;
                
                case 1:
                    maxHP += ShieldT1.maxHP;
                    HPRegen += ShieldT1.HPRegen;
                    defense += ShieldT1.defense;
                    break;
                
                case 2:
                    maxHP += ShieldT2.maxHP;
                    HPRegen += ShieldT2.HPRegen;
                    defense += ShieldT2.defense;
                    break;
                
                case 3:
                    maxHP += ShieldT3.maxHP;
                    HPRegen += ShieldT3.HPRegen;
                    defense += ShieldT3.defense;
                    break;

                case 4:
                    maxHP += ShieldT4.maxHP;
                    HPRegen += ShieldT4.HPRegen;
                    defense += ShieldT4.defense;
                    break;
                
                default:
                    maxHP += ShieldTMax.maxHP;
                    HPRegen += ShieldTMax.HPRegen;
                    defense += ShieldTMax.defense;
                    break;
            }

            if (shieldTier < tierMax) {
                if (shieldLevel >= 6) {
                    shieldLevel = 0;
                    shieldTier++;
                }
            }

            switch (shieldTier) {
                case 0:
                    break;
                case 1:
                    maxHPNext = ShieldT1.maxHP;
                    HPRegenNext = ShieldT1.HPRegen;
                    defenseNext = ShieldT1.defense;
                    shieldCost = ShieldT1.shieldCost;
                    break;
                case 2:
                    maxHPNext = ShieldT2.maxHP;
                    HPRegenNext = ShieldT2.HPRegen;
                    defenseNext = ShieldT2.defense;
                    shieldCost = ShieldT2.shieldCost;
                    break;
                case 3:
                    maxHPNext = ShieldT3.maxHP;
                    HPRegenNext = ShieldT3.HPRegen;
                    defenseNext = ShieldT3.defense;
                    shieldCost = ShieldT3.shieldCost;
                    break;
                case 4:
                    maxHPNext = ShieldT4.maxHP;
                    HPRegenNext = ShieldT4.HPRegen;
                    defenseNext = ShieldT4.defense;
                    shieldCost = ShieldT4.shieldCost;
                    break;
                default:
                    maxHPNext = ShieldTMax.maxHP;
                    HPRegenNext = ShieldTMax.HPRegen;
                    defenseNext = ShieldTMax.defense;
                    shieldCost = ShieldTMax.shieldCost;
                    break;
            }
            
        }

         
    }


    //Equipment Tiers
    //Values are added per upgrade
    static class SwordT0 {
        public const float atk = 2f;
        public const float firerate = 0.0f;
        public const float critChance = 0.00f;
        public const float critDmg = 0.0f;

        public const float swordCost = 100f;
    }

    static class SwordT1 {
        public const float atk = 3f;
        public const float firerate = 0.0f;
        public const float critChance = 0.00f;
        public const float critDmg = 0.0f;

        public const float swordCost = 500f;
    }

    static class SwordT2 {
        public const float atk = 6f;
        public const float firerate = 0.1f;
        public const float critChance = 0.00f;
        public const float critDmg = 0.1f;

        public const float swordCost = 1000f;
    }

    static class SwordT3 {
        public const float atk = 15f;
        public const float firerate = 0.1f;
        public const float critChance = 0.01f;
        public const float critDmg = 0.1f;

        public const float swordCost = 5000f;
    }

    static class SwordT4 {
        public const float atk = 100f;
        public const float firerate = 0.1f;
        public const float critChance = 0.01f;
        public const float critDmg = 0.1f;

        public const float swordCost = 20000f;
    }

    static class SwordTMax {
        public const float atk = 500f;
        public const float firerate = 0.1f;
        public const float critChance = 0.05f;
        public const float critDmg = 0.1f;

        public const float swordCost = 100000f;
    }

    static class ShieldT0 {
        public const float maxHP = 10f;
        public const float HPRegen = 0.5f;
        public const float defense = 0.5f;

        public const float shieldCost = 100f;
    }

    static class ShieldT1 {
        public const float maxHP = 15f;
        public const float HPRegen = 1f;
        public const float defense = 1f;

        public const float shieldCost = 500f;
    }

    static class ShieldT2 {
        public const float maxHP = 20f;
        public const float HPRegen = 2f;
        public const float defense = 2f;

        public const float shieldCost = 1000f;
    }

    static class ShieldT3 {
        public const float maxHP = 30f;
        public const float HPRegen = 3f;
        public const float defense = 3f;

        public const float shieldCost = 5000f;
    }

    static class ShieldT4 {
        public const float maxHP = 50f;
        public const float HPRegen = 5f;
        public const float defense = 5f;

        public const float shieldCost = 10000f;
    }

    static class ShieldTMax {
        public const float maxHP = 100f;
        public const float HPRegen = 10f;
        public const float defense = 10f;

        public const float shieldCost = 100000f;
    }
}
