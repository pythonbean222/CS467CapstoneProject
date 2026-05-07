using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{

public GameObject[] graypuzzlePieces;
public GameObject[] bluepuzzlePieces;
public GameObject[] purplepuzzlePieces;
public UnityEvent atmPuzzleWinnerEvent;

private int grayATMCounter;
private int blueATMCounter;
private int purpleATMCounter;

// win condition function
public void Winner()
    {
        if (graypuzzlePieces[1].activeInHierarchy && bluepuzzlePieces[0].activeInHierarchy && purplepuzzlePieces[2].activeInHierarchy)
        {
            Debug.Log("Player has won the game!");
            atmPuzzleWinnerEvent.Invoke();
        }
    }

public void grayATM()
    {
        grayATMCounter++;

        switch (grayATMCounter)
        {
            case 0:
                graypuzzlePieces[0].SetActive(true);
                graypuzzlePieces[1].SetActive(false);
                graypuzzlePieces[2].SetActive(false);
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
            case 1:
                graypuzzlePieces[1].SetActive(true);
                graypuzzlePieces[0].SetActive(false);
                graypuzzlePieces[2].SetActive(false);
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
            case 2:
                graypuzzlePieces[2].SetActive(true);
                graypuzzlePieces[0].SetActive(false);
                graypuzzlePieces[1].SetActive(false);
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
            case 3:
                graypuzzlePieces[0].SetActive(true);
                graypuzzlePieces[1].SetActive(false);
                graypuzzlePieces[2].SetActive(false);
                grayATMCounter = 0;
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
        }
    }

public void blueATM()
    {
        blueATMCounter++;

        switch (blueATMCounter)
        {
            case 0:
                bluepuzzlePieces[0].SetActive(true);
                bluepuzzlePieces[1].SetActive(false);
                bluepuzzlePieces[2].SetActive(false);
                Debug.Log("Blue ATM interacted with. Counter: " + blueATMCounter);
                break;
            case 1:
                bluepuzzlePieces[1].SetActive(true);
                bluepuzzlePieces[0].SetActive(false);
                bluepuzzlePieces[2].SetActive(false);
                Debug.Log("Blue ATM interacted with. Counter: " + blueATMCounter);
                break;
            case 2:
                bluepuzzlePieces[2].SetActive(true);
                bluepuzzlePieces[0].SetActive(false);
                bluepuzzlePieces[1].SetActive(false);
                Debug.Log("Blue ATM interacted with. Counter: " + blueATMCounter);
                break;
            case 3:
                bluepuzzlePieces[0].SetActive(true);
                bluepuzzlePieces[1].SetActive(false);
                bluepuzzlePieces[2].SetActive(false);
                blueATMCounter = 0;
                Debug.Log("Blue ATM interacted with. Counter: " + blueATMCounter);
                break;
        }
    }

public void purpleATM()
    {
        purpleATMCounter++;

        switch (purpleATMCounter)
        {
            case 0:
                purplepuzzlePieces[0].SetActive(true);
                purplepuzzlePieces[1].SetActive(false);
                purplepuzzlePieces[2].SetActive(false);
                Debug.Log("Purple ATM interacted with. Counter: " + purpleATMCounter);
                break;
            case 1:
                purplepuzzlePieces[1].SetActive(true);
                purplepuzzlePieces[0].SetActive(false);
                purplepuzzlePieces[2].SetActive(false);
                Debug.Log("Purple ATM interacted with. Counter: " + purpleATMCounter);
                break;
            case 2:
                purplepuzzlePieces[2].SetActive(true);
                purplepuzzlePieces[0].SetActive(false);
                purplepuzzlePieces[1].SetActive(false);
                Debug.Log("Purple ATM interacted with. Counter: " + purpleATMCounter);
                break;
            case 3:
                purplepuzzlePieces[0].SetActive(true);
                purplepuzzlePieces[1].SetActive(false);
                purplepuzzlePieces[2].SetActive(false);
                purpleATMCounter = 0;
                Debug.Log("Purple ATM interacted with. Counter: " + purpleATMCounter);
                break;
        }
    }


}
