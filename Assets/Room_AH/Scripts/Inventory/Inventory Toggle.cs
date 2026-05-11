using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI;

    private PlayerInputs input;
    private bool isInventoryOpen;

    private void Awake() {
        input = new PlayerInputs();
    }

    private void OnEnable() {
        input.Player.Enable();
        input.Player.Inventory.performed += ToggleInventory;   
    }

    private void OnDisable() {
        input.Player.Inventory.performed -= ToggleInventory;
        input.Player.Disable();
    }

    private void Start() {
        inventoryUI.SetActive(false);
    }

    private void ToggleInventory(InputAction.CallbackContext context) {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);

        Debug.Log($"Inventory toggled: {(isInventoryOpen ? "Open" : "Closed")}");
    }
}
