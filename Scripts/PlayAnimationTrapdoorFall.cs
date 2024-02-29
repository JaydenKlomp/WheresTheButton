using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationTrapdoorFall : MonoBehaviour
{
public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("JumpedFallsInTheLuikje", true);
    }
}
