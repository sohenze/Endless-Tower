using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MageLevel : MonoBehaviour
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
        text.text = "Level: " + playerData.perks.mage;
        if (playerData.perks.mage == 1) {
            text.text += " (MAX)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
