using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public TMP_Text displayTime;

    // CHANGE THIS TO ADJUST THE TIME
    private float currentTime = 300f;

    // game over event
    public UnityEvent gameOverEvent;


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        displayTime.text = currentTime.ToString("0") + " secs";

        if (currentTime < 0)
        {
            Time.timeScale = 0;
            // Debug.Log("Game Over");
            gameOverEvent.Invoke();
            displayTime.text = "Game Over, you lose!";
        }
    }




}
