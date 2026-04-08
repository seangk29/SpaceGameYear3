using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine.InputSystem.XR;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI npcDialogueText;
    [SerializeField] private float typeSpeed;
    //[SerializeField] private GameObject player;

    private Queue<string> paragraphs = new Queue<string>();
    public bool convoEnded;
    private bool isTyping;

    private string p;
    private const float MAX_TYPE_TIME = 0.1F;

    private Coroutine typeDialogueRoutine;

    [SerializeField] private AudioSource playerVoice;
    [SerializeField] private GameObject playerVoiceObject;
    [SerializeField] private AudioClip[] playerClips;

    [SerializeField] private Image playerImage;
    [SerializeField] private Sprite[] playerSprites;

    private int counter = -1;
    public Image npc;
    public Image playerSprite;

    public FindShop shops;

    public GameObject skipsShop;
    public GameObject nicosShop;

    public bool skipBool = false;

    public bool nicoBool = false;

    void Start()
    {
        shops = GameObject.FindGameObjectWithTag("Player").GetComponent<FindShop>();
    }

     void Update()
    {
        if (shops == null)
        {
            shops = GameObject.Find("Player").GetComponent<FindShop>();
        }
        else
            return;



    }


    public void ShowNextParagraph(DialogueText dialogueText)
    {
        //This finds the player and gets access to movement component.
         // PlayerMovement move = GameObject.Find("Player").GetComponent<PlayerMovement>();
         


        if (paragraphs.Count == 0)
        {
            if (!convoEnded)
            {
                startConvo(dialogueText);
              //  move.enabled = false;
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

            typeDialogueRoutine = StartCoroutine(typeDialogueText(p));
        }

        else
        {
            FinishParagraphEarly();
        }

        switch (counter)
        {
            case 0:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 1:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 2:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 3:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 4:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 5:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 6:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
                playerVoice.Play();
                break;
            case 7:
                playerVoice.clip = playerClips[counter];
                playerImage.sprite = playerSprites[counter];
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

        playerClips = dialogueText.speakerClip;
        playerSprites = dialogueText.sprites;


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

        if (shops.npcShopable.CompareTag("Skippy"))
        {
            skipsShop.SetActive(true);
            skipBool = true;
        }

        if (shops.npcShopable.CompareTag("Nicos"))
        {
            nicosShop.SetActive(true);
            nicoBool = true;
        }

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
    }



}
