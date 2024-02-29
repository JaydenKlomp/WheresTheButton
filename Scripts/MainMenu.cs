using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PauseMenuManager pauseMenuManager;
    private void Start()
    {
        try
        {
            pauseMenuManager = GameObject.Find("Pause").GetComponent<PauseMenuManager>();
        }
        catch
        {
            Debug.LogWarning("Nothing to reset in Main Menu");
        }
    }
    public void playTutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void playGame()
    {
        SceneManager.LoadScene(2);
    }
    public void quitGame()
    {
        try
        {
            pauseMenuManager = GameObject.Find("Pause").GetComponent<PauseMenuManager>();
        }
        catch
        {
            Debug.LogWarning("Nothing to reset in Main Menu");
        }

        if (PlayerPrefs.GetString("isPlayerFinished") == "false")
        {
            pauseMenuManager.ResetGame();
        }
        if (PlayerPrefs.GetString("isPlayerFinished") != "")
        {
            Debug.Log(PlayerPrefs.GetString("isPlayerFinished"));
        }
        Debug.Log("quitted");
        Application.Quit();

    }
}