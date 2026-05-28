// Citation for How to Trigger a Cutscene in Unity
// Date: 27 May 2026
// Adapted from YouTube Channel: Jimmy Vegas
// Source URL: https://www.youtube.com/watch?v=pru5sx_hqeE

// Citation for How to Play a Cutscene Video in Unity
// Date: 27 May 2026
// Adapted from YouTube Channel: Solo game Dev
// Source URL: https://www.youtube.com/watch?v=-XzVq7qIuys

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

            // Enable the audio listener to prevent error logs (One audio listener is required to be on at all times)
            // Aside from minimizing errors, this code doesn't do anything
            GetComponent<AudioListener>().enabled = true;

            // Start Coroutine Event
            StartCoroutine(DelayEvent());

        }
    }

    IEnumerator DelayEvent()
    {   
        yield return new WaitForSeconds(1f);
        
        // Enable a new camera to prevent error logs, similar to audio listener
        endMenuCamera.gameObject.SetActive(true);

        yield return new WaitForSeconds(19f);

        // Enable the End Menu Canvas
        endMenuCanvas.gameObject.SetActive(true);
        
        // Display the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        yield return new WaitForSeconds(72f);

        // Disable the cutscene after 72 seconds
        cutsceneCanvas.gameObject.SetActive(false);
    }
}
