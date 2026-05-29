using UnityEngine;

public class LockerInteraction : MonoBehaviour, IInteractable_AH
{
    [SerializeField] private GameObject keypadUI;
    [SerializeField] private DigitalDisplay keypadDisplay;
    [SerializeField] private LockerDoor lockerDoor;

    private bool isOpen = false;

    public void Interact() {
        if (isOpen) {
            return;
        }
        Debug.Log("Locker Interacted");
        OpenKeyPad();
        isOpen = true;
    }

    public void OpenKeyPad() {
        keypadUI.SetActive(true);
        keypadDisplay.SetLocker(this);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseKeyPad() {
        keypadUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isOpen = false;
    }

    public void OpenLocker() {
        lockerDoor.OpenDoor();
        Debug.Log("Locker opened!");
    }

    public string GetInteractionText() {
        return $"Press E to open keypad";
    }

}
