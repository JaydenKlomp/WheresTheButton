using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public CursorManager cursorManager;

    private string con;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_CommandOne;
    private MySqlCommand MS_CommandTwo;
    private MySqlCommand MS_CommandThree;
    private MySqlCommand MS_CommandFour;

    public string kaas;

    private bool isPaused = false;
    private int currentSceneBuildIndex;

    private void Start()
    {
        ResumeGame();
        cursorManager.ShowCursor();
        currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void databaseConnection()
    {
        con = "Server = 10.11.16.70 ; Database = whereismybutton ; User = Floris; Password = BasilBoys2023!;";
        MS_Connection = new MySqlConnection(con);

        MS_Connection.Open();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        cursorManager.ShowCursor(); // Show the cursor when the game is paused
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting the time scale to 1
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        cursorManager.HideCursor(); // Hide the cursor when the game resumes

        isPaused = false;
    }

    public void ResetGame()
    {
        databaseConnection();
        SceneManager.LoadScene(0);

        string deleteLevelOne = "DELETE FROM `level_1` WHERE name = '" + PlayerPrefs.GetString("inputText") + "';";
        Debug.Log(deleteLevelOne);
        MS_CommandOne  = new MySqlCommand(deleteLevelOne, MS_Connection);
        MS_CommandOne.ExecuteNonQuery();

        string deleteLevelTwo = "DELETE FROM `level_2` WHERE name = '" + PlayerPrefs.GetString("inputText") + "';";
        MS_CommandTwo  = new MySqlCommand(deleteLevelTwo, MS_Connection);
        MS_CommandTwo.ExecuteNonQuery();

        string deleteLevelThree = "DELETE FROM `level_3` WHERE name = '" + PlayerPrefs.GetString("inputText") + "';";
        MS_CommandThree  = new MySqlCommand(deleteLevelThree, MS_Connection);
        MS_CommandThree.ExecuteNonQuery();

        string deleteAllLevels = "DELETE FROM `all_levels` WHERE name = '" + PlayerPrefs.GetString("inputText") + "';";
        MS_CommandFour  = new MySqlCommand(deleteAllLevels, MS_Connection);
        MS_CommandFour.ExecuteNonQuery();
    }
}