using UnityEngine;

// Script for each fuse slot in the fuse box. Handles inserting fuses and updating the light controller and fuse box when a fuse is inserted. Implements IInteractable_AH for player interaction.

public class FuseSlot : MonoBehaviour, IInteractable_AH
{
    // set references in Inspector
    [Header("References")]
    [SerializeField] private FuseBoxLightController lightController;
    [SerializeField] private FuseBox fuseBox;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform fuseInsertPoint;
    [SerializeField] private GameObject fusePrefab;

    public bool HasFuse { get; private set; } 

    [Header("Audio")]
    // audio source and clip for inserting fuse
    [SerializeField] private AudioSource puzzleAudio;
    [SerializeField] private AudioClip fuseInsertSound;

    public void TryInsertFuse() {
        // if fuse already inserted, return
        if (HasFuse) {
            return;
        }

        // check if player has a fuse in inventory, if not return
        if (!inventory.HasItem(inventory.fuseItem)) {
            Debug.Log("No fuse in inventory to insert");
            return;
        }

        // remove fuse from inventory, set HasFuse to true
        inventory.RemoveItem(inventory.fuseItem, 1);
        HasFuse = true;

        // instantiate fuse prefab in slot, update light controller,
        Instantiate(fusePrefab, fuseInsertPoint.position, fuseInsertPoint.rotation, transform);
        lightController.InsertFuse();

        // play fuse insert sound
        if (puzzleAudio != null && fuseInsertSound != null) {
            puzzleAudio.PlayOneShot(fuseInsertSound);
        }

        // check if all fuses are inserted and open door if so
        fuseBox.CheckAllFuses();
        Debug.Log("Fuse inserted");
    }

    public void Interact() {
        // when player interacts with the fuse slot, try to insert a fuse
        TryInsertFuse();
    }

    public string GetInteractionText() {
        return $"Press E to insert fuse";
    }
}
