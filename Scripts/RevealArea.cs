using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealArea : MonoBehaviour
{
    public GameObject Sun;
    public Animator animatorPassage;

    private void Update()
    {   
        if (Sun.transform.rotation.eulerAngles.x < 20)
        {
            animatorPassage.SetBool("AreaRevealed", true);
        }
    }
}
