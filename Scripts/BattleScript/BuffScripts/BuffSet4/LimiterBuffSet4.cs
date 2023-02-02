using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimiterBuffSet4 : MonoBehaviour
{
    private PlayerBuffs playerBuffs;
    private BuffSpawn buffSpawn;

    void Awake() {
        playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
        buffSpawn = GameObject.Find("BuffSpawn").GetComponent<BuffSpawn>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (playerBuffs.fireballCounter >= playerBuffs.fireballLimit &&
            playerBuffs.shadowballCounter >= playerBuffs.shadowballLimit &&
            playerBuffs.pulseCounter >= playerBuffs.pulseLimit) 
            {
                Destroy(gameObject);
                buffSpawn.CreateBuff();
            }
        
        InvokeRepeating("checkFull", 0, 1.0f);
    }

    void Update() {
        
    }


    void checkFull() {
        if (playerBuffs.fireballCounter >= playerBuffs.fireballLimit &&
            playerBuffs.shadowballCounter >= playerBuffs.shadowballLimit &&
            playerBuffs.pulseCounter >= playerBuffs.pulseLimit) 
            {
                Destroy(gameObject);  
            }
    }
}