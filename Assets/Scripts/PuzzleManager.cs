using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

public GameObject[] graypuzzlePieces;
public GameObject[] bluepuzzlePieces;
public GameObject[] purplepuzzlePieces;

private int grayATMCounter;
private int blueATMCounter;
private int purpleATMCounter;

public void grayATM()
    {
        grayATMCounter++;

        switch (grayATMCounter)
        {
            case 1:
                graypuzzlePieces[0].SetActive(true);
                graypuzzlePieces[1].SetActive(false);
                graypuzzlePieces[2].SetActive(false);
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
            case 2:
                graypuzzlePieces[1].SetActive(true);
                graypuzzlePieces[0].SetActive(false);
                graypuzzlePieces[2].SetActive(false);
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
            case 3:
                graypuzzlePieces[2].SetActive(true);
                graypuzzlePieces[0].SetActive(false);
                graypuzzlePieces[1].SetActive(false);
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
            case 4:
                graypuzzlePieces[0].SetActive(true);
                graypuzzlePieces[1].SetActive(false);
                graypuzzlePieces[2].SetActive(false);
                grayATMCounter = 0;
                Debug.Log("Gray ATM interacted with. Counter: " + grayATMCounter);
                break;
        }
    }


}
