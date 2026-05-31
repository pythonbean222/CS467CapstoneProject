using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HintNotes : MonoBehaviour, IInteractable_AH
{
    [SerializeField] private FPSController_AH player;

    [Header("UI")]
    [SerializeField] private GameObject hintCanvas;
    [SerializeField] private Image hintImage;

    [Header("Note Content")]
    [SerializeField] private Sprite hintSprite;
    [SerializeField] private UnityEvent onHintShown;

    private bool isOpen = false;

    public void Interact() {
        if (isOpen) {
            CloseHint();
        } else {
            ShowHint();
        }
    }
    private void ShowHint() {
        Debug.Log("ShowHint called");

        hintImage.sprite = hintSprite;
        hintCanvas.SetActive(true);

        onHintShown.Invoke();

        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isOpen = true;
    }

    public void CloseHint() {
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
