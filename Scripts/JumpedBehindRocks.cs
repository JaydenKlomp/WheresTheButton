using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedBehindRocks : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;

    private void OnTriggerEnter(Collider test)
    {
        sound.Play();
        animator.SetBool("JumpedFinishedSpeakingLuikje", true);
    }
}
