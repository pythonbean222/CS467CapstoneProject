/*
Andrew J Cochran
Github Copilot
Final script to hand interactions for the ATM puzzle. Corrected the original script in ATM_interactions_archives 
to handle interact key logging error. Referenced and used google search and Copilot to assist with implentation. 
Original solution was to use old way of void Update() to check for key press, but this was not working. 
Copilot suggested using Unity's new Input System, which I was using before, yet not the correct way as the frames cannot check the
key input every time. I also added some debug logs to help with testing and troubleshooting.
*/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ATM_interaction : MonoBehaviour
{
    public GameObject atmScreen;
    public UnityEvent onATMInteraction;

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
            return;

        Debug.Log("Player is interacting with the ATM.");
        // null conditional operator to check if onATMInteraction is not null before invoking it
        // same as below code
        /*        if (onATMInteraction != null)
        {
            onATMInteraction.Invoke();
        }
        */
        onATMInteraction?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = true;
        LeanTween.scale(atmScreen, Vector3.one, 2).setEaseInBounce();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;
        LeanTween.scale(atmScreen, Vector3.zero, 2).setEaseInQuad();
    }
}