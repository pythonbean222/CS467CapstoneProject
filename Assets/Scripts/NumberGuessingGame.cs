using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NumberGuessingGame : MonoBehaviour
{
    [Header("Win")]
    [SerializeField] private WinEventManager winEventManager;

    [Header("Panels")]
    [SerializeField] private GameObject promptPanel;
    [SerializeField] private GameObject feedbackPanel;
    [SerializeField] private GameObject guessInputPanel;

    [Header("UI")]
    [SerializeField] private TMP_Text promptText;
    [SerializeField] private TMP_Text feedbackText;
    [SerializeField] private TMP_InputField guessInputField;

    [Header("Game")]
    [SerializeField] private int minNumber = 1;
    [SerializeField] private int maxNumber = 100;

    private int randomNumber;
    private bool isSolved;

    public UnityEvent OnCorrectGuess;

    private void Awake()
    {
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
        }

        if (feedbackPanel != null)
        {
            feedbackPanel.SetActive(false);
        }

        if (guessInputPanel != null)
        {
            guessInputPanel.SetActive(false);
        }
    }


    private void OnEnable()
    {
        if (guessInputField != null)
        {
            guessInputField.onSubmit.AddListener(SubmitGuess);
        }
    }

    private void OnDisable()
    {
        if (guessInputField != null)
        {
            guessInputField.onSubmit.RemoveListener(SubmitGuess);
        }
    }

    public void StartNewGame()
    {
        randomNumber = Random.Range(minNumber, maxNumber + 1);
        isSolved = false;

        // start panels sequence method
        StartCoroutine(ShowPanelsInSequence());

/*         if (promptText != null)
        {
            promptPanel.SetActive(true);
            
            
        }

        if (feedbackText != null)
        {
            feedbackText.text = "Enter your guess and press Enter.";
            feedbackText.color = Color.white;
        }

        if (guessInputField != null)
        {
            guessInputField.text = string.Empty;
            guessInputField.interactable = true;
            guessInputField.ActivateInputField();
        } */

        Debug.Log("Random Number (for testing): " + randomNumber);
    }

    // timed sequence method to call inside StartNewGame() to show panels in order
    private IEnumerator ShowPanelsInSequence()
    {
        // turns on prompt panel and sets prompt text
        promptPanel.SetActive(true);
        promptText.text = $"Guess a number between {minNumber} and {maxNumber}.";
        
        // waits for 2 seconds before showing feedback panel
        yield return new WaitForSeconds(2f);

        // turns off prompt panel; turns on feedback panel and input panel;
        // sets feedback text and activates input field
        promptPanel.SetActive(false);       
        feedbackPanel.SetActive(true);
        guessInputPanel.SetActive(true);

        feedbackText.text = "Enter your guess and press Enter.";
        
        guessInputField.interactable = true;
        guessInputField.ActivateInputField();

    }


    public void SubmitGuess()
    {
        if (guessInputField != null)
        {
            SubmitGuess(guessInputField.text);
        }
    }

    public void SubmitGuess(string guessInput)
    {
        if (isSolved)
        {
            return;
        }

        if (!int.TryParse(guessInput, out int playerGuess))
        {
            SetFeedback("Please enter a whole number.", Color.yellow);
            return;
        }

        if (playerGuess == randomNumber)
        {
            isSolved = true;
            SetFeedback($"Correct! The number was {randomNumber}.", Color.green);

            if (guessInputField != null)
            {
                guessInputField.interactable = false;
            }

            winEventManager?.RegisterPuzzleCompletion();
            OnCorrectGuess?.Invoke();
            return;
        }

        if (playerGuess < randomNumber)
        {
            SetFeedback("Too low. Try again.", Color.red);
        }
        else
        {
            SetFeedback("Too high. Try again.", Color.red);
        }

        if (guessInputField != null)
        {
            guessInputField.text = string.Empty;
            guessInputField.ActivateInputField();
        }
    }

    private void SetFeedback(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
        }
    }
}
