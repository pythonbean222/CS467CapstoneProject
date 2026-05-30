using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public TMP_Text displayTime;

    // CHANGE THIS TO ADJUST THE TIME
    private float currentTime = 10f;

    // game over event
    public UnityEvent gameOverEvent;

    private bool hasWon = false;
    private bool hasLost = false;

    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip loseClip1;
    [SerializeField] private AudioClip loseClip2;


    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            displayTime.text = "You win!";
            return;
        }

        else if (hasLost)
        {
            displayTime.text = "Game Over, you lose!";
            return;
        }

        currentTime -= Time.deltaTime;
        displayTime.text = currentTime.ToString("0") + " secs";

        if (currentTime < 0)
        {

            GameLost();
            return;
        }
    }


    public void GameLost()
    {
        
        hasLost = true;
        // Debug.Log("Game Over");
        gameOverEvent.Invoke();
        PlayLoseSequence();
        Time.timeScale = 0;

    }

    public void GameWon()
    {
        hasWon = true;
    }

    // Corouting to play losing sounds
    public void PlayLoseSequence()
    {
        StartCoroutine(PlayLosingSounds(loseClip1, loseClip2));
    }

    // Play losing sounds due to game over
    private IEnumerator PlayLosingSounds(AudioClip first, AudioClip second)
    {
        if (audioSource == null || first == null || second == null)
        {
            yield break;
        }

        audioSource.PlayOneShot(first);
        yield return new WaitForSecondsRealtime(first.length);
        audioSource.PlayOneShot(second);
    }


}
