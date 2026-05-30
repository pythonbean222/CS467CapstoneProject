using System.Collections;
using UnityEngine;

// Script for controlling the opening of the prize boxs in the puzzle room

public class PuzzlePrizeBox : MonoBehaviour
{
    // set in Inspector
    [Header("Lid Opening Movement")]
    [SerializeField] private Transform lidHinge;
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private float openSpeed = 2.0f;

    // box colliders
    [SerializeField] private Collider boxCollider;
    [SerializeField] private Collider lidCollider;


    private bool opened = false;

    public void OpenBox() {
        // if box already opened, return
        if (opened) return;

        // set opened to true and start opening animation
        opened = true;
        StartCoroutine(OpenAnimation());

        // disable colliders to prevent it from getting in the way of picking up the object
        boxCollider.enabled = false;
        lidCollider.enabled = false;
    }

    private IEnumerator OpenAnimation() {
        // store the starting rotation of the lid and calculate the target rotation based on the openRotation variable
        Quaternion startRot = lidHinge.localRotation;
        Quaternion endRot = Quaternion.Euler(openRotation);

        // elipsed time starts at 0 and increases until it reaches 1, at which point the lid will be fully open
        float elipsed = 0.0f;

        // while elipsed time is less than 1, keep rotating the lid towards the target rotation based on the openSpeed variable
        while (elipsed < 1.0f) {
            elipsed += Time.deltaTime * openSpeed;
            lidHinge.localRotation = Quaternion.Slerp(startRot, endRot, elipsed);

            yield return null;
        } 

        // ensure the lid is set to the exact target rotation at the end of the animation
        lidHinge.localRotation = endRot;
    }
}
