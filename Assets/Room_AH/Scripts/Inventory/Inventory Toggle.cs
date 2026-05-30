using UnityEngine;
using UnityEngine.InputSystem;

// Code adapted from Unity Unlocked's tutorial on making an inventory system in Unity.
// https://www.youtube.com/watch?v=PUKYv-afRnc&list=PLXG1jSmcT-NVNBRb-dCMBsCUbn_xtcwBo

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI;
    private PlayerInputs input;
    private bool isInventoryOpen;

    private void Awake() {
        // set up input system and subscribe to inventory toggle action
        input = new PlayerInputs();
    }

    private void OnEnable() {
        // enable input and subscribe to inventory toggle action
        input.Player.Enable();
        input.Player.Inventory.performed += ToggleInventory;   
    }

    private void OnDisable() {
        //  
        input.Player.Inventory.performed -= ToggleInventory;
        input.Player.Disable();
    }

    private void Start() {
        //  ensure inventory is closed at start
        inventoryUI.SetActive(false);
    }

    private void ToggleInventory(InputAction.CallbackContext context) {
        // toggle inventory UI on/off
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);

        Debug.Log("Inventory toggled: " + (isInventoryOpen ? "Open" : "Closed"));
    }
}
