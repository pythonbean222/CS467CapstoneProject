using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        Debug.Log("Player has entered the trigger area of a sphere collectible.");

        if (other.CompareTag("Player") && playerInventory != null)
        {
            playerInventory.CollectSphere();
            gameObject.SetActive(false);
        }
    }
}
