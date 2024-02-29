using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressStart : MonoBehaviour
{
    public GameObject Sun;

    public ButtonPressStart ClickScript;

    public Transform player;
    public Animator ButtonRockDown;
    public Animator animatorSun;

    public AudioSource Rumble;
    public AudioSource ButtonClick;
    public ButtonSubmit buttonSubmit;

    public Material buttonMat;
    public Color originalColor;
    public Color newColor;

    public float pressRadius = 2f;

    public void OnMouseDown()
    {

    }

    public void PressButton()
    {
            ButtonClick.Play();
            buttonMat.color = newColor;
            Quaternion newRotation = Quaternion.Euler(10, 91, 0);
            animatorSun.SetBool("ButtonPressed", true);
            ButtonRockDown.SetBool("AreaRevealed", true);
            Rumble.Play();
    }

    public void OnDisable()
    {
        buttonMat.color = originalColor;
    }
}
