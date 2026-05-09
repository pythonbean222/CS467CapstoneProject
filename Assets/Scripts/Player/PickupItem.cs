using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable {

    public ItemSO item;
    public int amount = 1;
    public string itemName = "Fuse";

    public void Interact() {
        Debug.Log($"You picked up a {itemName}!");

        // Add the item to the player's inventory
        Inventory playerInventory = FindAnyObjectByType<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.AddItem(item, amount);

            // Remove the item from the scene after picking it up
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("Player inventory not found!");
        }
    }
}
