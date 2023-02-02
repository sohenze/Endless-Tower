using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsFinal : MonoBehaviour
{
    private Player player;
    private TextMeshProUGUI text;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
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
            player.atkFinal.ToString("F1") +
            "\n" + player.firerateFinal.ToString("F1") + 
            "\n" + (player.critChanceFinal).ToString("P0") +
            "\n" + (player.critDmgFinal).ToString("P0") +
            "\n" + player.maxHPFinal.ToString("0") +  
            "\n" + player.HPRegenFinal.ToString("F1") +
            "\n" + player.defenseFinal.ToString("F1") +
            "\n" + (player.goldBonus).ToString("P0") +
            "\n" + (player.luck).ToString("P0");
    }
}
