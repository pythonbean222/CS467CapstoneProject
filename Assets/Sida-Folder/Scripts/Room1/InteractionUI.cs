// Citation for how to use built-in OnTriggerEnter and OnTriggerExit Colliders
// Date: 26 May, 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
// Source URL: https://docs.unity3d.com/ScriptReference/Collider.OnTriggerExit.html

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class InteractionUI : MonoBehaviour
{

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private Canvas interactPromptCanvas;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Hello");
            interactPromptCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Goodbye");
            interactPromptCanvas.enabled = false;
        }
    }
}
