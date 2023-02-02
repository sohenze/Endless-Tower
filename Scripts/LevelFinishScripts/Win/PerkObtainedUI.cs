using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerkObtainedUI : MonoBehaviour
{
    private WinUpdate winUpdate;
    private TextMeshProUGUI perkText;
    private int perkObtained;

    void Awake() {
        winUpdate = GameObject.Find("PlayerDataUpdater").GetComponent<WinUpdate>();
        perkText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        perkObtained = winUpdate.perkObtained;
        
        if (perkObtained != -1) {
            switch (perkObtained)
            {
                case 0:
                    perkText.text = "Perk Obtained: Tycoon";
                    break;
                case 1:
                    perkText.text = "Perk Obtained: Legionnaire";
                    break;
                case 2:
                    perkText.text = "Perk Obtained: Steel Blood";
                    break;
                case 3:
                    perkText.text = "Perk Obtained: Mage";
                    break;
                case 4:
                    perkText.text = "Perk Obtained: Point Meister";
                    break;
            }
        }
    }
}
