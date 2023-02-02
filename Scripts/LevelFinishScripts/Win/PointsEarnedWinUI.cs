using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsEarnedWinUI : MonoBehaviour
{
    private WinUpdate winUpdate;
    private TextMeshProUGUI pointsText;
    private float points;

    void Awake() {
        winUpdate = GameObject.Find("PlayerDataUpdater").GetComponent<WinUpdate>();
        pointsText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        points = winUpdate.pointsGained;
        pointsText.text = points.ToString();
    }
}
