using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossAnnounceUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Awake() {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("toggleShow", GameManager.bossTime);
        Invoke("toggleShow", GameManager.bossTime + GameManager.bossBuffer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void toggleShow() {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
