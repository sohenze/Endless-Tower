using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Image fill;
    private Slider slider;
    private Player player;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
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
        slider.value = Mathf.Clamp(player.currHP / player.maxHPFinal, 0, 1f);
    }
}
