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
                
                // Open Door
                doubleDoor.OpenDoor();

                // Change Spawn Room Lamp Color to Green
                spawnRoomLight.ChangeMaterial();

                return;
            }
            else
            {
                Debug.Log("INCORRECT ANSWER");

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
    }


}
