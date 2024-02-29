using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public string Player;


    private void Awake()
    {
        
        SceneManager.LoadScene(Player, LoadSceneMode.Additive);
    }
}
