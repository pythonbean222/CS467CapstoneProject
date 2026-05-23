using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class NumberGuessingGame : MonoBehaviour
{
    // This script will be attached to the computer screen in the escape room. It will handle the number guessing game logic.
    // local variables
    private int randomNumber;
    private int playerGuess;
    public UnityEvent OnCorrectGuess;
    private void Start()
    {
        // Generate a random number between 1 and 100
        randomNumber = Random.Range(1, 101);
        Debug.Log("Random Number (for testing): " + randomNumber);
    }

    
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
