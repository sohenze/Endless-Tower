using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour
{
    private HideUIScreens hider;

    void Awake() {
        hider = GameObject.Find("Canvas").GetComponent<HideUIScreens>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleShow() {
        if (gameObject.activeSelf) {
            hider.hideAll();
        } else {
            hider.hideAll();
            gameObject.SetActive(true);
        }
    }


}
