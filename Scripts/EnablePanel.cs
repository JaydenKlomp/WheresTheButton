using UnityEngine;
using UnityEngine.UI;

public class EnablePanel : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to enable

    public Material buttonMat;
    public Color originalColor;
    public Color newColor;
    public ButtonSubmit buttonSubmit;

    private void OnMouseDown()
    {
            PressButton();  
    }

    private void PressButton()
    {

                buttonMat.color = newColor;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                panel.SetActive(true);

    }

    private void OnDisable()
    {
        // Reset button material color
        buttonMat.color = originalColor;
    }
}





