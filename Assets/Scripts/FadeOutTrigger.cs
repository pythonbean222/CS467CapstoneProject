using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutTrigger : MonoBehaviour
{
    [SerializeField] private SceneFlowManager SceneFlowManager;
    
    [SerializeField] private WinEventManager winEventManager;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && winEventManager.hasWon)
        {
            Debug.Log("Player has entered the win trigger area.");
            StartCoroutine(FadeOutAndLoadScene()); 
        }
        
    }

    // coroutine to handle fade out and puzzleCompleted flag setting
    private IEnumerator FadeOutAndLoadScene()
    {
        // Assuming you have a fade out animation or effect here
        // For example, you could use LeanTween to fade out the screen
        LeanTween.alphaCanvas(fadeCanvasGroup, 1f, 2f).setEaseInOutQuad();

        // Wait for the fade out to complete (adjust the time as needed)
        yield return new WaitForSeconds(2f);

        // Load the next scene or perform any other actions after winning
        SceneFlowManager.puzzleCompleted = true;

        //SceneFlowManager.Update();


        
    }
}
