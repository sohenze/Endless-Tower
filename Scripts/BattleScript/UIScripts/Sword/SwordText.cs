using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwordText : MonoBehaviour
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
                    "Attack: " + playerEquipment.atk.ToString("F1") + " + " + playerEquipment.atkNext.ToString("0") +
                    "\nFirerate: " + playerEquipment.firerate.ToString("F1") + " + " + playerEquipment.firerateNext.ToString("F1") +
                    "\nCrit Chance: " + (playerEquipment.critChance).ToString("P0") + " + " + (playerEquipment.critChanceNext).ToString("P0") +
                    "\nCrit Damage: " + (playerEquipment.critDmg).ToString("P0") + " + " + (playerEquipment.critDmgNext).ToString("P0");
    }
}
