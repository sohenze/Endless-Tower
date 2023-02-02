using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
