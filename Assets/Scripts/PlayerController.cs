using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera cam;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpSpeed;
    public float impactThreshold;               //  impact force required to cause fall damage
    public float itemPickupDistance;            // max distance a player must be to pick up item

    [Header("Camera Effects")]
    public float baseCameraFov = 60f;           // default field of view
    public float baseCameraHeight = 0.85f;      // default camera height

    public float walkBobbingRate = 0.75f;       // rate of camera bobbing while walking
    public float runBobbingRate = 1.0f;         // rate of camera bobbing while running
    public float maxWalkBobbingOffset = 0.2f;   // max vertical offset for bobbing while walking
    public float maxRunBobbingOffset = 0.35f;   // max vertical offset for bobbing while running

    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrounded = false;                    // is player touching ground
    bool isJumping = false;                     // is player currently jumping
    float vyCache;                              // for implementing fall damage
    Transform attachedObject = null;
    float attachedDistance = 0.0f;

    void Start() {
        // locks cursor to the center of the screen and makes it invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        // horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);

        // new Vector3(0f, rb.velocity.y, 0f) -> retains vertical velocity, but discards forward and horizonal velocity
        newVelocity = Vector3.up * rb.linearVelocity.y;
        // if input detects the left shift key, then use the run speed, otherwise use the walk speed
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
                newVelocity.y = jumpSpeed;
                isJumping = true;
            }
        }

        // check if grounded and there is movement imput
        if ((Input.GetAxis("Vertical")) != 0f || (Input.GetAxis("Horizontal") != 0f) && isGrounded) {
            float bobbingRate = Input.GetKey(KeyCode.LeftShift) ? runBobbingRate : walkBobbingRate;
            float bobbingOffset = Input.GetKey(KeyCode.LeftShift) ? maxRunBobbingOffset : maxWalkBobbingOffset;
            // goes between 0 and bobbing offset at the given rate; subtract half of bobbing offset to center the bob around the base camera height
            Vector3 targetHeadPosistion = Vector3.up * baseCameraHeight + Vector3.up * (Mathf.PingPong(Time.time * bobbingRate, bobbingOffset) - bobbingOffset * 0.5f);
            // smoothly interpolate the camera's position to create a bobbing effect
            head.localPosition = Vector3.Lerp(head.localPosition, targetHeadPosistion, 0.1f);
        }

        // transform velocity from local space to world space so that the player moves in the direction they are facing
        rb.linearVelocity = transform.TransformDirection(newVelocity);

        // picking up items
        RaycastHit hit;
        // casts a ray from the player's head in the direction they are looking; if it hits an object within the item pickup distance, stored in the hit variable
        bool cast = Physics.Raycast(head.position, head.forward, out hit, itemPickupDistance);
        // if the player presses the F key, check if they are already holding an object; if yes, drop
        if (Input.GetKeyDown(KeyCode.F)) {
            if (attachedObject != null) {
                attachedObject.SetParent(null);

                if (attachedObject.GetComponent<Rigidbody>() != null)
                    attachedObject.GetComponent<Rigidbody>().isKinematic = false;

                if (attachedObject.GetComponent<Collider>() != null)
                    attachedObject.GetComponent<Collider>().enabled = true;

                attachedObject = null;
            // if the player is not holding an object, try picking up a nearby pickable item
            } else {
                if (cast) {
                    if (hit.transform.CompareTag("Pickable")) {
                        attachedObject = hit.transform;
                        attachedObject.SetParent(transform);

                        if (attachedObject.GetComponent<Rigidbody>() != null)
                            attachedObject.GetComponent<Rigidbody>().isKinematic = true;

                        if (attachedObject.GetComponent<Collider>() != null)
                            attachedObject.GetComponent<Collider>().enabled = false; 
                    }
                }
            }
        }
    }

    void FixedUpdate() {
        // another way to detect if the player is touching the ground; using Raycast with a distance of 1.0 
        //if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.0f))
        //    isGrounded = true;
        //else isGrounded = false;

        // for calculating fall damage
        vyCache = rb.linearVelocity.y;
    }

    void LateUpdate() {
        // vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;

        // FOV
        float fovOffset = (rb.linearVelocity.y < 0.0f) ? Mathf.Sqrt(Mathf.Abs(rb.linearVelocity.y)) : 0.0f;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseCameraFov + fovOffset, 0.25f);

        // if the player is holding an object
        if (attachedObject != null) {
            // position object in front of the player's head and allow the player to rotate it using the mouse scroll wheel
            attachedObject.position = head.position + head.forward * attachedDistance;
            attachedObject.Rotate(transform.right * Input.mouseScrollDelta.y * 30.0f, Space.World);
        }
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

    void OnCollisionStay(Collision col) {
        isGrounded = true;
        isJumping = false;
    }

    void OnCollisionExit(Collision col) {
        isGrounded = false;
    }

     void OnCollisionEnter(Collision col) {
        // prevents fall damage from hitting a wall/only applies fall damage when hitting the ground
        if (Vector3.Dot(col.GetContact(0).normal, Vector3.up) < 0.5f) {
            if (rb.linearVelocity.y < -5f) {
                rb.linearVelocity = Vector3.up * rb.linearVelocity.y;
                return;
            }
        }

        // f = m*a -- using acceleration to calculate fall damage;
       float acceleration = (rb.linearVelocity.y - vyCache) / Time.fixedDeltaTime;
       float impactForce = (rb.mass * Mathf.Abs(acceleration));     // kepp fall damage from becoming negative

        if (impactForce >= impactThreshold) {
            Debug.Log("Fall damage!");
        }
    }
}
