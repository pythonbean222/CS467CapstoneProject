using UnityEngine;
using UnityEngine.SceneManagement;

// manages the flow of scenes in the game; uses RoomHandler.cs from Lobby scene for variable storage of scene names
public class SceneFlowManager : MonoBehaviour
{
    public static SceneFlowManager Instance { get; private set; }

    [SerializeField] public bool SceneCompleted = false;
    [SerializeField] private int sceneCounter;
    [Header("SceneOne")]
    public string SceneOne;

     [Header("SceneTwo")]
    public string SceneTwo;

     [Header("FinalScene")]
    public string FinalScene;

    private string currentScene;

     // Update is called once per frame
    void Update()
    {
        if (SceneCompleted)
        {
            if (currentScene == SceneOne && sceneCounter < 2)
            {
                SceneManager.LoadScene(SceneTwo);
                updatesceneCounter();
                SceneCompleted = false; // Reset the flag to prevent multiple loads
            }
            else if (currentScene == SceneTwo)
            {
                SceneManager.LoadScene(SceneOne);
                updatesceneCounter();
                SceneCompleted = false; // Reset the flag to prevent multiple loads
            }

            else
            {
                SceneManager.LoadScene(FinalScene);
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

    private void updatesceneCounter()
    {
        sceneCounter++;
    }

    public void SetFirstScene(string sceneName)
    {
        SceneOne = sceneName;
    }

    public void SetSecondScene(string sceneName)
    {
        SceneTwo = sceneName;
    }

    public void SetFinalScene(string sceneName)
    {
        FinalScene = sceneName;
    }
}
