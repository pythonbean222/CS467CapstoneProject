using UnityEngine;
using UnityEngine.Events;

public class CollectiblePuzzleManager : MonoBehaviour
{
    // WinEventManager reference to track win conditions based on inventory changes.
    [SerializeField] private WinEventManager winEventManager;
    public UnityEvent OnCollectiblePuzzleWin;

    // Inventory-based win check settings.
    // Assign PlayerInventory in the Inspector if possible; otherwise PuzzleManager will try to find one at runtime.
    // The required counts control the conditions for the player to win.
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private int requiredCubes = 4;
    [SerializeField] private int requiredTriangles = 2;
    [SerializeField] private int requiredSpheres = 6;
    private bool hasRegisteredCompletion;

    private void Awake()
    {
    // Fallback lookup so the manager can still work even if the reference is not set manually.
    if (playerInventory == null)
        {
            playerInventory = Object.FindAnyObjectByType<PlayerInventory>();
        }
    }

    private void OnEnable()
    {
    // Listen for each collectible type so the win condition is re-evaluated whenever inventory changes.
    if (playerInventory == null)
        {
            return;
        }

        playerInventory.OnCubeCollected.AddListener(HandleInventoryChanged);
        playerInventory.OnTriangleCollected.AddListener(HandleInventoryChanged);
        playerInventory.OnSphereCollected.AddListener(HandleInventoryChanged);
    }

    private void OnDisable()
    {
        if (playerInventory == null)
        {
            return;
        }

        playerInventory.OnCubeCollected.RemoveListener(HandleInventoryChanged);
        playerInventory.OnTriangleCollected.RemoveListener(HandleInventoryChanged);
        playerInventory.OnSphereCollected.RemoveListener(HandleInventoryChanged);
    }

     private void HandleInventoryChanged(PlayerInventory inventory)
    {
        // Central handler for all inventory updates.
        CheckInventoryWinCondition();
    }

    // This function checks if the player's inventory meets the configured win conditions.
    public void CheckInventoryWinCondition()
    {
        // Compare the player's collected counts against the configured requirements.
        if (playerInventory == null)
        {
            Debug.LogWarning("PuzzleManager could not find a PlayerInventory instance.");
            return;
        }

/*         bool hasRequiredInventory =
            playerInventory.NumberOfCubes >= requiredCubes &&
            playerInventory.NumberOfTriangles >= requiredTriangles &&
            playerInventory.NumberOfSpheres >= requiredSpheres; */

        //if (hasRequiredInventory)
        if (playerInventory.NumberOfCubes >= requiredCubes &&
            playerInventory.NumberOfTriangles >= requiredTriangles &&
            playerInventory.NumberOfSpheres >= requiredSpheres)
        {
            if (hasRegisteredCompletion)
            {
                return;
            }

            hasRegisteredCompletion = true;
            Debug.Log("Player has met the inventory win conditions!");
            OnCollectiblePuzzleWin?.Invoke();
            winEventManager?.RegisterPuzzleCompletion();
        }
    }


}
