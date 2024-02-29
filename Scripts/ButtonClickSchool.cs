using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]

public class ButtonClickSchool : MonoBehaviour
{
    public Renderer rendererComponent;
    public Color targetColor;
    private Color originalColor;

    private Animator animator;
    public AudioClip buttonSound;
    public float pauseTime = 0.05f;

    private AudioSource audioSource;
    private Coroutine audioCoroutine;

    public GameObject leftDoor1;
    public GameObject rightDoor1;
    public GameObject leftDoor2;
    public GameObject rightDoor2;

    private Animator leftDoorAnimator1;
    private Animator rightDoorAnimator1;
    private Animator leftDoorAnimator2;
    private Animator rightDoorAnimator2;

    private GameObject mainCam;
    private GameObject secondCam;
    public string imageTag = "Crosshair";

    public float maxClickDistance = 3f;

    private void Start()
    {
        originalColor = rendererComponent.material.color;

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buttonSound;

        // Get the Animator component of the door objects
        leftDoorAnimator1 = leftDoor1.GetComponent<Animator>();
        rightDoorAnimator1 = rightDoor1.GetComponent<Animator>();
        leftDoorAnimator2 = leftDoor2.GetComponent<Animator>();
        rightDoorAnimator2 = rightDoor2.GetComponent<Animator>();

        mainCam = GameObject.FindWithTag("MainCamera");
        secondCam = GameObject.FindWithTag("SecondaryCamera");

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
    }

    void OnMouseUp()
    {
        Debug.Log("unClicked");

        animator.SetBool("isPressed", false);

        StopCoroutine(audioCoroutine);
        audioSource.Play();

        ChangeColor();

        if (leftDoorAnimator1.GetBool("isOpen") == false &&
            rightDoorAnimator1.GetBool("isOpen") == false)
        {
            leftDoorAnimator1.SetBool("isOpen", true);
            rightDoorAnimator1.SetBool("isOpen", true);
        }
        else
        {
            leftDoorAnimator1.SetBool("isOpen", false);
            rightDoorAnimator1.SetBool("isOpen", false);
        }

        if (leftDoorAnimator2.GetBool("isOpen") == false &&
            rightDoorAnimator2.GetBool("isOpen") == false)
        {
            leftDoorAnimator2.SetBool("isOpen", true);
            rightDoorAnimator2.SetBool("isOpen", true);
        }
        else
        {
            leftDoorAnimator2.SetBool("isOpen", false);
            rightDoorAnimator2.SetBool("isOpen", false);
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
        yield return new WaitForSeconds(1.5f);

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