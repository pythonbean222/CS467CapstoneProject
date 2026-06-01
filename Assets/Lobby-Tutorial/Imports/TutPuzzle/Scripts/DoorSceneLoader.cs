// Used in: Tutorial Scene on DoorTrigger game object
// Event method that returns player to the Lobby scene on trigger

// Citation for Load Scene
// Adapted from Unity Documentation
// Source URL: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html

using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneLoader : MonoBehaviour
{
    [SerializeField] private SceneFlowManager sceneFlowManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (sceneFlowManager == null)
        {
            sceneFlowManager = SceneFlowManager.Instance;
        }

        if (other.CompareTag("Player"))
        {
            sceneFlowManager.LoadScene("LobbyScene");
        }
    }
}