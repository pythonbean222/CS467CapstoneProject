// Citation for how to use the Unity Input System for Player Interaction
// Date: 1 May, 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/Interactions.html
// Source URL: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/RespondingToActions.html
// Source URL: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/ActionAssets.html

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction_SC : MonoBehaviour
{
    public Camera cameraObject;

    // The distance of our Ray Cast
    public float distance = 3f;

    // Player Input Action References (Unity's latest input system)
    public InputActionReference interactAction;

    // Enables our implemented input actions (Necessary for Unity's latest input system)
    void OnEnable()
    {
        // Subscribe interact input action to OnInteract() method
        interactAction.action.started += OnInteract;

        interactAction.action.Enable();
    }

    void OnDisable()
    {
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

    void OnInteract(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(cameraObject.transform.position, cameraObject.transform.forward, out RaycastHit hit, distance))
        {
            // If the raycast hits a collider that implements IInteractable interface, then trigger the interact() method for this particular object
            if (hit.collider.TryGetComponent<IInteractable>(out var interactableObj))
            {
                // Makes the Raycast visible for 10 seconds when Gizmos are enabled (for debugging purposes)
                Debug.DrawRay(cameraObject.transform.position, cameraObject.transform.forward * distance, Color.red, 10f);

                interactableObj.Interact();
            }
        }
    }   
}
