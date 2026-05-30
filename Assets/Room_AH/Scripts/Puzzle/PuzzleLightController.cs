using System.Collections;
using UnityEngine;

// Script for controlling the puzzle lights, including flashing red or green based on whether the puzzle is correct or incorrect

public class PuzzleLightController : MonoBehaviour
{
    // set in Inspector
    [Header("Renderers")]
    // set meshes for each light in Inspector
    [SerializeField] private MeshRenderer leftRed;
    [SerializeField] private MeshRenderer leftGreen;
    [SerializeField] private MeshRenderer rightRed;
    [SerializeField] private MeshRenderer rightGreen;

    [Header("Flash Settings")]
    // set number of flashes and time delay in Inspector
    [SerializeField] private float flashDelay = 0.2f;
    [SerializeField] private int flashCount = 2;

    // coroutine suspendes its execution (yield) until the given yield instruction is finished
    private Coroutine flashRoutine;

    void Start() {
        // lights initially set to red
        SetRed();
    }

    public void SetRed() {
        // left and right red are true, left and right green are false
        SetState(true, false, true, false);
    }

    public void SetGreen() {
        // left and right red are false, left and right green are true
        SetState(false, true, false, true);
    }

    public void SetOff() {
        // all lights off
        SetState(false, false, false, false);
    }

    // if puzzle is wrong, flash red
    public void FlashWrong() => StartFlash(false);
    // if puzzle is right, flash green
    public void FlashRight() => StartFlash(true);

    private void StartFlash(bool success) {
        // if flash already running, stop
        if (flashRoutine != null) {
            StopCoroutine(flashRoutine);
        }

        // start new flash
        flashRoutine = StartCoroutine(Flash(success));
    }

     private IEnumerator Flash(bool success) {
        for (int i = 0; i < flashCount; i++) {
            // if puzzle is correct, lights flash green
            if (success) {
                SetGreen();
            }
            // flash red if incorrect
            else {
                SetRed() ;
            }

            // pause coroutine, lights stay visible
            yield return new WaitForSeconds(flashDelay);

            // lights turn off
            SetOff();

            // pause coroutine, lights stay off
            yield return new WaitForSeconds(flashDelay);
        }

        // final state
        if (success) {
            // stay green on success
            SetGreen();
        }
        else {
            // stay red on failure
            SetRed();
        }

        // clear coroutine
        flashRoutine = null;
    }

    // set color meshes
    private void SetState(bool lr, bool lg, bool rr, bool rg) {
        leftRed.enabled = lr;
        leftGreen.enabled = lg;
        rightRed.enabled = rr;
        rightGreen.enabled = rg;
    }
}
