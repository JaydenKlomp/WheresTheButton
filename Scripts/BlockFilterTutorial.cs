using System;
using UnityEngine;

public class BlockFilterTutorial : MonoBehaviour
{
    public string RequiredObjectName;
    public event Action<bool> KeyEnteredChanged;

    public bool keyEntered;

    public bool KeyEntered
    {
        get { return keyEntered; }
        set
        {
            if (keyEntered != value)
            {
                keyEntered = value;
                KeyEnteredChanged?.Invoke(keyEntered);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == RequiredObjectName)
        {
            KeyEntered = true;
        }
        else
        {
            KeyEntered = false;
        }
    }
}