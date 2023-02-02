using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldUI : MonoBehaviour
{
    private Player player;
    private TextMeshProUGUI goldText;
    private float gold;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
        goldText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gold = player.gold;
        goldText.text = " $" + gold.ToString("0");
    }
}
