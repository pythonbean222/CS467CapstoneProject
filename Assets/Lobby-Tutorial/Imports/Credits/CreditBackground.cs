// Used in Credit Scene for background
// Escape Room Game Credits

// Citation
// Adapted from YouTube Creator: Root Games
// Source URL: https://www.youtube.com/watch?v=Wz3nbQPYwss&list=PLu_54TAaZ5RdRMHoDREFWVurtkEIKPMQP&index=10


using UnityEngine;

public class Credits : MonoBehaviour
{
    public float speed;

    [SerializeField] private Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}

