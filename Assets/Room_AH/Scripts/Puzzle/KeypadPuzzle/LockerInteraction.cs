using UnityEngine;

// Script for handling player interaction with the locker, including opening the keypad UI and opening the locker door when solved

public class LockerInteraction : MonoBehaviour, IInteractable_AH
{
    // References to the keypad UI, display, locker door, and player controller
    [SerializeField] private GameObject keypadUI;
    [SerializeField] private DigitalDisplay keypadDisplay;
    [SerializeField] private LockerDoor lockerDoor;
    [SerializeField] private FPSController_AH playerController;

    private bool isOpen = false;

    // Static event to notify when the locker has been solved
    public static event System.Action OnLockerSolved;

    public void Interact() {
        // If the locker is already open, do nothing
        if (isOpen) {
            return;
        }

        // Open the keypad UI and disable player movement and looking around
        OpenKeyPad();
        isOpen = true;
    }

    public void OpenKeyPad() {
        // Activate the keypad UI and set this locker as the target for the display to update
        keypadUI.SetActive(true);
        keypadDisplay.SetLocker(this);

        if (playerController != null) {
            // Disable player movement and looking around while the keypad UI is open
            playerController.SetLookEnabled(false);
            playerController.SetMoveEnabled(false);
        } 
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseKeyPad() {
        // Deactivate the keypad UI
        keypadUI.SetActive(false);

        if (playerController != null) {
            // Re-enable player movement and looking around when the keypad UI is closed
            playerController.SetLookEnabled(true);
            playerController.SetMoveEnabled(true);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isOpen = false;
    }

    public void OpenLocker() {
        // Open the locker door and log a message
        lockerDoor.OpenDoor();
        Debug.Log("Locker opened!");

        // Invoke the OnLockerSolved event to notify any listeners that the locker has been solved
        OnLockerSolved?.Invoke();
    }

    public string GetInteractionText() {
        return $"Press E to open keypad";
    }

}
