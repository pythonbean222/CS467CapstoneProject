using UnityEngine;
using System;

// controls each individual fuse slot

public class FuseBox : MonoBehaviour
{
    [Header("Fuse Slots")]
    [SerializeField] private FuseSlot[] fuseSlots;

    [Header("Door")]
    [SerializeField] private DoorController door;

    private bool opened = false;
    // event to notify when the fuse box puzzle is solved
    public event Action OnFuseBoxSolved;

    public void CheckAllFuses() {
        // if door already opened, return
        if (opened) {
            return;
        }

        // check if all fuse slots have a fuse inserted
        foreach (FuseSlot slot in fuseSlots) {
            if (!slot.HasFuse) {
                return;
            }
        }

        // all fuses are inserted, open the door
        opened = true; 
        Debug.Log("All fuses inserted, door opening");
        door.OpenDoor();

        // invoke the event to notify that the puzzle is solved
        OnFuseBoxSolved?.Invoke();
    }

    public bool IsSolved => opened;
}
