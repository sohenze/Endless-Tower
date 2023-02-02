using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowballBuff : MonoBehaviour
{
    private PlayerBuffs playerBuffs;
    private Button button;

    void Awake() {
        playerBuffs = GameObject.Find("Player").GetComponent<PlayerBuffs>();
        button = gameObject.GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(buff);
    }

    void Update() {
        if (playerBuffs.shadowballCounter >= playerBuffs.shadowballLimit) {
            button.interactable = false;
        }
    }

    void buff() {
        playerBuffs.ShadowballBuff();
        Destroy(gameObject.transform.parent.gameObject);
    }

}
