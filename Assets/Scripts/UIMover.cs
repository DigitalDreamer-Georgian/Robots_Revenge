using UnityEngine;
using UnityEngine.UI;

public class UIMover : MonoBehaviour
{
    public RectTransform tipPanel;
    public Toggle moveToggle;
    public float moveDistance = 200f;

    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = tipPanel.anchoredPosition;
        moveToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isChecked)
    {
        if (isChecked)
        {
            MovePanelLeft();
        }
        else
        {
            MovePanelBack();
        }
    }

    void MovePanelLeft()
    {
        tipPanel.anchoredPosition = new Vector2(originalPosition.x - moveDistance, originalPosition.y);
    }

    void MovePanelBack()
    {
        tipPanel.anchoredPosition = originalPosition;
    }
}

