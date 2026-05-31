using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FadeOutTrigger : MonoBehaviour
{
    [SerializeField] private RoomHandler roomHandler;
    [SerializeField] private WinEventManager winEventManager;
    
 
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
        // LeanTween.alphaCanvas(fadeCanvasGroup, 0, 2f).setEaseInOutQuad();

        // Wait for the fade out to complete (adjust the time as needed)
        yield return new WaitForSeconds(2f);

        // Load the next scene or perform any other actions after winning
        roomHandler.puzzleCompleted = true;
    }
}
