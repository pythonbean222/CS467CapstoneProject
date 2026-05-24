
/*
Andrew J Cochran

Computer Interaction script. Allows the player to interact with the computer in the escape room.
Will trigger the computer screen to appear and allow the player to interact with it, then
opens a number guessing game for the player to solve.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ComputerInteraction : MonoBehaviour
{
   public GameObject computerScreen;
   public UnityEvent onComputerInteraction;

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

        Debug.Log("Player is interacting with the computer.");
        // null conditional operator to check if onComputerInteraction is not null before invoking it
        // same as below code
            if (onComputerInteraction != null)
            {
                onComputerInteraction.Invoke();
            }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = true;
        Debug.Log("Player entered computer interaction range.");
        //LeanTween.scale(computerScreen, Vector3.one, 2).setEaseInBounce();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;
        Debug.Log("Player exited computer interaction range.");
        //LeanTween.scale(computerScreen, Vector3.zero, 2).setEaseInBounce();
    }
}
