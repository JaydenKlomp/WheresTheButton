using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFilter : MonoBehaviour
{
    public event Action<bool> KeyEnteredChanged;
    public KeyCalculator keyCalculator;
    public string RequiredObjectName;
    public bool keyEntered = false;

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
            keyCalculator.CheckBlockFilter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == RequiredObjectName)
        {
            KeyEntered = false;
            keyCalculator.CheckBlockFilter();
        }
    }
}