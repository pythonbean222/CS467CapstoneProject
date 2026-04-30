using UnityEngine;

public class ATM_interaction : MonoBehaviour
{
    // Reference to ATM screen
    public GameObject atmScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Code to display ATM interaction UI or trigger ATM functionality
            Debug.Log("Player has entered the ATM interaction zone.");
            LeanTween.scale(atmScreen, Vector3.one, 2).setEaseInBounce();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Code to hide ATM interaction UI or disable ATM functionality
            // Debug.Log("Player has exited the ATM interaction zone.");
            LeanTween.scale(atmScreen, Vector3.zero, 2).setEaseInQuad();
        }
    }
}
