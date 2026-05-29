using System.Collections;
using UnityEngine;

public class LockerDoor : MonoBehaviour
{
    [Header("Door Opening Movement")]
    [SerializeField] private Transform doorHinge;
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private float openSpeed = 2.0f;

    // box colliders
    //[SerializeField] private Collider doorCollider;

    private bool opened = false;

    public void OpenDoor()
    {
        if (opened) return;

        opened = true;
        StartCoroutine(OpenAnimation());

        // disable colliders to prevent it from getting in the way of picking up the object
        //if (doorCollider != null) {
        //    doorCollider.enabled = false;
        //}
    }

    private IEnumerator OpenAnimation()
    {
        Quaternion startRot = doorHinge.localRotation;
        Quaternion endRot = Quaternion.Euler(openRotation);

        float elipsed = 0.0f;

        while (elipsed < 1.0f)
        {
            elipsed += Time.deltaTime * openSpeed;
            doorHinge.localRotation = Quaternion.Slerp(startRot, endRot, elipsed);

            yield return null;
        } 

        doorHinge.localRotation = endRot;
    }
}
