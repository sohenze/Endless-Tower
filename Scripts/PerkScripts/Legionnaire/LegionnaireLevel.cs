using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LegionnaireLevel : MonoBehaviour
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
        text.text = "Level: " + playerData.perks.legionnaire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}