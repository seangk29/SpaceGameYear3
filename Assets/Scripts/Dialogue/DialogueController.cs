using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Linq;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI npcNameText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI npcDialogueText;
    [SerializeField] private AudioSource playerVoice;
    [SerializeField] private GameObject playerVoiceObject;
    [SerializeField] private AudioClip[] playerClips;
    [SerializeField] private float typeSpeed;
    [SerializeField] private GameObject player;
    public Image npc;
    public Image playerSprite;


    [SerializeField] private Queue<string> paragraphs = new Queue<string>();

    //public PlayerMovement move;

    private bool convoEnded;
    private bool isTyping;
    private int counter = -1;

    private string p;
    private const float MAX_TYPE_TIME = 0.1F;

    private Coroutine typeDialogueRoutine;


    private void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player");
        //move = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    public void ShowNextParagraph(DialogueText dialogueText)
    {
        //This finds the player and gets access to movement component.


        

        if (paragraphs.Count == 0)
        {
            if (!convoEnded)
            {
                startConvo(dialogueText);
                //move.enabled = false;
            }

            else if (convoEnded && !isTyping)
            {
                
                endConvo();
               // move.enabled = true;
                return;
            }

            
        }



        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            counter++;
            playerVoiceObject.SetActive(true);
            typeDialogueRoutine = StartCoroutine(typeDialogueText(p));   
        }
        else
        {
            //playerVoice.Stop();
            playerVoiceObject.SetActive(false);
            FinishParagraphEarly();
        }


        switch (counter)
        {
            case 0:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 1:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 2:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 3:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 4:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 5:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 6:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            case 7:
                playerVoice.clip = playerClips[counter];
                playerVoice.Play();
                break;
            default:
                playerVoice.clip = null;
                break;
        }


        if (paragraphs.Count == 0)
        {
            convoEnded = true;
        }

    }

    //This Activates the UI so the Conversation can begin.
    public void startConvo(DialogueText dialogueText)
    {
        if (!gameObject.activeSelf)
        { 
        gameObject.SetActive(true);
        }

        npcNameText.text = dialogueText.speakerName;
        playerNameText.text = dialogueText.playerName;
        playerClips = dialogueText.speakerClip;


        //Adds the text to the Queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }



    }

    //This hides the UI and allows for the conversation to end
    public void endConvo()
    {
        paragraphs.Clear();

        convoEnded = false;

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        playerVoice.Stop();

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);


    }


    //This function makes it so the dialogue gets typed letter by letter.
    private IEnumerator typeDialogueText(string p)
    {
        isTyping = true;

        int maxVisibleChars = 0;

        npcDialogueText.text = p;
        npcDialogueText.maxVisibleCharacters = maxVisibleChars;

        foreach (char c in p.ToCharArray())
        {

            maxVisibleChars++;
            npcDialogueText.maxVisibleCharacters = maxVisibleChars;
            

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }

    //This allows for you to end the text early.
    private void FinishParagraphEarly()
    {
        StopCoroutine(typeDialogueRoutine);
        npcDialogueText.maxVisibleCharacters = p.Length;
        isTyping = false;
        playerVoice.Stop();
    }



}
