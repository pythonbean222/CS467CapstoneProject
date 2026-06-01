using UnityEngine;

// Singleton class to manage audio for the keypad puzzle
// allows other scripts to play audio clips without needing a reference to the AudioSource component

public class AudioManager : MonoBehaviour
{   
    public static AudioManager Instance;
    [SerializeField] private AudioSource puzzleAudio;

    private void Awake() {
        // Ensure only one instance of AudioManager exists
        Instance = this;
    }

    public void PlaySound(AudioClip clip) {
        // Check if the clip is null before trying to play it
        if (clip == null) {
            return;
        }

        puzzleAudio.PlayOneShot(clip);
    }
}
