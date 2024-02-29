using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]

public class ButtonClickForest : MonoBehaviour
{
    public Renderer rendererComponent;
    public Color targetColor;
    private Color originalColor;

    private Animator animator;

    public float pauseTime = 0.05f;
    private AudioSource audioSource;
    private Coroutine audioCoroutine;

    public GameObject boulder;
    private Animator RockNRoll;

    private AudioSource rockRollSound;
    public GameObject rockSoundHolder;

    public GameObject mainCam;
    public GameObject secondCam;
    public string imageTag = "Crosshair";


    public float maxClickDistance = 3f;

    private void Start()
    {
        originalColor = rendererComponent.material.color;

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Get the Animator component of the door objects
        RockNRoll = boulder.GetComponent<Animator>();

        secondCam.GetComponent<Camera>().enabled = false;
    }

    private IEnumerator PlayAudio(float duration)
    {
        audioSource.Play();
        yield return new WaitForSeconds(duration);
        audioSource.Pause();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");

        animator.SetBool("isPressed", true);

        audioCoroutine = StartCoroutine(PlayAudio(pauseTime));

        rockSoundHolder = GameObject.Find("BoulderSoundHolder");
        rockRollSound = rockSoundHolder.GetComponent<AudioSource>();
    }

    void OnMouseUp()
    {
        Debug.Log("unClicked");

        animator.SetBool("isPressed", false);
        rockRollSound.Play();

        StopCoroutine(audioCoroutine);
        audioSource.Play();

        ChangeColor();

        if (RockNRoll.GetBool("isOpen") == false)
        {
            RockNRoll.SetBool("isOpen", true);
        }
        else
        {
            RockNRoll.SetBool("isOpen", false);
        }

        mainCam.GetComponent<Camera>().enabled = false;
        secondCam.GetComponent<Camera>().enabled = true;
        DisableUIImage();



        // Start the cutscene coroutine
        StartCoroutine(PlayCutscene());
    }

    public void ChangeColor()
    {
        if (rendererComponent.material.color == originalColor)
        {
            rendererComponent.material.color = targetColor;
        }
        else
        {
            rendererComponent.material.color = originalColor;
        }
    }

    private IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(5f);

        mainCam.GetComponent<Camera>().enabled = true;
        secondCam.GetComponent<Camera>().enabled = false;
        EnableUIImage();

    }

    private void DisableUIImage()
    {
        GameObject[] imageObjects = GameObject.FindGameObjectsWithTag(imageTag);
        foreach (GameObject imageObject in imageObjects)
        {
            Image imageComponent = imageObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.enabled = false; // Disable the image component
            }
        }
    }

    private void EnableUIImage()
    {
        GameObject[] imageObjects = GameObject.FindGameObjectsWithTag(imageTag);
        foreach (GameObject imageObject in imageObjects)
        {
            Image imageComponent = imageObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.enabled = true; // Disable the image component
            }
        }
    }


}