using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public GameObject displayPanel;
    public List<string> dialogues = new List<string>();

    private int currentDialogueIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            NextDialogue();
        }
    }

    private void OnMouseDown()
    {
        StartDialogue();
    }

    private void StartDialogue()
    {
        displayPanel.SetActive(true);
        currentDialogueIndex = 0;
        DisplayCurrentDialogue();
    }

    private void NextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Count)
        {
            DisplayCurrentDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayCurrentDialogue()
    {
        displayText.text = dialogues[currentDialogueIndex];
    }

    private void EndDialogue()
    {
        displayPanel.SetActive(false);
    }
}