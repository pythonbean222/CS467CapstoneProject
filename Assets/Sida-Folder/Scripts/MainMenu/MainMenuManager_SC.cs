using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager_SC : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button CreditsButton;

    // Method that loads the Lobby Level ("LobbyScene")
    public void StartGame()
    {
        
        SceneManager.LoadScene("LobbyScene");

        if (CreditsButton != null)
            CreditsButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Credits");
    }

    // Method that quits the application
    public void QuitGame()
    {
        Application.Quit();
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
