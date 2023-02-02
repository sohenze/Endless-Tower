using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MageBody : MonoBehaviour
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
        text.text = "Start with " + playerData.perks.mage + " fireball, shadowball and pulse";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}