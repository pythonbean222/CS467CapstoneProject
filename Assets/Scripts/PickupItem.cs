using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable {
    public string itemName = "Fuse";

    public void Interact() {
        Debug.Log($"You picked up a {itemName}!");

        // Remove the item from the scene after picking it up
        Destroy(gameObject);
    }
}