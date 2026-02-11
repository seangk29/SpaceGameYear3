using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialgoue/New Dialogue")]
public class DialogueText : ScriptableObject
{
    //This makes the SO's for where the dialogue data is held.



    public string speakerName;
    public string playerName;
    public AudioClip[] speakerClip;
    public Sprite[] sprites;

    [TextArea(5, 10)]
    public string[] paragraphs;


}
