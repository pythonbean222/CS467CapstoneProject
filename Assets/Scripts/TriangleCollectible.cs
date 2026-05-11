using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        Debug.Log("Player has entered the trigger area of a triangle collectible.");

        if (other.CompareTag("Player") && playerInventory != null)
        {
            playerInventory.CollectTriangle();
            gameObject.SetActive(false);
        }
    }
}
