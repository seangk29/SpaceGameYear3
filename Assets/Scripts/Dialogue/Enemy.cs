using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;



public class Enemy : NPC, Talkable
{
    //This allows for the player to interact with the enemy and begin the dialogue.

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;


    public override void interact()
    {
        talk(dialogueText);
        
    }

    public void talk(DialogueText dialogueText)
    {
        dialogueController.ShowNextParagraph(dialogueText);
    }


}
