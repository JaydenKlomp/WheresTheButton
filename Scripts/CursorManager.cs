using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool showCursorOnStart = false;

    private void Start()
    {
        if (showCursorOnStart)
            ShowCursor();
        else
            HideCursor();
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
