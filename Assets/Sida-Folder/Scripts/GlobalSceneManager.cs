// Citation for How to create and use a Singleton in Unity
// Date: 31 May 2026
// Copied from YouTube Channel: Game Dev Beginner
// Source URL: https://www.youtube.com/watch?v=yhlyoQ2F-NM

using UnityEngine;

public class GlobalSceneManager : MonoBehaviour
{
    // Create a singleton GlobalSceneManager
    public static GlobalSceneManager instance;

    // Initialize a public counter value to keep track of how many levels/scenes have been completed
    public int counterValue;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

// The code snippets below are to be placed into each puzzle room if we use this GlobalSceneManager implementation
// Should be placed at the end of each scene (ideally when the player overlaps the exit trigger)


// Place this code snippet into Andrew's Room
/*
GlobalSceneManager.instance.counterValue ++;

    if (GlobalSceneManager.instance.counterValue == 2)
    {
        SceneManager.LoadScene("Room1Scene");
    }
    else
    {
        SceneManager.LoadScene("Room_AH");
    }
*/


// Place this code snippet into Adrianna's Room
/*
GlobalSceneManager.instance.counterValue ++;

    if (GlobalSceneManager.instance.counterValue == 2)
    {
        SceneManager.LoadScene("Room1Scene");
    }
    else
    {
        SceneManager.LoadScene("Sci_fi puzzle room");
    }
*/


// Place this code snippet into Sida's Room (Room1Scene)
/*

GlobalSceneManager.instance.counterValue = 0;
    
*/