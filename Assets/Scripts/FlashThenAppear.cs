using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashThenAppear : MonoBehaviour
{

    public SpriteRenderer nextArea;
    public Collider2D nextAreaCol;

    public CardManager cardMg;
    public GameManager gameMg;

    public bool flashOver = false;


    // Start is called before the first frame update
    void Start()
    {
        if (cardMg == null)
        {

            cardMg = GameObject.FindGameObjectWithTag("cardManager").GetComponent<CardManager>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.NextArea && flashOver == false || (GameManager.Instance.currentState == GameManager.GameState.Hub) && flashOver == false)
        {
            StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
       
        yield return new WaitForSeconds(3f);
        nextAreaCol.enabled = true;
        flashOver = true;



    }
}
