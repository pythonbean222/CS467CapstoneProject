using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject computerScreen;
    [SerializeField] private GameObject computerText;
    [SerializeField] private UnityEvent onComputerInteraction;

    private escapeRoomControls inputActions;
    private bool playerInRange;

    private void Awake()
    {
        inputActions = new escapeRoomControls();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteractPerformed;
        inputActions.Player.Disable();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        if (!playerInRange)
        {
            return;
        }

        Debug.Log("Player is interacting with the computer.");

        if (computerScreen != null)
        {
            computerScreen.SetActive(true);
        }

        if (onComputerInteraction != null)
        {
            onComputerInteraction.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerInRange = true;
        Debug.Log("Player entered computer interaction range.");
        LeanTween.scale(computerScreen, Vector3.one, 2).setEaseInBounce();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerInRange = false;
        Debug.Log("Player exited computer interaction range.");
        LeanTween.scale(computerScreen, Vector3.zero, 2).setEaseInQuad();
    }
}
