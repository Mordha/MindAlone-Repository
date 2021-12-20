using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiialogueManager : MonoBehaviour
{
    public GameObject dialgueBox;

    public Text dialogueText;

    public Image avatarImage;

    public bool dialogueActive;

    public string[] dialogueLines;
    
    public int currentDialogueLine;
    private CharacterMovement _characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        dialogueActive = false;
        dialgueBox.SetActive(false);
        _characterMovement = FindObjectOfType<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogueLine++;


            if (currentDialogueLine >= dialogueLines.Length)
            {
                _characterMovement.isTalking = false;
                currentDialogueLine = 0;
                dialogueActive = false;
                dialgueBox.SetActive(false);
            }
            else
            {
                dialogueText.text = dialogueLines[currentDialogueLine];
            }
        }
    }

    public void ShowDialogue(string[] lines)
    {
        currentDialogueLine = 0;
        dialogueLines = lines;
        dialogueActive = true;
        dialgueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentDialogueLine];
        _characterMovement.isTalking = true;

    }

    public void ShowDialogue(string[]  lines, Sprite sprite)
    {
        ShowDialogue(lines);
        avatarImage.sprite = sprite;
    }
}
