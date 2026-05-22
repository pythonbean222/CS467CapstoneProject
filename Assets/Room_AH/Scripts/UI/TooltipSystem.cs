using UnityEngine;

// https://www.youtube.com/watch?v=HXFoUGw7eKk

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public Tooltip tooltip;

    public void Awake()
    {
        current = this;
        tooltip.gameObject.SetActive(false);
    }

    public static void Show(string text)
    {
        current.tooltip.textField.text = text;
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
