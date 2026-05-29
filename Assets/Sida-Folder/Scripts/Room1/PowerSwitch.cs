// Citation for how to use "Transform.Find" to find a child object by string name
// Date: 6 May 2026
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Transform.Find.html

using System.Collections;
using UnityEngine;

public class PowerSwitch : MonoBehaviour, IInteractable_SC
{
    [SerializeField] private Room1PuzzleManager puzzleManager;
    [SerializeField] private Material offlineMaterial;
    [SerializeField] private Material onlineMaterial;
    [SerializeField] private Animator powerSwitchAnimator;
    [SerializeField] private AudioSource powerSwitchAudio;

    [SerializeField] private string switchID;
    [SerializeField] private bool isActive;

    public void Interact()
    {
        if (!isActive)
        {
            isActive = true;

            // Play the Power Switch animation turning ON
            powerSwitchAnimator.SetBool("isOn", true);

            // Play 2D Sound
            powerSwitchAudio.Play();

            // Change the Power Switch display color to Green
            transform.Find("display").GetComponent<MeshRenderer>().material = onlineMaterial;

            puzzleManager.concatenateString(switchID);
        }
    }

    // Method to reset the Power Switch conditions
    public void ResetConditions()
    {
        StartCoroutine(delayTimer());
    }

    // Coroutine to provide a brief delay before turning all Power Switches to the OFF position
    private IEnumerator delayTimer()
    {
        yield return new WaitForSeconds(.5f);

        // Play the Power Switch animation turning OFF
        powerSwitchAnimator.SetBool("isOn", false);
        
        // Change the Power Switch display color to Red
        transform.Find("display").GetComponent<MeshRenderer>().material = offlineMaterial;

        isActive = false;
    }
}
