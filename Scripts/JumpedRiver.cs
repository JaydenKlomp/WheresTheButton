using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedRiver : MonoBehaviour
{
    public Animator Animator;
    public AudioSource AudioSource;
    private int AmountWalked;
    public string FirstState;
    public string SecondState;

    private void OnTriggerEnter(Collider other)
    {
        AmountWalked++;

        if (AmountWalked == 1)
        {
            Animator.SetBool(FirstState, true);
            AudioSource.Play();
            StartCoroutine(CheckAudioFinished());
        }
    }

    private IEnumerator CheckAudioFinished()
    {
        yield return new WaitWhile(() => AudioSource.isPlaying);
        Animator.SetBool(SecondState, true);
    }
}