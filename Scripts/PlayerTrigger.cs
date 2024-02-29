using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MySql.Data.MySqlClient;


public class PlayerTrigger : MonoBehaviour
{
    public string playerUserName;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_CommandOne;
    private MySqlCommand MS_CommandTwo;
    private Text scoreText;
    private Text timeText;
    private Text lvlOneTimeText;
    private Text lvlTwoTimeText;
    private Text lvlThreeTimeText;

    string server = "10.11.16.70";
    string uid = "Floris";
    string password = "BasilBoys2023!";
    string database = "whereismybutton";

    private bool timingStarted = false;
    private float gameTimer = 0f;
    private float lvlOneTime = 0f;
    private float lvlTwoTime = 0f;
    private float lvlThreeTime = 0f;
    private int playerScore = 0;

    public GameObject coinSoundHolder;

    private AudioSource audioSourceCoin;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        timeText = GameObject.Find("TotalTimeText").GetComponent<Text>();
        lvlOneTimeText = GameObject.Find("LvlOneTimeText").GetComponent<Text>();
        lvlTwoTimeText = GameObject.Find("LvlTwoTimeText").GetComponent<Text>();
        lvlThreeTimeText = GameObject.Find("LvlThreeTimeText").GetComponent<Text>();

        PlayerPrefs.SetString("isPlayerFinished", "false");

        scoreText.text = "Coins: " + playerScore.ToString();

        lvlOneTimeText.text = "";
        lvlTwoTimeText.text = "";
        lvlThreeTimeText.text = "";

        if (PlayerPrefs.GetFloat("gameTimer") != 0f)
        {
            gameTimer = PlayerPrefs.GetFloat("gameTimer");
            UpdateTimeText(gameTimer, timeText, "Time");
        }
        if (PlayerPrefs.GetFloat("lvlOneTime") != 0f)
        {
            lvlOneTime = PlayerPrefs.GetFloat("lvlOneTime");
            UpdateTimeText(lvlOneTime, lvlOneTimeText, "Lvl One");
        }
        if (PlayerPrefs.GetFloat("lvlTwoTime") != 0f)
        {
            lvlTwoTime = PlayerPrefs.GetFloat("lvlTwoTime");
            UpdateTimeText(lvlTwoTime, lvlTwoTimeText, "Lvl Two");

        }
        if (PlayerPrefs.GetFloat("lvlThreeTime") != 0f)
        {
            lvlThreeTime = PlayerPrefs.GetFloat("lvlThreeTime");
            UpdateTimeText(lvlThreeTime, lvlThreeTimeText, "Lvl Three");
        }
        if (PlayerPrefs.GetInt("playerScore") != 0)
        {
            playerScore = PlayerPrefs.GetInt("playerScore");
        }
        if (PlayerPrefs.GetString("inputText") != "0")
        {
            playerUserName = PlayerPrefs.GetString("inputText");
        }

