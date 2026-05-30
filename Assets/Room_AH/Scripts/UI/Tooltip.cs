using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Script adapted from Game Dev Guide on Youtube
// "Designing A Responsive Tooltip System in Unity" 
// https://www.youtube.com/watch?v=HXFoUGw7eKk

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    // References to the text field and layout element of the tooltip
    public TextMeshProUGUI textField;
    public LayoutElement layoutElement;
    public int characterWrapLimit;

    private void Update() {
        // If the text field is empty, hide the tooltip
        int textLength = textField.text.Length;
        
        // Enable the layout element if the text length exceeds the character wrap limit, otherwise disable it
        layoutElement.enabled = (textLength > characterWrapLimit) ? true : false;
    }

}
