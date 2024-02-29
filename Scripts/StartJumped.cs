using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJumped : MonoBehaviour
{
public Animator animator;
    public AudioSource audioSource;

    private void Update()
    {
        if(audioSource.isPlaying == false)
        {
            animator.SetBool("IsFinishedPlayingFirst", true);
        }
    }
}
