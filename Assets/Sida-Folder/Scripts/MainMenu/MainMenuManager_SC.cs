using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager_SC : MonoBehaviour
{
    // Method that loads the Lobby Level ("LobbyScene")
    public void StartGame()
    {
        SceneManager.LoadScene("LobbyScene");
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
