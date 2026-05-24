using System.Collections.Generic;
using UnityEngine;

// Code adapted from Unity Unlocked's tutorial on making an inventory system in Unity.
// https://www.youtube.com/watch?v=PUKYv-afRnc&list=PLXG1jSmcT-NVNBRb-dCMBsCUbn_xtcwBo

// Class for the inventory, holds a list of slots and has a method to add items to the inventory
public class Inventory : MonoBehaviour
{
    public ItemSO fuseItem;
    public GameObject inventorySlotParent;
    private List<Slot> inventorySlots = new List<Slot>();

    private void Awake() {
        // get all slots in the inventory and add them to a list
        inventorySlots.AddRange(inventorySlotParent.GetComponentsInChildren<Slot>());
    }

    private void Update() {
     
    }

    // Adds an item to the inventory
    public void AddItem(ItemSO itemToAdd, int amount) {
        int remaining = amount;

        //stack the item with existing stacks of the same item
        foreach (Slot slot in inventorySlots) {
            if (slot.HasItem() && slot.GetItem() == itemToAdd) {
                int currentAmount = slot.GetAmount();
                int maxStackSize = itemToAdd.maxStackSize;

                if (currentAmount < maxStackSize) {
                    int spaceLeft = maxStackSize - currentAmount;
                    int amountToAdd = Mathf.Min(spaceLeft, remaining);

                    slot.SetItem(itemToAdd, currentAmount + amountToAdd);
                    remaining -= amountToAdd;

                    if (remaining <= 0)
                        return;
                }
            }
        }

        // any additional items left to add go in empty slots
        foreach (Slot slot in inventorySlots) {
            if (!slot.HasItem()) {
                int amountToPlace = Mathf.Min(itemToAdd.maxStackSize, remaining);
                slot.SetItem(itemToAdd, amountToPlace);
                remaining -= amountToPlace;

                if (remaining <= 0)
                    return;
            }
        }

        // if inventory is full 
        if(remaining > 0) {
            Debug.Log("Not enough space in inventory to add {remaining} {itemToAdd.itemName}");
        }
    }

    public bool HasItem(ItemSO item) {
        // check if any slot has the item
        foreach (Slot slot in inventorySlots) {
            if (slot.HasItem() && slot.GetItem() == item) {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(ItemSO itemToRemove, int amount) {
        int remaining = amount;

        // remove from stacks of the item
        foreach (Slot slot in inventorySlots) {
            // if slot has the item to remove
            if (slot.HasItem() && slot.GetItem() == itemToRemove) {
                int currentAmount = slot.GetAmount();

                // if slot has less than or equal to the remaining amount to remove, clear the slot
                if (currentAmount > 0) {
                    int amountToRemove = Mathf.Min(currentAmount, remaining);
                    slot.RemoveAmount(amountToRemove);
                    remaining -= amountToRemove;
                }

                // if all of the item has been removed, return
                if (remaining <= 0) {
                    return;
                }
            }
        }

        // if not enough of the item to remove
        if(remaining > 0) {
            Debug.Log($"Not enough {itemToRemove.itemName} in inventory to remove {amount}");
        }
    }
}

