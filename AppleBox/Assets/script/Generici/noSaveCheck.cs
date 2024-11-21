using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noSaveCheck : MonoBehaviour
{
    public GameObject GameManager, continueButton;
    //public gameHandler Plevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler.Plevel == 0)
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = true;
        }
    }
        
}
