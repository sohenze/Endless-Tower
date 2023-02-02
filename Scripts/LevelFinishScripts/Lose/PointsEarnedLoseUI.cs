using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsEarnedLoseUI : MonoBehaviour
{
    private LoseUpdate loseUpdate;
    private TextMeshProUGUI pointsText;
    private float points;

    void Awake() {
        loseUpdate = GameObject.Find("PlayerDataUpdater").GetComponent<LoseUpdate>();
        pointsText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        points = loseUpdate.pointsGained;
        pointsText.text = points.ToString();
    }
}
