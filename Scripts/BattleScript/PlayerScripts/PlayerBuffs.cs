using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{
    private Player player;
    private PlayerMovement playerMovement;

    public int fireballCounter;
    public int shadowballCounter;
    public int pulseCounter;
    public int fireballLimit;
    public int shadowballLimit;
    public int pulseLimit;


    void Awake() {
        player = gameObject.GetComponent<Player>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fireballCounter = 0;
        shadowballCounter = 0;
        pulseCounter = 0;
        fireballLimit = 10;
        shadowballLimit = 10;
        pulseLimit = 5;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Buffs
    public void atkBuff() {
        player.atkMult += 0.15f;
    }

    public void hpBuff() {
        player.maxHPMult += 0.15f;
    }

    public void lifeBuff() {
        player.lives++;
    }

    public void firerateBuff() {
        player.firerateMult += 0.10f;
    }

    public void defenseBuff() {
        player.defenseMult += 0.15f;
    }

    public void critDmgBuff() {
        player.critDmg += 0.2f;
    }

    public void critChanceBuff() {
        player.critChance += 0.03f;
    }

    public void HPRegenBuff() {
        player.HPRegen += 0.5f;
    }

    public void goldBonusBuff() {
        player.goldBonus += 0.05f;
    }

    public void FireballBuff() {
        playerMovement.startFireball();
        fireballCounter++;
    }

    public void ShadowballBuff() {
        playerMovement.startShadowball();
        shadowballCounter++;
    }

    public void PulseBuff() {
        playerMovement.startPulse();
        pulseCounter++;
    }
}
