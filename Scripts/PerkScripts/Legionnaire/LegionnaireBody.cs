using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LegionnaireBody : MonoBehaviour
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
        text.text = "Gain " + (playerData.perks.legionnaire * 0.5) + " attack per kill";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}