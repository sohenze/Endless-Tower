using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPIndicatorUI : MonoBehaviour
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
        text.text = player.currHP.ToString("0") + "/" + player.maxHPFinal.ToString("0");
    }
}
