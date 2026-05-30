using UnityEngine;

// controls each individual fuse slot

public class FuseBox : MonoBehaviour
{
    [Header("Fuse Slots")]
    [SerializeField] private FuseSlot[] fuseSlots;

    [Header("Door")]
    [SerializeField] private DoorController door;

    private bool opened = false;

    public void CheckAllFuses() {
        // if door already opened, return
        if (opened) {
            return;
        }

        // if all fuse slots have a fuse, open the door
        foreach (FuseSlot slot in fuseSlots) {
            if (!slot.HasFuse) {
                return;
            }
        }

        opened = true;
        
        Debug.Log("All fuses inserted, door opening");
        door.OpenDoor();
    }
}
