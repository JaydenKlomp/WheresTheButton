using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        // Delete the PlayerPrefs data when the game starts
        PlayerPrefs.DeleteAll();
    }

    private void OnDestroy()
    {
        // Save the PlayerPrefs data before changing scenes
        PlayerPrefs.Save();
    }
}