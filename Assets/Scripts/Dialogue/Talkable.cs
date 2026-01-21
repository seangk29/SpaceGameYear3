using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Talkable
{
    //This lets you know if the NPC is talkable.
    public void talk(DialogueText dialogueText);
}
