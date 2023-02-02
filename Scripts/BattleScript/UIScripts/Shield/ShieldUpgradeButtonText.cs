using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldUpgradeButtonText : MonoBehaviour
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
        text.text = "$" + playerEquipment.shieldCost;
    }
}
