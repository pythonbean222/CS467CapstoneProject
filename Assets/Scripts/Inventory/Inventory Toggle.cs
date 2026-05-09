using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUI;
    private bool isInventoryOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            isInventoryOpen = !isInventoryOpen;
            inventoryUI.SetActive(isInventoryOpen);
        }
    }
}
