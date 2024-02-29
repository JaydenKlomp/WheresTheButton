using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorTrap : MonoBehaviour
{

    public Animator TrapDoorAnimation;
    public AudioSource DoorSound;
    public AudioSource Ambiance;

    private void OnTriggerEnter(Collider other)
    {
        TrapDoorAnimation.SetBool("WalkedOver", true);
        DoorSound.Play();
        Ambiance.Stop();
    }
}