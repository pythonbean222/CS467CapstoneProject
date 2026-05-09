using UnityEngine;
using System.Collections.Generic;

// https://www.youtube.com/watch?v=PUKYv-afRnc&list=PLXG1jSmcT-NVNBRb-dCMBsCUbn_xtcwBo

public class Inventory : MonoBehaviour
{
    public ItemSO fuseItem;

    public GameObject inventorySlotParent;
    private List<Slot> inventorySlots = new List<Slot>();

    private void Awake() {
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

                if (remaining <= 0)
                    return;
            }
        }

        // if inventory is full 
        if(remaining > 0) {
            Debug.Log("Not enough space in inventory to add" + remaining + itemToAdd.itemName);
        }
    }
}

