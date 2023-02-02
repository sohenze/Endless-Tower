using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SteelBloodBody : MonoBehaviour
{
    private PlayerData playerData;
    private TextMeshProUGUI text;

    void Awake() {
        playerData = SaveFileHandler.load();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Gain " + (playerData.perks.steelblood * 0.5) + " defense per kill";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}