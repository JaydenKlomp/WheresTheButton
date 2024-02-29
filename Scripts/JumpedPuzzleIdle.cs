using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedPuzzleIdle : MonoBehaviour
{
    public Animator Animator;
    public AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        Animator.SetBool("JumpedIdleRiver", true);
        AudioSource.Play();
    }
}
