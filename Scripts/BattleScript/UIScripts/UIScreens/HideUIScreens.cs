using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIScreens : MonoBehaviour
{
    GameObject[] screens;

    void Awake() {
        screens = GameObject.FindGameObjectsWithTag("UIScreen");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideAll() {
        foreach (GameObject screen in screens) {
            screen.SetActive(false);
        }
    }
}
