using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialgoue/New Dialogue")]
public class DialogueText : ScriptableObject
{
    //This makes the SO's for where the dialogue data is held.



    public string speakerName;
    public string playerName;

    [TextArea(5, 10)]
    public string[] paragraphs;


}
