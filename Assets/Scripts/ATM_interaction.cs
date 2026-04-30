using UnityEngine;
using UnityEngine.Events;

public class ATM_interaction : MonoBehaviour
{
    // Reference to ATM screen
    public GameObject atmScreen;

    escapeRoomControls inputActions;

    public UnityEvent onATMInteraction;

    private void Awake()
    {
        inputActions = new escapeRoomControls();
    }

    // trigger for entering ATM zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Code to display ATM interaction UI or trigger ATM functionality
            // Debug.Log("Player has entered the ATM interaction zone.");
            LeanTween.scale(atmScreen, Vector3.one, 2).setEaseInBounce();
        }
    }

    // trigger for exiting ATM zone
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Code to hide ATM interaction UI or disable ATM functionality
            // Debug.Log("Player has exited the ATM interaction zone.");
            LeanTween.scale(atmScreen, Vector3.zero, 2).setEaseInQuad();
        }
    }

    // trigger for interacting with the ATM while in the zone
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //  || inputActions.Player.Interact.WasReleasedThisFrame()
            if (inputActions.Player.Interact.WasPressedThisFrame())
            {
                // Code to handle interaction with the ATM, such as opening a menu or performing an action
                Debug.Log("Player is interacting with the ATM.");
                onATMInteraction.Invoke();
            }
        }
    }

    public void OnEnable()
    {
        inputActions.Player.Enable();
    }

    public void OnDisable()
    {
        inputActions.Player.Disable();
    }
}
