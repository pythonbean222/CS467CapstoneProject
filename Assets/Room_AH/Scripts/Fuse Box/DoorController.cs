using UnityEngine;

public class DoorController : MonoBehaviour
{
    // set door animator in Inspector
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;

    [SerializeField] private Vector3 leftDoorOpenOffset;
    [SerializeField] private Vector3 rightDoorOpenOffset;

    [SerializeField] private float speed = 3f;
    
    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;

    private bool open = false;

    void Start() {
        leftDoorClosedPosition = leftDoor.localPosition;
        rightDoorClosedPosition = rightDoor.localPosition;
    }

    // called by FuseBox when all fuses are inserted
    public void OpenDoor() {
        Debug.Log("DOOR OPEN TRIGGERED");
        open = true;
    }

    void Update() {
        if (!open) {
            return;
        }

        leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftDoorClosedPosition + leftDoorOpenOffset, Time.deltaTime * speed);
        rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightDoorClosedPosition + rightDoorOpenOffset, Time.deltaTime * speed);
    }
}
