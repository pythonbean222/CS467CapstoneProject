using UnityEngine;

// controls the door opening when all fuses are inserted in the fuse box

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

    [Header("Audio")]
    // audio source and clip for door opening
    [SerializeField] private AudioSource puzzleAudio;
    [SerializeField] private AudioClip doorOpenSound;

    void Start() {
        // set closed positions of doors
        leftDoorClosedPosition = leftDoor.localPosition;
        rightDoorClosedPosition = rightDoor.localPosition;
    }

    // called by FuseBox when all fuses are inserted
    public void OpenDoor() {
        open = true;
        // play door open sound
        if (puzzleAudio != null && doorOpenSound != null) {
            puzzleAudio.PlayOneShot(doorOpenSound);
        }
    }

    void Update() {
        // if door not open, return
        if (!open) {
            return;
        }

        // lerp doors to open position
        leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftDoorClosedPosition + leftDoorOpenOffset, Time.deltaTime * speed);
        rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightDoorClosedPosition + rightDoorOpenOffset, Time.deltaTime * speed);
    }
}
