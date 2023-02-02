using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballBuff : MonoBehaviour
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
        if (playerBuffs.fireballCounter >= playerBuffs.fireballLimit) {
            button.interactable = false;
        }
    }

    void buff() {
        playerBuffs.FireballBuff();
        Destroy(gameObject.transform.parent.gameObject);
    }

}

