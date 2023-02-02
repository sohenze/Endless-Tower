using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCountUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Awake() {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Kills: " + Player.killCount;
    }
}
