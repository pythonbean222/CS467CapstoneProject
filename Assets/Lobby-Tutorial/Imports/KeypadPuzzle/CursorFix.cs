using UnityEngine;

public class CursorFix : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}