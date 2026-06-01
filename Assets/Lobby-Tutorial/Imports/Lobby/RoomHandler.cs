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
    [SerializeField] private SceneFlowManager SceneFlowManager;
    [SerializeField] private SceneLoader SceneLoader;
    // [SerializeField] private string sceneToLoad;


    [Header("UI")]
    public TextMeshProUGUI countdownText;

    private bool doorsOpened = false;
    private bool isLoading = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (countdownText != null)
            countdownText.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (doorsOpened || isLoading) return;

        doorsOpened = true;

        OpenDoors();
        StartCoroutine(CountdownAndLoad());
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
        SceneFlowManager.currentScene = SceneLoader.sceneToLoad;
        SceneFlowManager.LoadScene(SceneLoader.sceneToLoad);

    }

    private System.Collections.IEnumerator PlayTakeOffAfterDelay(float delay)
    // Method to play the TakeOff sound after the door sound
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(TakeOff);
    }
}