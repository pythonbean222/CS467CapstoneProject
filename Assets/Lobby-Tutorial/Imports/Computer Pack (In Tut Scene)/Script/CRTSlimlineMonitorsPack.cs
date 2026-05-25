using UnityEngine;
using UnityEngine.SceneManagement;

public class CRTSlimlineMonitorsPack : MonoBehaviour
{
    public GameObject textMesh;
    public MeshRenderer screenRenderer;
    public Material emissiveMaterial;
    public Material normalMaterial;
    public AudioClip ComputerClick;
    AudioSource audioSource;

    private bool isOn = false;

    private void Start()
    {
        TurnOffComputer();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (isOn)
            TurnOffComputer();
        else
            TurnOnComputer();
    }

    private void TurnOnComputer()
    {
        if (screenRenderer != null && emissiveMaterial != null)
        {
            Material[] mats = screenRenderer.materials;
            mats[1] = emissiveMaterial; 
            screenRenderer.materials = mats;
        }

        if (textMesh != null)
            textMesh.SetActive(true);

        isOn = true;
            StartCoroutine(LoadSceneAfterSound());
    }

    private void TurnOffComputer()
    {
        if (screenRenderer != null && normalMaterial != null)
        {
            Material[] mats = screenRenderer.materials;
            mats[1] = normalMaterial;
            screenRenderer.materials = mats;
        }

        if (textMesh != null)
            textMesh.SetActive(false);

        isOn = false;
    }
    private System.Collections.IEnumerator LoadSceneAfterSound()
    {
        audioSource.PlayOneShot(ComputerClick);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TutorialPuzzle");
    }
}
