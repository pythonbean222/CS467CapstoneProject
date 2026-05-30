using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager_SC : MonoBehaviour
{
    // Method that loads the Lobby Level ("LobbyScene")
    public void StartGame()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void LoadCredits()
    {
        Debug.Log("load credits pressed");
        SceneManager.LoadScene("Credits");
    }

    // Method that quits the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
