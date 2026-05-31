using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutTrigger : MonoBehaviour
{
    [SerializeField] private SceneFlowManager sceneFlowManager;
    
    [SerializeField] private WinEventManager winEventManager;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    
 
    public void OnTriggerEnter(Collider other)
    {
        if (sceneFlowManager == null)
        {
            sceneFlowManager = SceneFlowManager.Instance;
        }

        if (other.CompareTag("Player") && winEventManager.hasWon && sceneFlowManager != null)
        {
            Debug.Log("Player has entered the win trigger area.");
            StartCoroutine(FadeOutAndLoadScene()); 
        }
        else if (sceneFlowManager == null)
        {
            Debug.LogWarning("FadeOutTrigger could not find a SceneFlowManager instance.");
        }
        
    }

    // coroutine to handle fade out and puzzleCompleted flag setting
    private IEnumerator FadeOutAndLoadScene()
    {
        // Assuming you have a fade out animation or effect here
        // For example, you could use LeanTween to fade out the screen
        LeanTween.alphaCanvas(fadeCanvasGroup, 1f, 2f).setEaseInOutQuad();

        Debug.Log("Starting fade out...");
        // Wait for the fade out to complete (adjust the time as needed)
        yield return new WaitForSeconds(2f);
        Debug.Log("Fade out completed, setting SceneCompleted to true.");

        // Load the next scene or perform any other actions after winning
        sceneFlowManager.SceneCompleted = true;
        Debug.Log("SceneCompleted flag set to true, loading next scene...");

                
    }
}
