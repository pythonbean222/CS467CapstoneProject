using System.Collections;
using UnityEngine;

public class Rotary : MonoBehaviour, IInteractable
{
    [Header("Rotary Puzzle Manager")]
    public RotaryManager puzzleManager;

    public PuzzleLightController lightController;

    [Header("Handle State")]
    // current handle posision; false = horizontal
    [SerializeField] private bool isVertical = false;
    // track correct puzzle state; true = vertical
    [SerializeField] private bool shouldBeVertical = true;
    // specify handle in Inspector to rotate
    [SerializeField] private Transform handle;

    [Header("Rotation")]
    // rotation values in Inspector
    [SerializeField] private Vector3 horizontalRotation;
    [SerializeField] private Vector3 verticalRotation;

    [Header("Animation")]
    // time of rotation animation
    [SerializeField] private float rotationDuration = 0.25f;

    private bool isRotating = false;

    public void Interact() {
        // if rotation is already happening, do nothing
        if (isRotating) {
            return;
        }
        // change state and start animation
        ToggleHandle();
        // check manager to validation solution
        puzzleManager.CheckPuzzle();
    }

    private void ToggleHandle() {
        isVertical = !isVertical;

        // store desired rotation - quaternation is Unity's rotation format
        Quaternion targetRotation;

        // convert rotations from Euler angles in Inspecor to Quatetnion 
        if (isVertical) {
            // use vertical rotation
            targetRotation = Quaternion.Euler(verticalRotation);
        }
        else {
            // use horizontal rotation
            targetRotation = Quaternion.Euler(horizontalRotation);
        }
        
        // start animation
        StartCoroutine(RotateSmoothly(targetRotation));
    }

    private IEnumerator RotateSmoothly(Quaternion targetRotation) {
        isRotating = true;

        // get current rotation before animation
        Quaternion startRotation = handle.localRotation;

        // track animation progress
        float elapsed = 0.0f;
        
        // during animation
        while(elapsed < rotationDuration) {
            // add time to make animation smooth
            elapsed += Time.deltaTime;
            float t = elapsed / rotationDuration;

            //Slerp - spherical interpolation, helps to create smooth turning
            handle.localRotation = Quaternion.Slerp(startRotation, targetRotation, t);

            // pauses the coroutine until the next frame; prevents loop from instantly compeleting
            yield return null;
        }

        handle.localRotation = targetRotation;
        isRotating = false;
    }

    public bool IsCorrect() {
        // verify current and desired states match
        return isVertical == shouldBeVertical;
    }

    public string GetInteractionText() {
        return $"Press E to turn handle";
    }
}
