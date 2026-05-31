using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// code adapted from SpeedTutor's video on creating a note system in Unity
// "Creating Notes & Letters in Unity"
// https://www.youtube.com/watch?v=cMTCx4_5Jqc

public class HintNotes : MonoBehaviour, IInteractable_AH
{
    [SerializeField] private FPSController_AH player;

    // UI elements
    [Header("UI")]
    [SerializeField] private GameObject hintCanvas;
    [SerializeField] private Image hintImage;

    // Note content
    [Header("Note Content")]
    [SerializeField] private Sprite hintSprite;
    [SerializeField] private UnityEvent onHintShown;

    private bool isOpen = false;

    public void Interact() {
        // Toggle the hint display when the player interacts
        if (isOpen) {
            CloseHint();
        } else {
            ShowHint();
        }
    }
    private void ShowHint() {
        // Display the hint UI and disable player controls
        hintImage.sprite = hintSprite;
        hintCanvas.SetActive(true);

        onHintShown.Invoke();

        // Disable player movement and show cursor for UI interaction
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isOpen = true;
    }

    public void CloseHint() {
        // Hide the hint UI and re-enable player controls
        hintCanvas.SetActive(false);
        
        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isOpen = false;
    }

    public string GetInteractionText() {
        return isOpen ? $"Press E to close note" : $"Press E to show note";
    }
}
