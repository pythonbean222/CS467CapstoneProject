using UnityEngine;

// Script for pickup items in the game, such as the fuse item. Implements the IInteractable_AH interface to allow player interaction.

public class PickupItem : MonoBehaviour, IInteractable_AH {

    public ItemSO item;
    public int amount = 1;
    public string itemName = "Fuse";
    private bool alreadyPickedUp = false;

    public void Interact() {
        // prevent player from picking up the same item multiple times
        if (alreadyPickedUp) return;
        alreadyPickedUp = true;

        Debug.Log($"You picked up a {itemName}!");

        // Add the item to the player's inventory
        Inventory playerInventory = FindAnyObjectByType<Inventory>();
        if (playerInventory != null) {
            playerInventory.AddItem(item, amount);

            // Remove the item from the scene after picking it up
            Destroy(gameObject);
        }
        else {
            // Log an error if the player's inventory is not found
            Debug.LogError("Player inventory not found!");
        }
    }

    public string GetInteractionText() {
        return $"Press E to pick up {itemName}";
    }
}
