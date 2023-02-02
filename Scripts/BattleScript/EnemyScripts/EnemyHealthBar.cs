using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Image fill;
    private Slider slider;
    private EnemyCombat enemy;

    void Awake() {
        enemy = transform.parent.parent.gameObject.GetComponent<EnemyCombat>();
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
        slider.value = Mathf.Clamp(enemy.currHP / enemy.maxHP, 0, 1f);
    }
}
