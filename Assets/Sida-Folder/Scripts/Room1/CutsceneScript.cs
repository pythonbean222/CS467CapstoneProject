using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject playerGameobject;
    [SerializeField] private Canvas cutsceneCanvas;
    [SerializeField] private Canvas endMenuCanvas;
    [SerializeField] private Camera endMenuCamera;
    [SerializeField] private GameObject musicGameObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If player triggers the cutscene collider, play the cutscene
            cutsceneCanvas.gameObject.SetActive(true);

            // Disable the Player game object (to prevent them from moving)
            playerGameobject.gameObject.SetActive(false);

            // Disable the Background Music
            musicGameObject.SetActive(false);

            // Start Coroutine Event
            StartCoroutine(DelayEvent());

        }
    }

    IEnumerator DelayEvent()
    {
        yield return new WaitForSeconds(19f);

        // Disable the cutscene after 19 seconds
        cutsceneCanvas.gameObject.SetActive(false);
        
        // Enable a new camera
        endMenuCamera.gameObject.SetActive(true);

        // Enable the End Menu Canvas
        endMenuCanvas.gameObject.SetActive(true);
        
        // Display the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
