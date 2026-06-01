// Used in Lobby Scene
// Called to load player to desire room, loads sounds + dialouge 

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoomHandler : MonoBehaviour
{
    [Header("Doors")]
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;

    [Header("Audio")]
    public AudioClip doorSound;
    public AudioClip TakeOff;
    private AudioSource audioSource;

    // sceneflowmanager variables and references for scene loading
    [SerializeField] private SceneFlowManager sceneFlowManager;
    [SerializeField] private SceneLoader sceneLoader;
    // [SerializeField] private string sceneToLoad;


    [Header("UI")]
    public TextMeshProUGUI countdownText;

    private bool doorsOpened = false;
    private bool isLoading = false;
    private bool playerInRange = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (countdownText != null)
            countdownText.gameObject.SetActive(false);

        if (sceneFlowManager == null)
            Debug.LogError("RoomHandler: SceneFlowManager reference is not assigned.", this);

        if (sceneLoader == null)
            Debug.LogError("RoomHandler: SceneLoader reference is not assigned.", this);
    }

    private void OpenDoors()
    // Method to open doors and trigger sounds
    {
        if (leftDoorAnimator != null)
            leftDoorAnimator.SetTrigger("Open");

        if (rightDoorAnimator != null)
            rightDoorAnimator.SetTrigger("Open");

        if (audioSource != null && doorSound != null)
            audioSource.PlayOneShot(doorSound);
        
        if (audioSource != null && doorSound != null)
        {
            audioSource.PlayOneShot(doorSound);
            StartCoroutine(PlayTakeOffAfterDelay(doorSound.length));
        }
    }

    private System.Collections.IEnumerator CountdownAndLoad()
    // Method to display text and load scene
    {
        isLoading = true;

        if (countdownText != null)
            countdownText.gameObject.SetActive(true);

        int timeLeft = 5;

        while (timeLeft > 0)
        {
            if (countdownText != null)
                countdownText.text = "Loading in " + timeLeft + "...";

            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        if (sceneFlowManager == null || sceneLoader == null)
        {
            Debug.LogError("RoomHandler: Cannot load scene because one or more scene references are missing.", this);
            isLoading = false;
            yield break;
        }

        sceneFlowManager.currentScene = sceneLoader.sceneToLoad;
        Debug.Log("Current Scene set to: " + sceneFlowManager.currentScene);
        sceneFlowManager.LoadScene(sceneLoader.sceneToLoad);

    }

    private System.Collections.IEnumerator PlayTakeOffAfterDelay(float delay)
    // Method to play the TakeOff sound after the door sound
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(TakeOff);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (doorsOpened || isLoading) return;

            doorsOpened = true;

            if (sceneFlowManager == null)
            sceneFlowManager = SceneFlowManager.Instance;

            OpenDoors();
            StartCoroutine(CountdownAndLoad());
        }
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}