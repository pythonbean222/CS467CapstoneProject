using System.Collections;
using UnityEngine;

// Script for the locker door that opens when the correct code is entered on the keypad

public class LockerDoor : MonoBehaviour
{
    [Header("Door Opening Movement")]
    [SerializeField] private Transform doorHinge;
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private float openSpeed = 2.0f;

    private bool opened = false;

    public void OpenDoor() {
        // If the door is already opened, do nothing
        if (opened) return;

        // Start the opening animation
        opened = true;
        StartCoroutine(OpenAnimation());
    }

    private IEnumerator OpenAnimation() {
        // Store the starting rotation and calculate the target rotation based on the openRotation
        Quaternion startRot = doorHinge.localRotation;
        Quaternion endRot = Quaternion.Euler(openRotation);

        // Smoothly interpolate the door's rotation from the starting rotation to the target rotation over time
        float elipsed = 0.0f;

        // Continue the interpolation until the door is fully opened
        while (elipsed < 1.0f) {
            elipsed += Time.deltaTime * openSpeed;
            doorHinge.localRotation = Quaternion.Slerp(startRot, endRot, elipsed);

            yield return null;
        } 

        // Ensure the door is set to the exact target rotation at the end of the animation
        doorHinge.localRotation = endRot;
    }
}
