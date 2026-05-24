using UnityEngine;

public class FuseBox : MonoBehaviour
{
    [Header("Fuse Slots")]
    [SerializeField] private FuseSlot[] fuseSlots;

    [Header("Door")]
    [SerializeField] private DoorController door;

    private bool opened = false;

    public void CheckAllFuses() {
        if (opened) {
            return;
        }

        // if all fuse slots have a fuse, open the door
        foreach (FuseSlot slot in fuseSlots) {
            Debug.Log($"{slot.name} HasFuse = {slot.HasFuse}");
            if (!slot.HasFuse) {
                return;
            }
        }

        opened = true;
        Debug.Log("All fuses inserted, door opening");
        door.OpenDoor();
    }
}
