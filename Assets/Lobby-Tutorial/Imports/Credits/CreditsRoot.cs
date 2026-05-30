// Used in Credit Scene for text
// Escape Room Game Credits

// Citation
// Adapted from YouTube Creator: Root Games
// Source URL: https://www.youtube.com/watch?v=Wz3nbQPYwss&list=PLu_54TAaZ5RdRMHoDREFWVurtkEIKPMQP&index=10

using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 2f;
    public float duration = 10f; // Stops the text at specific time

    private float timer;

    void Update()
    {
        if (timer < duration)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            timer += Time.deltaTime;
        }
    }
}