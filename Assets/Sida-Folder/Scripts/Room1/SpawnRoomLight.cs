using UnityEngine;

public class SpawnRoomLight : MonoBehaviour
{
    [SerializeField] private Material offlineMaterial;
    [SerializeField] private Material onlineMaterial;

    // Method that changes the lamp material to emissive green, disables the red pointlight, and enables the green pointlight
    public void ChangeMaterial()
    {
        transform.Find("lamp_mesh").GetComponent<MeshRenderer>().material = onlineMaterial;

        transform.Find("pointlight_red").gameObject.SetActive(false);

        transform.Find("pointlight_green").gameObject.SetActive(true);
    }
}
