using UnityEngine;
using System;
using UnityEngine.UI;

// Code adapted from Alexander Zotov's video on creating a keypad puzzle in Unity:
// "Tutorial How To Make Simple Digital Code Lock With Display And Keypad For 2D Unity Game" 
// https://www.youtube.com/watch?v=mL-FLsV3WRs&t=2s
// Tutorial uses sprites for the buttons, was adapted to use Unity's UI Button component instead

public class KeypadButtonPress : MonoBehaviour
{
    // event to notify when a button is pressed, passing the button's value as a string
    public static event Action<string> ButtonPressed = delegate { };
    private string buttonValue;

    void Start() {
        // assumes button game objects are named in the format "Value_Button", e.g. "1_Button", "Enter_Button"
        buttonValue = gameObject.name.Split('_')[0];
        GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked() {
        // invoke the event, passing the button's value
        ButtonPressed(buttonValue);
    }
}
