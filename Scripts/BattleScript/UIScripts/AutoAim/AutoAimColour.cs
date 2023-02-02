using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoAimColour : MonoBehaviour
{
    public Button button;

    private ColorBlock offCB;
    private ColorBlock onCB;
    private Color onColor;

    void Awake() {
        button = gameObject.GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        onColor = new Color(255, 255, 0, 255);
        offCB = button.colors;

        onCB = ColorBlock.defaultColorBlock;
        onCB.normalColor = onColor;
        onCB.highlightedColor = onColor;
        onCB.selectedColor = onColor;

    }

    public void toggleColor() {
        if (button.colors == offCB) {
            button.colors = onCB;
        } else {
            button.colors = offCB;
        }
    }
}
