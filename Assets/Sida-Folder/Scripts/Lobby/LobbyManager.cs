using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public void TutorialRoom()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Room1()
    {
        SceneManager.LoadScene("Room1Scene");
    }

    public void Room2()
    {
        SceneManager.LoadScene("Room2Scene");
    }

    public void Room3()
    {
        SceneManager.LoadScene("Room3Scene");
    }
}
