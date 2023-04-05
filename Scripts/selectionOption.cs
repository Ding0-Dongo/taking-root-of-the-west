using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class selectionOption : MonoBehaviour
{
    public GameObject dialoguePanel; 
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public GameObject noButton;
    public GameObject yesButton;
    public float wordSpeed;
    public bool playerIsClose;



    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }

        if(dialogueText.text == dialogue[index])
        {
            noButton.SetActive(true);
            yesButton.SetActive(true);
        }
    }



    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        noButton.SetActive(false);
        yesButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }


    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
