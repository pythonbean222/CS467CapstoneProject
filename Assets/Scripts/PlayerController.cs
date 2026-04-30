using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera cam;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;

    void Start() {
        // locks cursor to the center of the screen and makes it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        // horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }

    void FixedUpdate() {
        // new Vector3(0f, rb.velocity.y, 0f) -> retains vertical velocity, but discards forward and horizonal velocity
        Vector3 newVelocity = Vector3.up * rb.linearVelocity.y;
        // if input detects the left shift key, then use the run speed, otherwise use the walk speed
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        // transform velocity from local space to world space so that the player moves in the direction they are facing
        rb.linearVelocity = transform.TransformDirection(newVelocity);
    }

    private void LateUpdate() {
        // vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;
    }

    // vertical rotation - prevents the player from looking too far up or down
    public static float RestrictAngle(float angle, float angleMin, float angleMax) {
        if (angle > 180f)
            angle -= 360f;
        else if (angle < -180f)
            angle += 360f;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
}
