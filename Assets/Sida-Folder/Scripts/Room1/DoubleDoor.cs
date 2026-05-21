using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    [SerializeField] private Animator doubleDoorAnim;

    public void OpenDoor()
    {
        doubleDoorAnim.enabled = true;
    }
}
