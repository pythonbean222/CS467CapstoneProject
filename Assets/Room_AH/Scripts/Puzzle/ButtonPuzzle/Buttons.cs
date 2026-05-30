using System.Collections;
using UnityEngine;

// Script for controlling the buttons in the button puzzle

public class Buttons : MonoBehaviour, IInteractable_AH
{
    // Puzzle box manager
    [Header("Button Puzzle Manager")]
    public ButtonManager puzzleManager;

    // set button handle for visualization
    [Header("Button Press Visual")]
    // set button handle for visualization 
    [SerializeField] private Transform buttonHandle;

    public PuzzleLightController lightController;

    // set button ID
    [Header("Button Identifier")]
    // set button ID in Inspector
    [SerializeField] private string buttonID;

    // animation variables
    [Header("Animation")]
    // set offset for button movement
    [SerializeField] private Vector3 pressedOffset;
    // set indent duration
    [SerializeField] private float pressDuration = 0.1f;

    private Vector3 startLocalPos;
    private Coroutine pressRoutine;

    private void Start() {
        // store original button position
        startLocalPos = buttonHandle.localPosition;
    }

    public void Interact() {
        // on interact button is pressed
        puzzleManager.PressButton(buttonID);

        // start press animaton
        PressAnimation();
    }

    private void PressAnimation() {
        // if press action already occuring, stop 
        if (pressRoutine != null) {
            StopCoroutine(pressRoutine);
        }

        // start new press animation
        pressRoutine = StartCoroutine(PressRoutine());
    }

    private IEnumerator PressRoutine() {
        // set location of pressed button
        Vector3 pressedPos = startLocalPos + pressedOffset;

        // for button movement inwards
        // track animation progress
        float elapsed = 0f;

        // during animation
        while (elapsed < pressDuration) {
            // add time to make animation smooth
            elapsed += Time.deltaTime;
            float lerp = elapsed / pressDuration;

            // Lerp - linear extrapolation between two points; creates smooth movement
            buttonHandle.localPosition = Vector3.Lerp(startLocalPos, pressedPos, lerp);

            // pause coroutine until next frame
            yield return null;
        }

        buttonHandle.localPosition = pressedPos;

        // for button movement back to start position
        // track animation progress
        elapsed = 0f;

        // during animation
        while (elapsed < pressDuration)
        {
            // add time to make animation smooth
            elapsed += Time.deltaTime;
            float lerp = elapsed / pressDuration;

            // Lerp - linear extrapolation between two points; creates smooth movement
            buttonHandle.localPosition = Vector3.Lerp(pressedPos, startLocalPos, lerp);

            // pause coroutine until next frame
            yield return null;
        }

        buttonHandle.localPosition = startLocalPos;
    }

    public string GetInteractionText() {
        return $"Press E to push button";
    }
}
