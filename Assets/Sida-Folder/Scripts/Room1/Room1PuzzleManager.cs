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

    // Puzzle 1 Method
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

    // Puzzle 2 Method
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


}
