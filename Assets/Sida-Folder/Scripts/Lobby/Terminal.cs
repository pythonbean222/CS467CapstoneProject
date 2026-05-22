using Unity.VisualScripting;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable_SC
{
    public Canvas canvasMenu;
    public FPSController_SC playerController;

    // Bool to keep track of whether the selection menu is open
    public bool isOpen;

    void Start()
    {
        // Start with the selection menu closed
        isOpen = false;
    }

    public void Interact()
    {
        if (!isOpen)
        {
            // Disable the player's movement script
            playerController.enabled = false;

            // Activates the selection menu
            canvasMenu.gameObject.SetActive(true);

            // Reveals the mouse cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            isOpen = true;
        }
        else
        {
            // Enable the player's movement script
            playerController.enabled = true;

            // Deactivates the selection menu
            canvasMenu.gameObject.SetActive(false);

            // Hides the mouse cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            isOpen = false;
        }
    }
}
