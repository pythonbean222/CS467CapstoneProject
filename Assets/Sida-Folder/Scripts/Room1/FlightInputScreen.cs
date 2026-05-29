using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlightInputScreen : MonoBehaviour, IInteractable_SC
{
    [SerializeField] private Room1PuzzleManager puzzleManager;
    [SerializeField] private FPSController_SC playerController;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Canvas interactPrompt;
    [SerializeField] private Canvas pressEnterPrompt;

    [SerializeField] private string playerStringInput;

    [SerializeField] private AudioSource flightCanvasAudioSource;
    [SerializeField] private AudioClip flightCorrect;
    [SerializeField] private AudioClip flightIncorrect;
    [SerializeField] private AudioClip flightWallMovement;
    [SerializeField] private AudioClip flightAmbience;
    [SerializeField] private AudioClip endDoorOpen;

    private bool isActive;
    private bool isSolved;

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

    /*
    Interesting Unity Quirk I stumbled upon:
    Turns out that an OnClick event can use a Private Method that is assigned PRIOR to being made Private.
    Initially CloseUI() was public, but later modified to private to prevent conflicts.
    Despite CloseUI() no longer showing up as an available option in the OnClick() event drop-down,
    it's reference to the private method is still active.

    The Link below is a forum related to this Quirk:
    https://issuetracker.unity3d.com/issues/onclick-event-can-use-private-method-when-that-method-is-assigned-before-being-made-private
    */
    private void CloseUI()
    {
        playerStringInput = inputField.text;

        playerController.enabled = true;

        // Clear the SelectedGameObject to prevent being able to interact when out of range
        EventSystem.current.SetSelectedGameObject(null);

        // Force the input field to Deactivate immediately
        inputField.DeactivateInputField();

        // Hide the interact prompt
        interactPrompt.gameObject.SetActive(true);

        // Hide the Press Enter to confirm value prompt
        pressEnterPrompt.gameObject.SetActive(false);

        CheckIfPuzzleSolved();
    }

    private void CheckIfPuzzleSolved()
    {
        if (playerStringInput.ToUpper() == "FLIGHT")
        {
            // This Bool is necessary to prevent the user from being able to interact with the input field after getting it correct
            isSolved = true;

            // Play Correct Sound
            flightCanvasAudioSource.PlayOneShot(flightCorrect);
            flightCanvasAudioSource.PlayOneShot(flightAmbience);
            flightCanvasAudioSource.PlayOneShot(flightWallMovement);

            // Start Door Audio Coroutine
            StartCoroutine(DoorAudioDelay());

            // Change the text color to Green to display they're correct
            inputField.textComponent.color = Color.green;

            // Communicate with the Puzzle Manager
            puzzleManager.FlightPuzzle();

        }
        else
        {
            // Play Incorrect Sound
            flightCanvasAudioSource.PlayOneShot(flightIncorrect);

            // Change the text color to Red to display they're wrong
            inputField.textComponent.color = Color.red;
        }

        isActive = false;
    }

    private IEnumerator DoorAudioDelay()
    {
        yield return new WaitForSeconds(4.2f);

        // Play the End Door Opening Sound
        flightCanvasAudioSource.PlayOneShot(endDoorOpen);
    }
}
