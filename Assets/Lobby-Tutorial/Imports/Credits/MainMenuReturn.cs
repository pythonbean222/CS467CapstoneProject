using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuReturn : MonoBehaviour
{
    // Main Menu Button in Credits Scene to return to main menu
    public void MainMenu_Return()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
