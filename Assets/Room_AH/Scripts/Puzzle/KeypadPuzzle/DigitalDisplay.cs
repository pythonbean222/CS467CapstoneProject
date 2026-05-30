using UnityEngine;
using TMPro;

// Code adapted from Alexander Zotov's video on creating a keypad puzzle in Unity:
// "Tutorial How To Make Simple Digital Code Lock With Display And Keypad For 2D Unity Game" 
// https://www.youtube.com/watch?v=mL-FLsV3WRs&t=2s
// Tutorial uses sprites for the buttons, was adapted to use Unity's UI Button component instead

public class DigitalDisplay : MonoBehaviour
{
    // reference to the text component on the display to show the entered code
    [SerializeField] private TMP_Text displayCharacters;

    [SerializeField] private string codeSequence = "";
    [SerializeField] private string correctCode = "1234";

    private LockerInteraction currentLocker;

    void Start() {
        // initialize display to be empty at the start
        displayCharacters.text = "";
        KeypadButtonPress.ButtonPressed += UpdateDisplay;
    }

    public void SetLocker(LockerInteraction locker) {
        // set the current locker reference so we can call its OpenLocker and CloseKeyPad methods when the correct code is entered
        currentLocker = locker;
    }

    private void UpdateDisplay(string buttonValue) {
        // handle special buttons like "Enter" and "Delete"
        switch (buttonValue) {
            case "Enter":
                 CheckResult();
                return;
            case "Delete":
                ResetDisplay();
                return;
        }

        // for number buttons, append the button's value to the code sequence and update the display, but limit to 4 characters
        if (codeSequence.Length < 4) {
            codeSequence += buttonValue;
            displayCharacters.text = codeSequence;
        }
    }

    private void ResetDisplay() {
        // clear the code sequence and reset the display text
        codeSequence = "";
        displayCharacters.text = "";
    }

    private void CheckResult() {
        // check if the entered code sequence matches the correct code
        if (codeSequence == correctCode) {
            Debug.Log("Correct Code");

            // if the code is correct, call the OpenLocker and CloseKeyPad methods on the current locker reference to open the locker and close the keypad UI
            if (currentLocker != null) {
                currentLocker.OpenLocker();
                currentLocker.CloseKeyPad();
            }
        } else {
            // if the code is incorrect, log a message and reset the display for another attempt
            Debug.Log("Incorrect Code");
        }

        // reset the display after checking the result
        ResetDisplay();
    }
}
