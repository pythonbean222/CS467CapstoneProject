using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// manages the flow of scenes in the game; uses RoomHandler.cs from Lobby scene for variable storage of scene names
public class SceneFlowManager : MonoBehaviour
{
    public static SceneFlowManager Instance { get; private set; }

    [SerializeField] public bool SceneCompleted = false;
    // [SerializeField] private int sceneCounter;
    [Header("SceneOne")]
    public string SceneOne;

     [Header("SceneTwo")]
    public string SceneTwo;

     [Header("FinalScene")]
    public string FinalScene;

    [SerializeField] public string currentScene;

    [Header("Scene Completed")]
    private bool SceneOneCompleted = false;
    private bool SceneTwoCompleted = false;

     // Update is called once per frame
    void Update()
    {
        if (SceneCompleted)
        {
            Debug.Log("Scene completed, loading next scene...");
            if (currentScene == SceneOne && SceneTwoCompleted == false)
            {
                Debug.Log("Current Scene: " + currentScene);
                currentScene = SceneTwo;
                SceneManager.LoadScene(SceneTwo);
                //updatesceneCounter();
                SceneOneCompleted = true;
                Debug.Log("Current Scene: " + currentScene);
                SceneCompleted = false; // Reset the flag to prevent multiple loads
            }
            else if (currentScene == SceneTwo && SceneOneCompleted == false)
            {
                Debug.Log("Current Scene: " + currentScene);
                currentScene = SceneOne;
                SceneManager.LoadScene(SceneOne);
                //updatesceneCounter();
                SceneTwoCompleted = true;
                Debug.Log("Current Scene: " + currentScene);
                SceneCompleted = false; // Reset the flag to prevent multiple loads
            }

            else
            {
                Debug.Log("Current Scene: " + currentScene);
                Debug.Log("All scenes completed, loading final scene...");
                SceneManager.LoadScene(FinalScene);
                SceneCompleted = false; // Reset the flag to prevent multiple loads
                SceneOneCompleted = false;
                SceneTwoCompleted = false;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        currentScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }
    // Awake method
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Ensure the SceneFlowManager persists across scene loads
        DontDestroyOnLoad(gameObject);
    }

/*     private void updatesceneCounter()
    {
        sceneCounter++;
    } */


}
