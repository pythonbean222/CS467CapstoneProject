// Citation for how to use use Audio Source and Audio Clips to play One Shots
// Date: 28 May 2026
// Adapted from YouTube Channel: Nathan Jenkins
// Source URL: https://www.youtube.com/watch?v=ln4ilSVR1Ug

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Room1PuzzleManager : MonoBehaviour
{
    [Header("Puzzle 1 Variables")]
    [Space(10)]

    [SerializeField] private string correctString = "1234";
    [SerializeField] private string playerString = "";
    [SerializeField] private int stringCount = 0;

    [SerializeField] private DoubleDoor doubleDoor;
    [SerializeField] private SpawnRoomLight spawnRoomLight;
    
    [SerializeField] private PowerSwitch switch1;
    [SerializeField] private PowerSwitch switch2;
    [SerializeField] private PowerSwitch switch3;
    [SerializeField] private PowerSwitch switch4;

    [Header("Puzzle 2 Variables")]
    [Space(10)]

    [SerializeField] private int binaryProblemsSolved;
    [SerializeField] private bool isComplete;
    [SerializeField] private Animator pentagonWallAnim;
    [SerializeField] private Animator diamondWallAnim;

    [Header("Puzzle 3 Variables")]
    [Space(10)]

    [SerializeField] private int randomSpawnSet;
    [SerializeField] private GameObject pictureFrameSpawnSet1;
    [SerializeField] private GameObject pictureFrameSpawnSet2;
    [SerializeField] private GameObject pictureFrameSpawnSet3;
    [SerializeField] private bool isFlightPasswordComplete;
    [SerializeField] private Animator endDoorAnim;

    [Header("Audio Variables")]
    [Space(10)]
    [SerializeField] private AudioSource masterAudioSource;
    [SerializeField] private AudioClip powerSwitchCorrect;
    [SerializeField] private AudioClip powerSwitchIncorrect;
    [SerializeField] private AudioClip doorOpen1;
    [SerializeField] private AudioClip decimalWallMovement;
    [SerializeField] private GameObject musicGameObject;

    

    void Start()
    {
        // Set one of the three possible PictureFrameSpawnSets as active for Puzzle 3
        RandomSpawnSetSelector();
    }

    private void RandomSpawnSetSelector()
    {
        // Generate a random value from 0 to 2
        randomSpawnSet = UnityEngine.Random.Range(0, 3);

        // Enable the corresponding PictureFrameSpawnSet
        if (randomSpawnSet == 0)
        {
            pictureFrameSpawnSet1.gameObject.SetActive(true);
            // Debug.Log(randomSpawnSet);
        }
        else if (randomSpawnSet == 1)
        {
            pictureFrameSpawnSet2.gameObject.SetActive(true);
            // Debug.Log(randomSpawnSet);
        }
        else
        {
            pictureFrameSpawnSet3.gameObject.SetActive(true);
            // Debug.Log(randomSpawnSet);
        }
    }

    // Puzzle 1 Completion Condition Check
    public void concatenateString(string switchID)
    {
        stringCount++;

        playerString += switchID;

        Debug.Log(playerString);

        if (stringCount == 4)
        {
            if (playerString == correctString)
            {
                Debug.Log("CORRECT ANSWER");

                // Play Correct Sound
                masterAudioSource.PlayOneShot(powerSwitchCorrect);
                masterAudioSource.PlayOneShot(doorOpen1);
                
                // Open Door
                doubleDoor.OpenDoor();

                // Change Spawn Room Lamp Color to Green
                spawnRoomLight.ChangeMaterial();

                return;
            }
            else
            {
                Debug.Log("INCORRECT ANSWER");

                // Play Incorrect Sound
                masterAudioSource.PlayOneShot(powerSwitchIncorrect);

                // Reset conditions
                playerString = "";
                stringCount = 0;
                switch1.ResetConditions();
                switch2.ResetConditions();
                switch3.ResetConditions();
                switch4.ResetConditions();
            }
        }
    }

    // Puzzle 2 Completion Condition Check
    public void BinaryPuzzle()
    {
        if (!isComplete)
        {
            binaryProblemsSolved ++;
        }
        if (binaryProblemsSolved == 2)
        {
            isComplete = true;

            // Play Sound
            masterAudioSource.PlayOneShot(decimalWallMovement);

            // Move the Walls back to reveal hidden room
            pentagonWallAnim.enabled = true;
            diamondWallAnim.enabled = true;
        }
    }

    // Puzzle 3 Completion Condition Check
    public void FlightPuzzle()
    {
        Debug.Log("Finished FLIGHT Puzzle!");
        endDoorAnim.enabled=true;

        // Stop the Background Music
        musicGameObject.SetActive(false);
    }


}
