using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedIdleCave : MonoBehaviour
{
    public Animator Animator;
    public AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        Animator.SetBool("JumpedIdleInTunnel", true);
        AudioSource.Play();
    }
}
