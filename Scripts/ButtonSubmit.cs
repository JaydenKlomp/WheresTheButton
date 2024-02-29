using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using UnityEngine.ProBuilder.Shapes;
using Unity.VisualScripting;

public class ButtonSubmit : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField inputField;
    public string inputText;

    public ButtonPressStart buttonpressstart;
    public GameObject warningPanel;
    public TMP_Text tmpPlaceHolder;
    public TextMeshPro txtPlaceHolder;
    public TMP_Text Error01;

    MySqlConnection con;
    string server = "10.11.16.70";
    string uid = "Floris";
    string password = "BasilBoys2023!";
    string database = "whereismybutton";

    List<string> playerNames = new List<string>();
    bool isPlayerFound = false;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PressButton);
    }

    public void databaseConnection()
    {
        string conString = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + database;
        con = new MySqlConnection(conString);
        con.Open();
    }

    public void getPlayerNames()
    {
        databaseConnection();

        string collectTables = "SELECT name FROM `level_1` WHERE 1";
        MySqlCommand cmd = new MySqlCommand(collectTables, con);
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string playerName = reader.GetString(0);
            playerNames.Add(playerName);
        }

        reader.Close();

    }

    private void PressButton()
    {
        
         inputText = inputField.text;

         getPlayerNames();



        foreach (string playerName in playerNames)
        {
            if (playerName == inputText)
            {
                isPlayerFound = true;
                break;
            }
        }

        if (isPlayerFound)
        {
            // Laat message zien dat de speler al bestaat
            Debug.Log("Naam bestaat al");

            Error01.text = "Name exists";
            warningPanel.SetActive(true);

            isPlayerFound = false;
        }
        else
        {
            if (inputText.Length < 15)
            {
                if (!string.IsNullOrEmpty(inputText))
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    panel.SetActive(false);

                    PlayerPrefs.SetString("inputText", inputText);
                    Debug.Log(inputText);
                    buttonpressstart.PressButton();
                } else
                {
                    // Laat message zien dat de spelernaam leeg is
                    Debug.Log("Naam is leeg");
                    Error01.text = "Name is empty";

                    warningPanel.SetActive(true);


                }

            } else
            {
                // Laat message zien dat de speler een naam heeft die langer is dan 15 karakters.;
                Debug.Log("Naam is langer dan 15 tekens");

                Error01.text = "Too long";

                warningPanel.SetActive(true);
            }
        }
    }
}