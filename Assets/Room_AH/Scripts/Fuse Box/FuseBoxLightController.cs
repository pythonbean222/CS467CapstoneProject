using UnityEngine;

// controls the red and green light for each fuse slot, updates based on whether a fuse is inserted or not

public class FuseBoxLightController : MonoBehaviour
{
    [Header("Renderers")]
    // set meshes for each light in Inspector
    [SerializeField] private MeshRenderer fuseRed;
    [SerializeField] private MeshRenderer fuseGreen;

    private bool fuseInserted;

    void Start() {
        // fuse initially removed, so red light on and green light off
        UpdateLights();
    }

    public void InsertFuse() {
        // if fuse already inserted, return
        if (fuseInserted) return;

        // set fuse as inserted and update lights
        fuseInserted = true;
        UpdateLights();
    }  

    public void RemoveFuse() {
        // if fuse already removed, return
        if (!fuseInserted) return;

        // set fuse as removed and update lights
        fuseInserted = false;
        UpdateLights();
    }

    // set color meshes
    private void UpdateLights() {
        // if no fuse, red light on and green light off
        fuseRed.enabled = !fuseInserted;
        // if fuse inserted, red light off and green light on
        fuseGreen.enabled = fuseInserted;
    }
}
