using UnityEngine;
using UnityEngine.SceneManagement;

// manages the flow of scenes in the game; uses RoomHandler.cs from Lobby scene for variable storage of scene names
public class SceneFlowManager : MonoBehaviour
{

    [SerializeField] public bool puzzleCompleted = false;
    [SerializeField] private int sceneCounter;
    [Header("SceneOne")]
    public string SceneOne;

     [Header("SceneTwo")]
    public string SceneTwo;

     [Header("FinalScene")]
    public string FinalScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleCompleted)
        {
            sceneCounter++;
            if (sceneCounter < 2)
            {
                SceneManager.LoadScene(SceneTwo);
                puzzleCompleted = false; // Reset the flag to prevent multiple loads
            }

            else
            {
                SceneManager.LoadScene(FinalScene);
                puzzleCompleted = false; // Reset the flag to prevent multiple loads
            }

        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    // Awake method
    private void Awake()
    {
        // Ensure the SceneFlowManager persists across scene loads
        DontDestroyOnLoad(gameObject);
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
