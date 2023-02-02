using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsPlayerEquipment : MonoBehaviour
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
            "+ " + playerEquipment.atk.ToString("F1") +
            "\n+ " + playerEquipment.firerate.ToString("F1") + 
            "\n+ " + playerEquipment.critChance.ToString("P0") + 
            "\n+ " + playerEquipment.critDmg.ToString("P0") +
            "\n+ " + playerEquipment.maxHP.ToString("F1") +
            "\n+ " +  playerEquipment.HPRegen.ToString("F1") +
            "\n+ " + playerEquipment.defense.ToString("F1");
    }
}
