using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwordHeading : MonoBehaviour
{
    private PlayerEquipment playerEquipment;
    private TextMeshProUGUI text;
    private int swordTier;

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
        
        swordTier = playerEquipment.swordTier;
        string swordName = "";
        string swordLevel = " +" + playerEquipment.swordLevel;

        switch(swordTier) {
            case 0:
                swordName = "Sword";
                text.color = Color.white;
                break;
            case 1:
                swordName = "Iron Sword";
                text.color = Color.grey;
                break;
            case 2:
                swordName = "Gold Sword";
                text.color = Color.yellow;
                break;
            case 3:
                swordName = "Aqua Sword";
                text.color = Color.cyan;
                break;
            case 4:
                swordName = "Emerald Sword";
                text.color = new Color(0, 90, 0, 1);
                break;    
            default:
                swordName = "Demon Sword";
                text.color = Color.red;
                break;
        }

        text.text = swordName + "\n" + swordLevel;
    }
}
