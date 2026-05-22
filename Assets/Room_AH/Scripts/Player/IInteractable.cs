// Citation for setting up an Interface in Unity
// Date: 1 May, 2026
// Adapted from Unity Learn
// Source URL: https://learn.unity.com/tutorial/interfaces

public interface IInteractable {
    void Interact();

    // Added by AH to get get the interaction text for tooltip system
    string GetInteractionText();
}
