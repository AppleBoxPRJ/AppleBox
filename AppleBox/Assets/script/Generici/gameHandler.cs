using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameHandler : MonoBehaviour
{
    public static int Plevel;
    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerPrefs.HasKey('PlayerLevel'): " + PlayerPrefs.HasKey("PlayerLevel"));
        Debug.Log("plevel: " + Plevel);

        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            Plevel = PlayerPrefs.GetInt("PlayerLevel");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerLevel", 0);
            Plevel = 0;
        }
    }

    public void NoSaveData()
    {
        if (Plevel == 0)
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
