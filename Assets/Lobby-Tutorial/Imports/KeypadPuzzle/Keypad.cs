using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Keypad : MonoBehaviour
{
    public string password = "0343";
    private string userInput = "";
    public Animator doorAnimator;
    public Animator rightdoorAnimator;
    public TMP_Text displayText;
    public GameObject completionMessage;
    public AudioClip ComputerError;
    public AudioClip SlideDoor;
    AudioSource audioSource;

    private void Start()
    {
        userInput = "";
        UpdateDisplay();
        audioSource = GetComponent<AudioSource>();
    }
    public void ButtonClicked(string number)
    {
        userInput += number;
        UpdateDisplay();
        if (userInput.Length >= 4)
        {
            // check password 
            if (userInput == password)
            {
                Debug.Log("Entry Allowed");
                doorAnimator.SetTrigger("Open");
                rightdoorAnimator.SetTrigger("Open");
                completionMessage.SetActive(true);
                audioSource.PlayOneShot(SlideDoor);
            }
            else
            {
                Debug.Log("Not this time");
                audioSource.PlayOneShot(ComputerError);
                displayText.text = "Incorrect. Try again.";
                userInput = "";
            }
        }
    }
    void UpdateDisplay()
    {
        displayText.text = userInput;
    }
}
