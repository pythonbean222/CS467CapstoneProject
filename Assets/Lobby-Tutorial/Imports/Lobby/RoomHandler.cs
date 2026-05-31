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

    [Header("Scene")]
    public string FirstScene;

     [Header("NextScene")]
    public string SecondScene;

     [Header("FinalScene")]
    public string FinalScene;

    [Header("UI")]
    public TextMeshProUGUI countdownText;

    private bool doorsOpened = false;
    private bool isLoading = false;

    [SerializeField] public bool puzzleCompleted = false;
    [SerializeField] private int sceneCounter;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (countdownText != null)
            countdownText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (puzzleCompleted)
        {
            sceneCounter++;
            if (sceneCounter < 2)
            {
                SceneManager.LoadScene(SecondScene);
                puzzleCompleted = false; // Reset the flag to prevent multiple loads
            }

            else
            {
                SceneManager.LoadScene(FinalScene);
                puzzleCompleted = false; // Reset the flag to prevent multiple loads
            }


        }

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

        SceneManager.LoadScene(FirstScene);
    }

    private System.Collections.IEnumerator PlayTakeOffAfterDelay(float delay)
    // Method to play the TakeOff sound after the door sound
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(TakeOff);
    }
}