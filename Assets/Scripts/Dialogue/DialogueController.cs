using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI npcDialogueText;
    [SerializeField] private float typeSpeed;

    private Queue<string> paragraphs = new Queue<string>();
    public bool convoEnded;
    private bool isTyping;

    private string p;
    private Sprite s;
    private AudioClip a;
    private const float MAX_TYPE_TIME = 0.1F;

    private Coroutine typeDialogueRoutine;

    [SerializeField] private AudioSource replaceVoice;
    [SerializeField] private GameObject playerVoiceObject;
    public Queue<AudioClip> newAudio = new Queue<AudioClip>();


    public  Queue<Sprite> newImage = new Queue<Sprite>();
    public Image imgReplace;


    public FindShop shops;

    public GameObject skipsShop;
    public GameObject nicosShop;

    public bool skipBool = false;

    public bool nicoBool = false;

    public int visual;

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

        visual = dialogueText.paragraphs.Length;

        if (paragraphs.Count == 0)
        {
            if (!convoEnded)
            {
                startConvo(dialogueText);

            }

            else if (convoEnded && !isTyping)
            {
                
                endConvo();
                return;
            }

            
        }


        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            s = newImage.Dequeue();
            a = newAudio.Dequeue();

            typeDialogueRoutine = StartCoroutine(typeDialogueText(p, s, a));

            //This is what will make the Dialogue Audio play once
            //the clips have been properly done so remember to uncomment this
            
            replaceVoice.Play();

        }

        else
        {
            FinishParagraphEarly();
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

        //Adds the text to the Queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
            newImage.Enqueue(dialogueText.sprites[i]);
            newAudio.Enqueue(dialogueText.speakerClip[i]);
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
    private IEnumerator typeDialogueText(string p, Sprite s, AudioClip a)
    {
        isTyping = true;

        int maxVisibleChars = 0;

        npcDialogueText.text = p;
        npcDialogueText.maxVisibleCharacters = maxVisibleChars;
        imgReplace.sprite = s;
        replaceVoice.clip = a;

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
