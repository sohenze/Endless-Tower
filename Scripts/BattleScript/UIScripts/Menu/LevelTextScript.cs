using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTextScript : MonoBehaviour
{
    private TextMeshProUGUI levelText;
    private int level;

    void Awake() {
        levelText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level = GameManager.gameLevel;
        levelText.text = "Level " + level;
    }
}
