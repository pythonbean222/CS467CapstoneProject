// Citation for how to use the Unity Input System for Player Interaction
// Date: 1 May, 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/Interactions.html
// Source URL: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/RespondingToActions.html
// Source URL: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/ActionAssets.html

// Date: 11 May, 2026
// made changes to the original code provided by Sida to add a tooltip system that shows the interaction text of the current interactable object that the player is looking at - AH

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cameraObject;
    // The distance of our Ray Cast
    public float distance = 3f;
    // Player Input Action References (Unity's latest input system)
    public InputActionReference interactAction;

    // Added by AH - to keep track of the current interactable object that the player is looking at
    private IInteractable_AH currentInteractable;

    // Enables our implemented input actions (Necessary for Unity's latest input system)
    void OnEnable() {
        // Subscribe interact input action to OnInteract() method
        if (interactAction == null) {
        return;
        }

        interactAction.action.started += OnInteract;
        interactAction.action.Enable();
    }

    void OnDisable() {
        // Unsubscribe interact input action from OnInteract() method
        interactAction.action.started -= OnInteract;
        interactAction.action.Disable();
    }

    // Citation for how to use a Raycast in Unity
    // Date: 1 May, 2026
    // Adapted from Unity Documentation
    // Source URL: https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Physics.Raycast.html

    // Citation for how to check if a Raycast-hit object implements an interface
    // Date: 1 May, 2026
    // Adapted from Unity Discussions
    // Source URL: https://discussions.unity.com/t/raycasting-for-interactables/920097

    void OnInteract(InputAction.CallbackContext context) {
        //Debug.Log("Current interactable = " + currentInteractable);
 
        // Adding layer mask to ensure that the raycast does not interact with player - AH
        int layerMask = ~LayerMask.GetMask("Player");
        // If there is an interactable object currently in range, interact with it
        if (currentInteractable != null) {
            currentInteractable.Interact();
        }
    }

    // Checks for interactable objects in front of the player using a raycast - used in tooltip system by AH
    private void Update() {
        CheckForInteractable();
    }

    private void CheckForInteractable() {
        // Blocking is set so that the player cannot interact with objects inside boxes
        int layerMask = LayerMask.GetMask("Interactable", "Blocking");
        
        // Perform a raycast from the camera's position in the forward direction, checking for objects in the Interactable and Blocking layers
        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.forward, out RaycastHit hit, distance, layerMask)) {
            //Debug.Log($"Raycast hit: {hit.collider.gameObject.name}");
            //Debug.Log($"Raycast hit: {hit.collider.gameObject.name}");

            // If the raycast hits a collider in the Blocking layer, clear the current interactable and hide the tooltip
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Blocking")) {
                //Debug.Log("Hit a blocking object, cannot interact.");
                ClearInteractable();
                return;
            }

            // If the raycast hits a collider that implements IInteractable interface, then trigger the interact() method for this particular object
            if (hit.collider.TryGetComponent<IInteractable_AH>(out var interactableObj)) {
                // Set the current interactable object and show the tooltip
                currentInteractable = interactableObj;
                TooltipSystem.Show(interactableObj.GetInteractionText());
                return;
            }
        }
        
        ClearInteractable();
    }   

    void ClearInteractable() {
        if (currentInteractable != null) {
            currentInteractable = null;
            TooltipSystem.Hide();
        }
    }
}
