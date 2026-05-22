using System.Collections;
using UnityEngine;

public class PuzzleBox : MonoBehaviour
{
    [Header("Lid Opening Movement")]
    [SerializeField] private Transform lidHinge;
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private float openSpeed = 2.0f;

    // box colliders
    [SerializeField] private Collider boxCollider;
    [SerializeField] private Collider lidCollider;


    private bool opened = false;

    public void OpenBox()
    {
        if (opened) return;

        opened = true;
        StartCoroutine(OpenAnimation());

        // disable colliders to prevent it from getting in the way of picking up the object
        boxCollider.enabled = false;
        lidCollider.enabled = false;
    }

    private IEnumerator OpenAnimation()
    {
        Quaternion startRot = lidHinge.localRotation;
        Quaternion endRot = Quaternion.Euler(openRotation);

        float elipsed = 0.0f;

        while (elipsed < 1.0f)
        {
            elipsed += Time.deltaTime * openSpeed;
            lidHinge.localRotation = Quaternion.Slerp(startRot, endRot, elipsed);

            yield return null;
        } 

        lidHinge.localRotation = endRot;
    }
}
