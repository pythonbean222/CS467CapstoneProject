using UnityEngine;

public class SceneLoader : MonoBehaviour
{
 [SerializeField] private SceneFlowManager SceneFlowManager;
 [SerializeField] public string sceneToLoad;

/*     public void OnClick()
    {
        SceneFlowManager.LoadScene(sceneToLoad);
        Debug.Log("SceneLoader: OnClick called, loading scene: " + sceneToLoad);
    } */
}
