using UnityEngine;
using System;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=mL-FLsV3WRs&t=2s

public class KeypadButtonPress : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };
    private string buttonValue;

    void Start() {
        buttonValue = gameObject.name.Split('_')[0];

        GetComponent<Button>().onClick.AddListener(ButtonClicked);
        
    }

    private void ButtonClicked() {
        ButtonPressed(buttonValue);
    }
}
