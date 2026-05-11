using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{

public GameObject[] graypuzzlePieces;
public GameObject[] bluepuzzlePieces;
public GameObject[] purplepuzzlePieces;
public UnityEvent atmPuzzleWinnerEvent;

/* // Inventory-based win check settings.
// Assign PlayerInventory in the Inspector if possible; otherwise PuzzleManager will try to find one at runtime.
// The required counts control the conditions for the player to win.
[SerializeField] private PlayerInventory playerInventory;
[SerializeField] private int requiredCubes = 1;
[SerializeField] private int requiredTriangles = 1;
[SerializeField] private int requiredSpheres = 1; */

private int grayATMCounter;
private int blueATMCounter;
private int purpleATMCounter;

/* private void Awake()
{
    // Fallback lookup so the manager can still work even if the reference is not set manually.
    if (playerInventory == null)
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }
} */

/* private void OnEnable()
{
    // Listen for each collectible type so the win condition is re-evaluated whenever inventory changes.
    if (playerInventory == null)
    {
        return;
    }

    playerInventory.OnCubeCollected.AddListener(HandleInventoryChanged);
    playerInventory.OnTriangleCollected.AddListener(HandleInventoryChanged);
    playerInventory.OnSphereCollected.AddListener(HandleInventoryChanged);
} */

/* private void OnDisable()
{
    // Remove listeners to avoid duplicate subscriptions when the object is disabled and re-enabled.
    if (playerInventory == null)
    {
        return;
    }

    playerInventory.OnCubeCollected.RemoveListener(HandleInventoryChanged);
    playerInventory.OnTriangleCollected.RemoveListener(HandleInventoryChanged);
    playerInventory.OnSphereCollected.RemoveListener(HandleInventoryChanged);
} */

/* private void HandleInventoryChanged(PlayerInventory inventory)
{
    // Central handler for all inventory updates.
    CheckInventoryWinCondition();
} */

// win condition function
public void Winner()
    {
        if (graypuzzlePieces[1].activeInHierarchy && bluepuzzlePieces[0].activeInHierarchy && purplepuzzlePieces[2].activeInHierarchy)
        {
            Debug.Log("Player has won the atm puzzle game!");
            atmPuzzleWinnerEvent.Invoke();
        }
    }

/* public void CheckInventoryWinCondition()
{
    // Compare the player's collected counts against the configured requirements.
    if (playerInventory == null)
    {
        Debug.LogWarning("PuzzleManager could not find a PlayerInventory instance.");
        return;
    }

    bool hasRequiredInventory =
        playerInventory.NumberOfCubes >= requiredCubes &&
        playerInventory.NumberOfTriangles >= requiredTriangles &&
        playerInventory.NumberOfSpheres >= requiredSpheres;

    if (hasRequiredInventory)
    {
        Debug.Log("Player has met the inventory win conditions!");
        atmPuzzleWinnerEvent?.Invoke();
    }
}
 */
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
