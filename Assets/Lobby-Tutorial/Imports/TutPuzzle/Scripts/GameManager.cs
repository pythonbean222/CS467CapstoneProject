// Used in Sliding Puzzle - TutorialPuzzle Scene
// On complete, changes progress in GameProgressLobbyTutorial.cs to continue dialouge and return player to TutorialScene
// Citation for Sliding Game Puzzle
// Date: 1 May 2025
// Adapted from YouTube Creator: Firnox
// Source URL: https://www.youtube.com/watch?v=IgBjJ-bexeo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private UnityEngine.UI.Button continueButton;
    public AudioClip PuzzleCorrect;
    AudioSource audioSource;

    private string[] tutorialMessages =
    {
        "Click the tiles to move them",
        "Look for patterns that align correctly when pieces are in the right place.",
        "Complete the image to reveal the code."
    };

    private int currentMessage = 0;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    private bool shuffling = false;

    // Create game setup in size by size pieces
    private void CreateGamePieces(float gapThickness)
    {
        // Width of each puzzle piece
        float width = 1 / (float)size;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                // Centering each piece to its corresponding spot + assigning name to each piece
                piece.localPosition = new Vector3(
                    -1 + (2 * width * col) + width,
                    +1 - (2 * width * row) - width,
                    0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                // Creating the last row right piece to be empty
                if ((row == size -1) && (col == size -1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                } 
                else
                {
                    // map UV cordinates
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    // UV coord order: (0, 1), (1, 1), (0, 0), (1, 0)
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
                    
                    mesh.uv = uv; // aslign to mesh
                }
            }
        }
    }



    // Start called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        audioSource = GetComponent<AudioSource>();
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f); // Passes the parameter of the thickness of the tiles
        Shuffle();
        if (tutorialText != null)
            tutorialText.text = tutorialMessages[currentMessage];
        if (continueButton != null)
            continueButton.onClick.AddListener(NextMessage);
    }

    // Update once per frame 
    void Update()
    {
        // Check for completion 
        if (!shuffling && CheckCompletion())
        {
            shuffling = true;
            StartCoroutine(PuzzleSolved());
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == hit.transform)
                    {
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }
                    }
                }
            }
        }
    }

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            // swap in game state
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            // swap in their transform 
            (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));
            // Update empty location
            emptyLocation = i;
            return true;
        }
        return false;
    }

    private bool CheckCompletion()
    // Checks fr completion by comparing the current order of the pieces in the list against their original correct order
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }

    private void Shuffle()
    // Shuffles the puzzle pieces
    {
        int count = 0;
        int last = 0;
        while (count < (size * size * size))
        {
            int rnd = Random.Range(0, size * size);
            if (rnd == last) {continue;}
            last = emptyLocation;
            if (SwapIfValid(rnd, -size, size))
            {
                count++;
            }
            else if (SwapIfValid(rnd, +size, size))
            {
                count++;
            }
            else if (SwapIfValid(rnd, -1, 0))
            {
                count++;
            }
            else if (SwapIfValid(rnd, +1, -1))
            {
                count++;
            }
        }
    }

    private IEnumerator PuzzleSolved()
    // Once the puzzle is solved, the missing puzzle piece is filled in with the whole code
    // Code is left on display for 5 seconds and Tutorial scene is reloaded
    {
        pieces[emptyLocation].gameObject.SetActive(true);
        audioSource.PlayOneShot(PuzzleCorrect);
        tutorialText.text = "You got it! Keep this code in mind...";
        yield return new WaitForSeconds(5f);

        // Changing progress in GameProgressLobbyTutorial.cs to continue dialouge
        GameProgressLobbyTutorial.puzzleCompleted = true;
        SceneManager.LoadScene("TutorialScene");
    }

    private void NextMessage()
    {
        currentMessage++;
        if (currentMessage < tutorialMessages.Length)
        {
            tutorialText.text = tutorialMessages[currentMessage];
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
    }
}
