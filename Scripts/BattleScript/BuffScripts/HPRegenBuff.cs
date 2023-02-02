using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPRegenBuff : MonoBehaviour
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

    void buff() {
        playerBuffs.HPRegenBuff();
        Destroy(gameObject.transform.parent.gameObject);
    }
}
