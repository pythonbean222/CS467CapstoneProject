using UnityEngine;
using System.Collections;

// attached to the exit trigger collider, checks if the player has completed the fuse box puzzle before allowing them to exit

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private SceneFlowManager sceneFlowManager;
    [SerializeField] private FuseBox fuseBox;
    [SerializeField] private CanvasGroup exitPrompt;

    // prevent multiple triggers
    private bool triggered = false;
    // track if the puzzle has been completed
    private bool puzzleCompleted = false;

    private void Awake() {
        // if sceneFlowManager reference is not set in the inspector, try to find it in the scene
        if (sceneFlowManager == null) {
            sceneFlowManager = SceneFlowManager.Instance;
        }

        if (exitPrompt != null) {
            exitPrompt.alpha = 0f; 
        }
    }

    private void OnEnable() {
        // subscribe to the fuse box solved event
        if (fuseBox != null) {
            fuseBox.OnFuseBoxSolved += HandlePuzzleCompleted;
        }
    }

    private void OnDisable() {
        // unsubscribe from the fuse box solved event
        if (fuseBox != null) {
            fuseBox.OnFuseBoxSolved -= HandlePuzzleCompleted;
        }
    }

    private void HandlePuzzleCompleted() {
        // mark the puzzle as completed when the event is received
        Debug.Log("Puzzle completed, exit trigger can now be activated.");
        puzzleCompleted = true;
    }

    public void OnTriggerEnter(Collider other) {
        // if already triggered, do nothing
        if (triggered) {
            return;
        }

        // check if the collider belongs to the player
        if (!other.CompareTag("Player")) {
            return;
        }

        // if the puzzle is not completed, do not allow exit
        if (!puzzleCompleted) {
            Debug.LogError("Puzzle not completed!");
            return;
        }

        // mark as triggered to prevent multiple activations
        triggered = true;
        Debug.Log("Exit trigger activated, scene completed.");

        // set the scene as completed in the scene flow manager
        if (exitPrompt != null) {
            StartCoroutine(FadeOutAndLoadNextScene());
        } else {
            SceneFlowManager.Instance.SceneCompleted = true;
        }
    }

    private IEnumerator FadeOutAndLoadNextScene() {
        // set the exit prompt to visible and fade it in
        float fadeDuration = 1.5f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            exitPrompt.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        // after fade is complete, mark the scene as completed
        SceneFlowManager.Instance.SceneCompleted = true;
    }
}
