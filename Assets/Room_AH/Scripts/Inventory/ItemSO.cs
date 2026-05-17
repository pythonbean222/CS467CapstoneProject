using UnityEngine;

// Code adapted from Unity Unlocked's tutorial on making an inventory system in Unity.
// https://www.youtube.com/watch?v=PUKYv-afRnc&list=PLXG1jSmcT-NVNBRb-dCMBsCUbn_xtcwBo

// ScriptableObject that holds data for an item in the inventory
[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int maxStackSize;
    public GameObject itemPrefab;
    public GameObject handItemPrefab;

}
