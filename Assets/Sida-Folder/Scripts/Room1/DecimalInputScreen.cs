// Citation for how to force the input field to activate/deactivate using a built in method: ActivateInputField()
// Date: 13 May, 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.InputField.ActivateInputField.html

// Citation for how to use the Event System SetSelectedGameObject() to set which UI GameObject currently has input focus
// Date: 13 May, 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.EventSystem.SetSelectedGameObject.html

// Citation for how to convert from Binary to Decimal using a built in C# method
// Date: 14 May, 2026
// Adapted from StackOverflow - How to convert binary to decimal
// Source URL: https://stackoverflow.com/questions/1961599/how-to-convert-binary-to-decimal

// Citation for how to convert from Decimal to Binary using a built in C# method
// Date: 14 May, 2026
// Adapted from StackOverflow - Convert integer to binary in C#
// Source URL: https://stackoverflow.com/questions/2954962/convert-integer-to-binary-in-c-sharp

// Citation for how to use the built-in PadLeft() method in C#
// Date: 14 May, 2026
// Adapted from StackOverflow - How to pad left a number with a specific amount of zeroes
// Source URL: https://stackoverflow.com/questions/11901395/how-to-pad-left-a-number-with-a-specific-amount-of-zeroes

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DecimalInputScreen : MonoBehaviour, IInteractable_SC
{
    [SerializeField] private Room1PuzzleManager puzzleManager;
    [SerializeField] private FPSController_SC playerController;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshPro binaryTextObject;

    [SerializeField] private string playerStringInput;
    [SerializeField] private string binaryString;
    [SerializeField] private string decimalString;
    [SerializeField] private Canvas interactPrompt;
    [SerializeField] private Canvas pressEnterPrompt;

    [SerializeField] private AudioSource decimalWallAudioSource;
    [SerializeField] private AudioClip decimalWallCorrect;
    [SerializeField] private AudioClip decimalWallIncorrect;

    private bool isActive;
    private bool isSolved;

    void Start()
    {
        // Generate a random value from 0 to 15
        decimalString = UnityEngine.Random.Range(0, 16).ToString();

        // Convert Randomly Generated Value to Binary, AND PadLeft() with '0' when necessary
        binaryString = Convert.ToString(Convert.ToByte(decimalString), 2).PadLeft(4, '0');

        // Update the in-game Binary Text Object
        UpdateBinaryText();
    }

    void UpdateBinaryText()
    {
        binaryTextObject.text = binaryString;
    }

    public void Interact()
    {
        if (!isActive & !isSolved)
        {
            playerController.enabled = false;

            // Set the SelectedGameObject to the inputField we're interacting with
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);

            // Force the input field to activate immediately rather than requiring player to click it
            inputField.ActivateInputField();

            // Set the input text color to white
            inputField.textComponent.color = Color.white;

            // Hide the interact prompt
            interactPrompt.gameObject.SetActive(false);

            // Display the Press Enter to confirm value prompt
            pressEnterPrompt.gameObject.SetActive(true);

            isActive = true;
        }
    }

    private void CloseUI()
    {
        playerStringInput = inputField.text;

        playerController.enabled = true;

        // Clear the SelectedGameObject to prevent being able to interact when out of range
        EventSystem.current.SetSelectedGameObject(null);

        // Force the input field to Deactivate immediately
        inputField.DeactivateInputField();

        // Reveal the interact prompt
        interactPrompt.gameObject.SetActive(true);

        // Hide the Press Enter to confirm value prompt
        pressEnterPrompt.gameObject.SetActive(false);

        CheckIfPuzzleSolved();
    }

    private void CheckIfPuzzleSolved()
    {
        if (playerStringInput == decimalString)
        {
            Debug.Log("Conversion Puzzle Solved!");

            // Play Correct Audio
            decimalWallAudioSource.PlayOneShot(decimalWallCorrect);

            // This Bool is necessary to prevent the user from being able to interact with the input field after getting it correct
            isSolved = true;

            // Change the text color to Green to display they're correct
            inputField.textComponent.color = Color.green;

            // Communicate with the Puzzle Manager
            puzzleManager.BinaryPuzzle();

        }
        else
        {
            // Play Incorrect Audio
            decimalWallAudioSource.PlayOneShot(decimalWallIncorrect);

            // Change the text color to Red to display they're wrong
            inputField.textComponent.color = Color.red;
        }

        isActive = false;
    }

    // A method that provides a brief delay to prevent timing issues
    private IEnumerator BriefDelay()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
