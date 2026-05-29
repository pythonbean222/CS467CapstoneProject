// Used in Tutorial Scene 

// Script made for tutorial dialouge. Checks when the sliding puzzle has been completed
// and continues after. 

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
    // To be shown before the Sliding Puzzle is completed
    {
        // Opening Prompt
        "Welcome to Escaptory!",
        "This is a short tutorial to help you learn how puzzles work before your escape begins.",
        "Your goal here in Escaptory is simple: explore, solve puzzles, and unlock the exit door!",

        // Introducing Keypad Puzzle 
        "Lets get a closer look at the door. Walk to it.",
        "Darn! It's locked. It requires a numerical code.",
        "Try inputting a code into the keypad to open.",

        // Introducing Computer Puzzle
        "The computer looks like it might contain something useful.. interact with it!"
    };

    private string[] FinishedPuzzleMessages =
    // To be displayed after the Sliding Puzzle has been completed
    {
        // Computer Puzzle is complete 
        "The revealed code will likely be important for...",
        "perhaps something that requires a keypad?",
        "Input the code you revealed into the keypad. ",

        // Completion
        "You are ready. Your escape begins now...",
    };

    private int currentMessage = 0; // Counter for which dialouge step is to be displayed in TMP_Text


// Citation for Click detection, text display
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/ScriptReference/UIElements.Button-clicked.html
// Source URL: https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.0/api/TMPro.TMP_Text.html#TMPro_TMP_Text_text
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (tutorialText != null)
            tutorialText.text = tutorialMessages[currentMessage];
        if (continueButton != null)
            continueButton.onClick.AddListener(NextMessage);

        if (puzzleCompleted)
        // Checks if the Sliding Puzzle has been completed or not
        {
            tutorialText.text = FinishedPuzzleMessages[currentMessage];
        }
        else
        {
            currentMessage = 0;
            tutorialText.text = tutorialMessages[currentMessage];
        }
    }

// Citation for next dialogue text
// AI was used as a coding aid to help structure the logic for text progression and button-triggered dialogue updates
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