        scoreText.text = "Coins: " + playerScore.ToString();
    }

    public void databaseConnection()
    {
        string con = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + database;
        MS_Connection = new MySqlConnection(con);

        MS_Connection.Open();
    }

    public int getLastIdFromTableLvlOne()
    {
        int lastId = 0;
        databaseConnection();

        string CollectTables = "SELECT id FROM level_1 ORDER BY id DESC LIMIT 1";
        MySqlCommand cmd = new MySqlCommand(CollectTables, MS_Connection);
        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lastId = reader.GetInt32("id");
            }
            reader.Close();
        }
        catch (System.Exception)
        {

        }

        return lastId + 1;
    }

    public int getLastIdFromTableLvlTwo()
    {
        int lastId = 0;
        databaseConnection();

        string CollectTables = "SELECT id FROM level_2 ORDER BY id DESC LIMIT 1";
        MySqlCommand cmd = new MySqlCommand(CollectTables, MS_Connection);
        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lastId = reader.GetInt32("id");
            }
            reader.Close();
        }
        catch (System.Exception)
        {

        }

        return lastId + 1;
    }

    public int getLastIdFromTableLvlThree()
    {
        int lastId = 0;
        databaseConnection();

        string CollectTables = "SELECT id FROM level_3 ORDER BY id DESC LIMIT 1";
        MySqlCommand cmd = new MySqlCommand(CollectTables, MS_Connection);
        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lastId = reader.GetInt32("id");
            }
            reader.Close();
        }
        catch (System.Exception)
        {

        }

        return lastId + 1;
    }

    public int getLastIdFromTableAllLevels()
    {
        int lastId = 0;
        databaseConnection();

        string CollectTables = "SELECT id FROM all_levels ORDER BY id DESC LIMIT 1";
        MySqlCommand cmd = new MySqlCommand(CollectTables, MS_Connection);
        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                lastId = reader.GetInt32("id");
            }
            reader.Close();
        }
        catch (System.Exception)
        {

        }

        return lastId + 1;
    }

    private void Update()
    {
        if (timingStarted)
        {
            gameTimer += Time.deltaTime;
            PlayerPrefs.SetFloat("gameTimer", gameTimer);

            UpdateTimeText(gameTimer, timeText, "Time");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            Debug.Log("Coin collected");
            coinSoundHolder = GameObject.Find("coinSoundHolder");
            audioSourceCoin = coinSoundHolder.GetComponent<AudioSource>();

            Destroy(other.gameObject);
            AddPoint(1);
        }

        if (other.CompareTag("EnterTrigger") && !timingStarted)
        {
            Debug.Log("Entered");
            timingStarted = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ExitTrigger") && timingStarted)
        {
            Debug.Log("Exited");
            timingStarted = false;
            Destroy(other.gameObject);

            if (lvlOneTime == 0f)
            {
                playerUserName = PlayerPrefs.GetString("inputText");

                lvlOneTime = gameTimer;
                PlayerPrefs.SetFloat("lvlOneTime", lvlOneTime);

                UpdateTimeText(lvlOneTime, lvlOneTimeText, "Lvl One");

                databaseConnection();

                string queryCreateLevelOne = "INSERT INTO level_1(id, name, finish_time, score, level, time) VALUES (" + getLastIdFromTableLvlOne() + ",'" + playerUserName + "','0','0','1','0000-00-00 00:00:00')";
                string queryUpdateLevelOne = "UPDATE `level_1` SET `finish_time` = '" + lvlOneTime + "', `score` = '" + playerScore + "', `time` = NOW() WHERE name = '" + playerUserName + "';";

                MS_CommandOne = new MySqlCommand(queryCreateLevelOne, MS_Connection);
                MS_CommandOne.ExecuteNonQuery();

                MS_CommandTwo = new MySqlCommand(queryUpdateLevelOne, MS_Connection);
                MS_CommandTwo.ExecuteNonQuery();

                MS_Connection.Close();
            }
            else if (lvlTwoTime == 0f)
            {
                lvlTwoTime = gameTimer - lvlOneTime;
                PlayerPrefs.SetFloat("lvlTwoTime", lvlTwoTime);

                UpdateTimeText(lvlTwoTime, lvlTwoTimeText, "Lvl Two");

                databaseConnection();

                string queryCreateLevelTwo = "INSERT INTO `level_2`(`id`, `name`, `finish_time`, `score`, `level`, `time`) VALUES (" + getLastIdFromTableLvlTwo() + ",'" + playerUserName + "','0','0','2','0000-00-00 00:00:00')";
                string queryUpdateLevelTwo = "UPDATE `level_2` SET `finish_time`='" + lvlTwoTime + "',`score`='" + playerScore + "', `time` = NOW() WHERE name= '" + playerUserName + "'";

                MS_CommandOne = new MySqlCommand(queryCreateLevelTwo, MS_Connection);
                MS_CommandOne.ExecuteNonQuery();

                MS_CommandTwo = new MySqlCommand(queryUpdateLevelTwo, MS_Connection);
                MS_CommandTwo.ExecuteNonQuery();

                MS_Connection.Close();
            }
            else if (lvlThreeTime == 0f)
            {
                lvlThreeTime = gameTimer - lvlOneTime - lvlTwoTime;
                PlayerPrefs.SetFloat("lvlThreeTime", lvlThreeTime);


                UpdateTimeText(lvlThreeTime, lvlThreeTimeText, "Lvl Three");

                databaseConnection();

                string queryCreateLevelThree = "INSERT INTO `level_3`(`id`, `name`, `finish_time`, `score`, `level`, `time`) VALUES (" + getLastIdFromTableLvlThree() + ",'" + playerUserName + "','0','0','3','0000-00-00 00:00:00')";
                string queryUpdateLevelThree = "UPDATE `level_3` SET `finish_time`='" + lvlThreeTime + "',`score`='" + playerScore + "', `time` = NOW() WHERE name= '" + playerUserName + "'";

                string queryCreateAllLevels = "INSERT INTO `all_levels` (`id`, `name`, `finish_time`, `score`, `time`) VALUES (" + getLastIdFromTableAllLevels() + ",'" + playerUserName + "','0','0','0000-00-00 00:00:00')";
                string queryUpdateAllLevels = "UPDATE `all_levels` SET `finish_time`='" + gameTimer + "',`score`='" + playerScore + "', `time` = NOW() WHERE name= '" + playerUserName + "'";

                MS_CommandOne = new MySqlCommand(queryCreateLevelThree, MS_Connection);
                MS_CommandOne.ExecuteNonQuery();

                MS_CommandTwo = new MySqlCommand(queryUpdateLevelThree, MS_Connection);
                MS_CommandTwo.ExecuteNonQuery();

                MS_CommandTwo = new MySqlCommand(queryCreateAllLevels, MS_Connection);
                MS_CommandTwo.ExecuteNonQuery();

                MS_CommandTwo = new MySqlCommand(queryUpdateAllLevels, MS_Connection);
                MS_CommandTwo.ExecuteNonQuery();

                MS_Connection.Close();
            }
            if(lvlThreeTime != 0f)
            {
                PlayerPrefs.SetString("isPlayerFinished", "true");
            }

            Debug.Log("Level One Time: " + lvlOneTime);
            Debug.Log("Level Two Time: " + lvlTwoTime);
            Debug.Log("Level Three Time: " + lvlThreeTime);
        }
    }

    private void UpdateTimeText(float timer, Text textField, string text)
    {
        float totalSeconds = timer;
        int minutes = (int)(totalSeconds / 60) % 60;
        int seconds = (int)(totalSeconds % 60);
        int milliseconds = (int)((totalSeconds * 1000) % 1000);

        string timerString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        textField.text = text + ": " + timerString;
    }

    public void AddPoint(int points)
    {
        playerScore += points;
        PlayerPrefs.SetInt("playerScore", playerScore);
        scoreText.text = "Coins: " + playerScore.ToString();
        audioSourceCoin.Play();
    }
}