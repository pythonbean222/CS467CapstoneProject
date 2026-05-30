using UnityEngine;

// Script adapted from Game Dev Guide on Youtube
// "Designing A Responsive Tooltip System in Unity" 
// https://www.youtube.com/watch?v=HXFoUGw7eKk

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public Tooltip tooltip;

    public void Awake() {
        // Set the current instance of the tooltip system and hide the tooltip on awake
        current = this;
        tooltip.gameObject.SetActive(false);
    }

    public static void Show(string text) {
        // Set the text of the tooltip and show it
        current.tooltip.textField.text = text;
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide() {
        // Hide the tooltip
        current.tooltip.gameObject.SetActive(false);
    }
}
