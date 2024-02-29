using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class nextButtonClick : MonoBehaviour
{
    private Animator animator;
    public AudioClip buttonSound;
    public float pauseTime = 0.05f;

    private AudioSource audioSource;
    private Coroutine audioCoroutine;

    public float maxClickDistance = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buttonSound;

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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}