using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private Image fill;
    private Slider slider;
    private BossCombat boss;

    void Awake() {
        boss = transform.parent.parent.gameObject.GetComponent<BossCombat>();
        slider = gameObject.GetComponent<Slider>();
        fill = transform.Find("Fill").GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Mathf.Clamp(boss.currHP / boss.maxHP, 0, 1f);
    }
}
