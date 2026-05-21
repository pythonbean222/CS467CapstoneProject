using UnityEngine;

public class CubeLamp : MonoBehaviour, IInteractable
{
    public Material defaultMat;
    public Material emissiveMat;
    
    public void Interact()
    {
        Debug.Log("Interacting with CubeLamp");

        GetComponent<MeshRenderer>().material = emissiveMat;
    }
}
