using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WinEventManager : MonoBehaviour
{
    [SerializeField] private RoomHandler roomHandler;
    public UnityEvent PuzzleWinnerEvent;
    [SerializeField] public int winEventCounter = 0;
    [SerializeField] private int puzzlesRequiredToWin = 3;
    [SerializeField] public bool hasWon;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winClip1;
    [SerializeField] private AudioClip winClip2;

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
            PlayWinSequence();

        }
    }



    public void PlayWinSequence()
    {
        StartCoroutine(PlayWinningSounds(winClip1, winClip2));
    }

    private IEnumerator PlayWinningSounds(AudioClip first, AudioClip second)
    {
        if (audioSource == null || first == null || second == null)
        {
            yield break;
        }

        audioSource.PlayOneShot(first);
        yield return new WaitForSeconds(first.length);
        audioSource.PlayOneShot(second);

    }

}
