using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldText : MonoBehaviour
{
    private PlayerEquipment playerEquipment;
    private TextMeshProUGUI text;

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
        text.text =
                    "Max HP: " + playerEquipment.maxHP.ToString("F1") + " + " + playerEquipment.maxHPNext.ToString("0") +
                    "\nHP Regen: " + playerEquipment.HPRegen.ToString("F1") + " + " + playerEquipment.HPRegenNext.ToString("F1") +
                    "\nDefense: " + playerEquipment.defense.ToString("F1") + " + " + playerEquipment.defenseNext.ToString("F1");
    }
}
