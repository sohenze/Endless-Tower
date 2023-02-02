using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndlessLevelText : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Awake() {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = SelectLevelScript.endlessLevel.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(transform.parent.GetComponent<Button>().interactable);
    }
}
