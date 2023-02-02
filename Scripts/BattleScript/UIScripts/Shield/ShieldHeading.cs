using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldHeading : MonoBehaviour
{
    private PlayerEquipment playerEquipment;
    private TextMeshProUGUI text;
    private int shieldTier;

    void Awake() {
        playerEquipment = GameObject.Find("Player").GetComponent<PlayerEquipment>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shieldTier = playerEquipment.shieldTier;
        string shieldName = "";
        string shieldLevel = " +" + playerEquipment.shieldLevel;

        switch(shieldTier) {
            case 0:
                shieldName = "Shield";
                text.color = Color.white;
                break;
            case 1:
                shieldName = "Iron Shield";
                text.color = Color.grey;
                break;
            case 2:
                shieldName = "Gold Shield";
                text.color = Color.yellow;
                break;
            case 3:
                shieldName = "Aqua Shield";
                text.color = Color.cyan;
                break; 
            case 4:
                shieldName = "Emerald Shield";
                text.color = new Color(0, 90, 0, 1);
                break; 
            default:
                shieldName = "Demon Shield";
                text.color = Color.red;
                break;
        }

        text.text = shieldName + "\n" + shieldLevel;
    }
}
