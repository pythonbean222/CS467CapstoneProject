using System.Collections.Generic;
using UnityEngine;

// Script for managing the button puzzle in the puzzle room

public class ButtonManager : MonoBehaviour
{
    // Puzzle box manager
    [SerializeField] private PuzzlePrizeBox puzzleBox;

    [Header("Correct Order")]
    // store corect sequence of buttons
    [SerializeField] private List<string> correctSequence = new List<string>();

    [Header("Player Input")]
    // store button input as player presses
    [SerializeField] private List<string> currentInput = new List<string>();

    public List<PuzzleLightController> buttonLights;

    [Header("Current Puzzle State")]
    // track puzzle completion
    public bool solved = false;

    [Header("Audio")]
    // audio source and clips for button press, correct solution, and incorrect solution
    [SerializeField] private AudioSource puzzleAudio;
    [SerializeField] private AudioClip buttonPressSound;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip incorrectSound;

    public void PressButton(string buttonID) {
        // if already solved, return
        if (solved) return;

        // add pressed button via button ID
        currentInput.Add(buttonID);

        // check if correct number of buttons have been pressed and check solution
        if (currentInput.Count >= correctSequence.Count) {
            CheckSolution();
        }
    }

    public void PlayButtonPressSound() {
        // play button press sound
        if (puzzleAudio != null && buttonPressSound != null) {
            puzzleAudio.PlayOneShot(buttonPressSound);
        }
    }

    void CheckSolution() {
        bool correct = true;

        // check if each input matches the correct input
        for (int i = 0; i < currentInput.Count; i++) {
            // if not matching, break and reset puzzle
            if (currentInput[i] != correctSequence[i]) {
                correct = false;
                break;
            }
        }

        // if buttons are pressed in the correct order, it's solved
        if (correct) {
            SolvePuzzle();
        }
        // if not, reset count
        else {
            ResetPuzzle();
        }
    }

    void SolvePuzzle() {
        solved = true;

        // play correct sound
        if (puzzleAudio != null && correctSound != null) {
            puzzleAudio.PlayOneShot(correctSound);
        }

        // if puzzle is solved, button lights flash green
        foreach (var button in buttonLights) {
            button.FlashRight();
        }

        puzzleBox.OpenBox();

        // clear input
        currentInput.Clear();
    }

    void ResetPuzzle() {
        // play incorrect sound
        if (puzzleAudio != null && incorrectSound != null) {
            puzzleAudio.PlayOneShot(incorrectSound);
        }

        // if puzzle is not solved, button lights flash red
        foreach (var button in buttonLights) {
            button.FlashWrong();
        }

        // clear input
        currentInput.Clear();
    }
}
