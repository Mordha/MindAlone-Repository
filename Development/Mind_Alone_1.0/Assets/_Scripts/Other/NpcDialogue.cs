using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NpcDialogue : MonoBehaviour
{

    public string npcName;
    public string[] npcDialogueLines;

    public Sprite npcSprite;

    private DiialogueManager _manager;

    private bool playerInTheZone;

    public int typeOfNpc;

    public bool npcType2;
    
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<DiialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheZone && typeOfNpc == 2 && Input.GetKeyDown(KeyCode.F))
        {
            string[] finalDialogue = new string[npcDialogueLines.Length];
            
            int i = 0;
            foreach (string line in npcDialogueLines)
            {
                finalDialogue[i] = (npcName != null ? npcName + "\n" : "") + line;
                i++;
            }
            

            if (npcSprite != null)
            {
                _manager.ShowDialogue(finalDialogue, npcSprite);
            }
            else
            { 
                _manager.ShowDialogue(finalDialogue);
            } 
        } else if (playerInTheZone && typeOfNpc == 1 && npcType2)
        {
            string[] finalDialogue = new string[npcDialogueLines.Length];
            
            int i = 0;
            foreach (string line in npcDialogueLines)
            {
                finalDialogue[i] = (npcName != null ? npcName + "\n" : "") + line;
                i++;
            }
            
            if (npcSprite != null)
            {
                _manager.ShowDialogue(finalDialogue, npcSprite);
                npcType2 = false;
            }
            else
            { 
                _manager.ShowDialogue(finalDialogue);
                
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("_Player"))
        {
            playerInTheZone = true;
            npcType2 = true;
            Debug.Log(playerInTheZone);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("_Player"))
        {
            playerInTheZone = false;
           
        }
    }
}
