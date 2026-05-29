using UnityEngine;

public class DoorOpen_WinEvent : MonoBehaviour
{

    [SerializeField] Transform leftDoorTransform;
    [SerializeField] Transform rightDoorTransform;
    [SerializeField] Vector3 leftDoorOpenOffset;
    [SerializeField] Vector3 rightDoorOpenOffset;
    [SerializeField] float duration = 3f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLeftDoor()
    {
        LeanTween.moveZ(leftDoorTransform.gameObject, leftDoorTransform.position.z + leftDoorOpenOffset.z, duration);
    }

    public void OpenRightDoor()
    {
        LeanTween.moveZ(rightDoorTransform.gameObject, rightDoorTransform.position.z + rightDoorOpenOffset.z, duration);
    }

}
