using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NumberGuessingGame : MonoBehaviour
{
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

        if (promptText != null)
        {
            promptPanel.SetActive(true);
            promptText.text = $"Guess a number between {minNumber} and {maxNumber}.";
            
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
        }

        Debug.Log("Random Number (for testing): " + randomNumber);
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
