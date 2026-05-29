using UnityEngine;

public class Computer : MonoBehaviour, IInteractable_SC
{
    [SerializeField] private FPSController_SC playerController;
    [SerializeField] private GameObject SecurityCamera;
    [SerializeField] private Canvas SecurityCameraCanvas;
    [SerializeField] private Canvas interactPrompt;
    [SerializeField] private AudioSource computerInteractAudio;
    private GameObject cameraReference;

    private bool isActive;

    void Awake()
    {
        // Get a reference to the Camera game object
        cameraReference = SecurityCamera.transform.Find("Camera").gameObject;
    }

    public void Interact()
    {
        if (!isActive)
        {
            playerController.enabled = false;

            // Play Computer Audio
            computerInteractAudio.Play();

            cameraReference.SetActive(true);

            SecurityCameraCanvas.gameObject.SetActive(true);

            interactPrompt.gameObject.SetActive(false);

            isActive = true;
        }
        else
        {
            playerController.enabled = true;

            cameraReference.SetActive(false);

            SecurityCameraCanvas.gameObject.SetActive(false);

            interactPrompt.gameObject.SetActive(true);

            isActive = false;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
