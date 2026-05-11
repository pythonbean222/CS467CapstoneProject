using UnityEngine;

// https://www.youtube.com/watch?v=PUKYv-afRnc&list=PLXG1jSmcT-NVNBRb-dCMBsCUbn_xtcwBo

[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int maxStackSize;
    public GameObject itemPrefab;
    public GameObject handItemPrefab;

}
