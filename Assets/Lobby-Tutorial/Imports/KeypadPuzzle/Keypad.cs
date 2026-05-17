using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public string password = "0343";
    private string userInput = "";
    public Animator doorAnimator;

    private void Start()
    {
        userInput = "";
    }
    public void ButtonClicked(string number)
    {
        userInput += number;
        if (userInput.Length >= 4)
        {
            // check password 
            if (userInput == password)
            {
                Debug.Log("Entry Allowed");
                doorAnimator.SetTrigger("Open");
                // Sound?
            }
            else
            {
                Debug.Log("Not this time");
                // Sound?
                userInput = "";
            }
        }
    }
}
