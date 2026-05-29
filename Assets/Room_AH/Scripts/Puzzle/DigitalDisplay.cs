using UnityEngine;
using TMPro;

public class DigitalDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text displayCharacters;

    [SerializeField] private string codeSequence = "";
    [SerializeField] private string correctCode = "1234";

    private LockerInteraction currentLocker;

    void Start() {
        displayCharacters.text = "";

        KeypadButtonPress.ButtonPressed += UpdateDisplay;
    }

    public void SetLocker(LockerInteraction locker) {
        currentLocker = locker;
    }

    private void UpdateDisplay(string buttonValue) {
        switch (buttonValue) {
            case "Enter":
                 CheckResult();
                return;
            case "Delete":
                ResetDisplay();
                return;
        }

        if (codeSequence.Length < 4) {
            codeSequence += buttonValue;
            displayCharacters.text = codeSequence;
        }
    }

    private void ResetDisplay() {
        codeSequence = "";
        displayCharacters.text = "";
    }

    private void CheckResult() {
        if (codeSequence == correctCode) {
            Debug.Log("Correct Code");

            if (currentLocker != null) {
                currentLocker.OpenLocker();
                currentLocker.CloseKeyPad();
            }
        } else {
            Debug.Log("Incorrect Code");
        }

        ResetDisplay();
    }
}
