using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        Debug.Log("Player has entered the trigger area of a cube collectible.");

        if (other.CompareTag("Player") && playerInventory != null)
        {
            playerInventory.CollectCube();
            gameObject.SetActive(false);
        }
    }
}
