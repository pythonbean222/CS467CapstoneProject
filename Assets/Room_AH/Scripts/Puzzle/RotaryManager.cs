using System.Collections.Generic;
using UnityEngine;

public class RotaryManager : MonoBehaviour
{
    // Puzzle box manager
    [SerializeField] private PuzzleBox puzzleBox;

    // store all handles in puzzle
    [SerializeField] private List<Rotary> handles;

    public List<PuzzleLightController> rotaryLights;

    [Header("Current Puzzle State")]
    // track puzzle compeltion
    public bool solved = false;

    public void CheckPuzzle() {
        // if already solved, return
        if (solved) {
            return; 
        }

        bool allCorrect = true;

        // cycle through handles
        for (int i = 0; i < handles.Count; i++) {
            // if handle is correct, returns true; returns false otherwise
            bool correct = handles[i].IsCorrect();

            // if one handle is not correct, set all correct to false; puzzle not solved
            if (!correct) {
                allCorrect = false;
            }
        }

        // only solve puzzle and change lights if all are correct
        if (allCorrect) {
            SolvePuzzle();
        }
    }

    void SolvePuzzle() {
        // return if already solved
        if (solved) return;

        solved = true;
        Debug.Log("Puzzle Solved");

        // turn all lights green once puzzle has been solved
        for (int i = 0; i < handles.Count; i++) {
            rotaryLights[i].SetGreen();
        }

        puzzleBox.OpenBox();
    }
}
