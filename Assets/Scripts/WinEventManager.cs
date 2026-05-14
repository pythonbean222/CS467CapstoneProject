using UnityEngine;
using UnityEngine.Events;

public class WinEventManager : MonoBehaviour
{

    public UnityEvent PuzzleWinnerEvent;
    [SerializeField] public int winEventCounter = 0;
/* 
    [SerializeField] private PuzzleManager puzzleManager;
    
    private void Awake()
    {
        if (puzzleManager == null)
        {
            puzzleManager = Object.FindAnyObjectByType<PuzzleManager>();
        }
    } */


// win condition function
public void Winner()
    {
        // if (puzzleManager != null && winEventCounter >= 3)
            if (winEventCounter >= 3)
        {
            Debug.Log("Player has won the puzzle game!");
            PuzzleWinnerEvent.Invoke();
        }
    }

}
