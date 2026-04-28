using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public static float distanceFromTarget;
    [SerializeField] float toTarget;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            
            toTarget = hit.distance;
            distanceFromTarget = hit.distance;
            Debug.Log("Distance from target: " + toTarget);

        }
    }
}
