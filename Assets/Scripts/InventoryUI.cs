using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cubeText;
    [SerializeField] private TextMeshProUGUI triangleText;
    [SerializeField] private TextMeshProUGUI sphereText;

    // Update classes for using player inventory

    public void UpdateCubeCount(PlayerInventory playerInventory)
    {
        cubeText.text = playerInventory.NumberOfCubes.ToString();
    }

    public void UpdateTriangleCount(PlayerInventory playerInventory)
    {
        triangleText.text = playerInventory.NumberOfTriangles.ToString();
    }

    public void UpdateSphereCount(PlayerInventory playerInventory)
    {
        sphereText.text = playerInventory.NumberOfSpheres.ToString();
    }
}
