// Bryanna Rosales-Hernandez 
// Game progress tracking to track when the user has not yet accomplished the sliding puzzle 
// Bool is changed in the GameManager.cs to true after the player has accomplished sliding puzzle. 
// When true, tutorial continues with different dialouge

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameProgressLobbyTutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private UnityEngine.UI.Button continueButton;


    public static bool puzzleCompleted = false;

    public static int tutorialDialougeStep = 0;

    private string[] tutorialMessages =
    {
        // Opening Prompt
        "Welcome to Escapify!",
        "This is a short tutorial to help you learn how puzzles work before your escape begins.",
        "Your goal here in Escapify is simple: explore, solve puzzles, and unlock the exit door!",

        // Introducing Keypad Puzzle 
        "Lets get a closer look at the door. Walk to it.",
        "Darn! It's locked. It requires a numerical code.",
        "Try inputting a code into the keypad to open.",

        // Introducing Computer Puzzle
        "The computer looks like it might contain something useful.. interact with it!"
    };

    private string[] FinishedPuzzleMessages =
    {
        // Computer Puzzle is complete 
        "The revealed code will likely be important for...",
        "perhaps something that requires a keypad?",
        "Input the code you revealed into the keypad. ",

        // Completion
        "You are ready. Your escape begins now...",
    };

    private int currentMessage = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (tutorialText != null)
            tutorialText.text = tutorialMessages[currentMessage];
        if (continueButton != null)
            continueButton.onClick.AddListener(NextMessage);

        if (puzzleCompleted)
        {
            tutorialText.text = FinishedPuzzleMessages[currentMessage];
        }
        else
        {
            currentMessage = 0;
            tutorialText.text = tutorialMessages[currentMessage];
        }
    }

    private void NextMessage()
    {
        currentMessage++;
        if (!puzzleCompleted)
        {
            if (currentMessage < tutorialMessages.Length)
            {
               tutorialText.text = tutorialMessages[currentMessage]; 
            }
            else
            {
                continueButton.gameObject.SetActive(false);
            }
        }
        else
        {
            if (currentMessage < FinishedPuzzleMessages.Length)
            {
               tutorialText.text = FinishedPuzzleMessages[currentMessage]; 
            }
            else
            {
                continueButton.gameObject.SetActive(false);
            }
        }
    }
};