using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleShow() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void show() {
        gameObject.SetActive(true);
    }
}
