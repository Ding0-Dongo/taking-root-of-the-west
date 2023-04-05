using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class whodunnitEndings : MonoBehaviour
{

    public GameObject endingPanel;

    public void showEnding(){
        if(!(endingPanel.activeInHierarchy))
        {
            endingPanel.SetActive(true);
        }
    }

}
