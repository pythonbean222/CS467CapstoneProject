using UnityEngine;
using UnityEngine.Events;

public class WinEventManager : MonoBehaviour
{

    public UnityEvent PuzzleWinnerEvent;
    [SerializeField] public int winEventCounter = 0;
    [SerializeField] private int puzzlesRequiredToWin = 3;
    private bool hasWon;
/* 
    [SerializeField] private PuzzleManager puzzleManager;
    
    private void Awake()
    {
        if (puzzleManager == null)
        {
            puzzleManager = Object.FindAnyObjectByType<PuzzleManager>();
        }
    } */


    public void RegisterPuzzleCompletion()
    {
        if (hasWon)
        {
            return;
        }

        winEventCounter++;
        Winner();
    }

    // win condition function
    public void Winner()
    {
        // if (puzzleManager != null && winEventCounter >= 3)
            if (!hasWon && winEventCounter >= puzzlesRequiredToWin)
        {
            hasWon = true;
            Debug.Log("Player has won the puzzle game!");
            PuzzleWinnerEvent?.Invoke();
        }
    }

}
