using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noButton : MonoBehaviour
{
    public GameObject dialoguePanel;

    public void clearPanel(){
        if(dialoguePanel.activeInHierarchy){
            dialoguePanel.SetActive(false);
        }
    }
}
