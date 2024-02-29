using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableJump : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement.jumpForce = 12;
    }
}
