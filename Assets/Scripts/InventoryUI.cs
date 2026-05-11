using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI cubeText;
    private TextMeshProUGUI triangleText;
    private TextMeshProUGUI sphereText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // create references to the sphere, cube, and triangle text objects
        sphereText = GetComponent<TextMeshProUGUI>();
        cubeText = GetComponent<TextMeshProUGUI>();
        triangleText = GetComponent<TextMeshProUGUI>();
    }

    // Update class for using player inventory
    public void UpdateCollectibleCounts(PlayerInventory playerInventory)
    {
        // update the text of the sphere, cube, and triangle text objects to reflect the current counts in the player inventory
        sphereText.text = playerInventory.NumberOfSpheres.ToString();
        cubeText.text = playerInventory.NumberOfCubes.ToString();
        triangleText.text = playerInventory.NumberOfTriangles.ToString();
    }
}
