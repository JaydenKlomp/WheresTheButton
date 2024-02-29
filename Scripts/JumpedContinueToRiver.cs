using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpedContinueToRiver : MonoBehaviour
{
    public Animator Animator;


    private void OnTriggerEnter(Collider other)
    {
        Animator.SetBool("JumpedToRiver", true);
    }
}
