using UnityEngine;

public class FuseSlot : MonoBehaviour, IInteractable_AH
{
    [Header("References")]
    [SerializeField] private FuseBoxLightController lightController;
    [SerializeField] private FuseBox fuseBox;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform fuseInsertPoint;
    [SerializeField] private GameObject fusePrefab;

    public bool HasFuse { get; private set; } 

    public void TryInsertFuse() {
        Debug.Log("Attempting to insert fuse");

        if (HasFuse) {
            Debug.Log("Fuse already inserted");
            return;
        }

        if (!inventory.HasItem(inventory.fuseItem)) {
            Debug.Log("No fuse in inventory to insert");
            return;
        }

        inventory.RemoveItem(inventory.fuseItem, 1);
        HasFuse = true;

        Instantiate(fusePrefab, fuseInsertPoint.position, fuseInsertPoint.rotation, transform);
        lightController.InsertFuse();

        fuseBox.CheckAllFuses();
        Debug.Log("Fuse inserted");
    }

    public void Interact() {
        Debug.Log("FuseSlot Interact called");
        TryInsertFuse();
    }

    public string GetInteractionText() {
        return $"Press E to insert fuse";
    }
}
