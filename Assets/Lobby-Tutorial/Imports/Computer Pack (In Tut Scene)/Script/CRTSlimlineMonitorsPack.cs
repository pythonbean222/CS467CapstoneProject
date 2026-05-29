using UnityEngine;
using UnityEngine.SceneManagement;

public class CRTSlimlineMonitorsPack : MonoBehaviour
{
    public GameObject textMesh;
    public MeshRenderer screenRenderer;
    public Material emissiveMaterial;
    public Material normalMaterial;
    public AudioClip ComputerClick;

    private AudioSource audioSource;

    private bool isOn = false;
    private bool playerInRange = false;

    private void Start()
    {
        TurnOffComputer();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isOn)
                TurnOffComputer();
            else
                TurnOnComputer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
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