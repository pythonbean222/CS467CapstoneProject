// Citation for using the Character Controller Component to create a functional FPS Controller
// Date: 26 April, 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

// Citation for the MoveCharacter() and Look() methods
// Date: 27 April, 2026
// Adapted from YouTube Creator: Ironbark Games Studio
// Source URL: https://www.youtube.com/watch?v=HvGY7S8UFD0

using UnityEngine;
using UnityEngine.InputSystem;

public class FPSController_BR : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    // Player attributes
    public float speed = 5f;
    public float gravity = -9.81f;
    public float acceleration = 10f;
    // public float jumpHeight = 2f;
    public float mouseSensitivity = 0.15f;
    
    // Player Input Action References (Unity's latest input system)
    public InputActionReference moveAction;
    public InputActionReference lookAction;
    // public InputActionReference jumpAction;

    // Used to apply acceleration and inertia to Player movement
    Vector3 velocity;
    Vector3 currentVelocity;

    // Used to track the Camera angle
    float xRotation;

    void Start()
    {
        // Hides the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Enables our implemented input actions (Necessary for Unity's latest input system)
    void OnEnable()
    {
        moveAction.action.Enable();
        lookAction.action.Enable();
        // jumpAction.action.Enable();
    }

    // Disables our implemented input actions
    void OnDisable()
    {
        moveAction.action.Disable();
        lookAction.action.Disable();
        // jumpAction.action.Disable();
    }
    
    void Update()
    {
        Look();
        // Jump();
        ApplyGravity();
        MoveCharacter();
    }

    // Method that handles player movement
    void MoveCharacter()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 move = new Vector3(input.x, 0f, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        move = transform.TransformDirection(move);

        // Apply acceleration for more natural movement/inertia
        Vector3 targetVelocity = move * speed;

        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);

        Vector3 finalMove = currentVelocity + Vector3.up * velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }

    // Method that handles player mouse look
    void Look()
    {
        Vector2 look = lookAction.action.ReadValue<Vector2>();

        float mouseX = look.x * mouseSensitivity;
        float mouseY = look.y * mouseSensitivity;

        xRotation = Mathf.Clamp(xRotation - mouseY, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    /* Disabling Jump Functionality
    void Jump()
    {
        if (jumpAction.action.triggered && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    */

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
    }
}
