using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Code adapted from Unity Unlocked's tutorial on making an inventory system in Unity.
// https://www.youtube.com/watch?v=PUKYv-afRnc&list=PLXG1jSmcT-NVNBRb-dCMBsCUbn_xtcwBo

// Class for a slot in the inventory, holds an item and amount, updates visuals, and tracks if hovering
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovering;
    private ItemSO heldItem;
    private int itemAmount;
    private Image iconImage;
    private TextMeshProUGUI amountText;

    private void Awake() {
        // get the image and text from the slot's children
        iconImage = transform.GetChild(0).GetComponent<Image>();
        amountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    // returns the item held in this slot; null if empty
    public ItemSO GetItem() {
        return heldItem;
    }

    // returns the amount of the item held in this slot
    public int GetAmount() {
        return itemAmount;
    }

    // sets item and amount for a slot, updates the visuals
    public void SetItem(ItemSO item, int amount = 1) {
        heldItem = item;
        itemAmount = amount;

        UpdateSlot();
    }

    public void UpdateSlot() {
        // if an item is in slot, show icon and amount
        if (heldItem != null) {
            iconImage.enabled = true;
            iconImage.sprite = heldItem.itemIcon;
            amountText.text = itemAmount.ToString();
        }
        else {
            // if no item in slot, hide icon and clear amount
            iconImage.enabled = false;
            amountText.text = "";
        }
    }

    // add to amount of an item in a slot, update visuals, return new amount
    public int AddAmount(int amountToAdd) {
        itemAmount += amountToAdd;
        UpdateSlot();
        return itemAmount;
    }

    // remove from amount of an item in a slot, update visuals, return new amount
    public int RemoveAmount(int amountToRemove) {
        itemAmount -= amountToRemove;
        if(itemAmount <= 0) {
            ClearSlot();
        }
        else {
            UpdateSlot();
        }

        return itemAmount;
    }

    // clear the slot of any item and update visuals
    public void ClearSlot() {
        heldItem = null;
        itemAmount = 0;
        UpdateSlot();
    }

    // return true if item in a slot, false if empty
    public bool HasItem() {
        return heldItem != null;
    }

    // return true if item in a slot is the same as the given item
    public void OnPointerEnter(PointerEventData eventData) {
        hovering = true;
    }

    // return false if item in a slot is the same as the given item
    public void OnPointerExit(PointerEventData eventData) {
        hovering = false;
    }
}
