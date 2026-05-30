using UnityEngine;

// Script for toggling the layer of the fuse box game object when the locker is solved, allowing it to become interactable

public class FuseLayerToggle : MonoBehaviour
{
    [SerializeField] private LockerInteraction locker;
    
    private void OnEnable() {
        // Subscribe to the OnLockerSolved event from the LockerInteraction script to enable the fuse box layer when the locker is solved
        LockerInteraction.OnLockerSolved += EnableFuseLayer;
    }

    private void OnDisable() {
        // Unsubscribe from the OnLockerSolved event when this script is disabled to prevent memory leaks
        LockerInteraction.OnLockerSolved -= EnableFuseLayer;
    }

    private void EnableFuseLayer() {
        // Change the layer of the fuse box game object to "Interactable" to allow player interaction
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }
}
