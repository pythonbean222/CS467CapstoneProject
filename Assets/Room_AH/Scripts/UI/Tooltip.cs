using UnityEngine;
using UnityEngine.UI;
using TMPro;

//https://www.youtube.com/watch?v=HXFoUGw7eKk

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public LayoutElement layoutElement;
    public int characterWrapLimit;

    private void Update()
    {
        int textLength = textField.text.Length;

        layoutElement.enabled = (textLength > characterWrapLimit) ? true : false;
    }

}
