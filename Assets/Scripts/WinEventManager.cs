using UnityEngine;
using UnityEngine.Events;

public class WinEventManager : MonoBehaviour
{

    public UnityEvent PuzzleWinnerEvent;

    [SerializeField] private PuzzleManager puzzleManager;
    
    private void Awake()
    {
        if (puzzleManager == null)
        {
            puzzleManager = Object.FindAnyObjectByType<PuzzleManager>();
        }
    }


// win condition function
public void Winner()
    {
        if (puzzleManager != null && puzzleManager.winEventCounter >= 3)
        {
            Debug.Log("Player has won the puzzle game!");
            PuzzleWinnerEvent.Invoke();
        }
    }

}
