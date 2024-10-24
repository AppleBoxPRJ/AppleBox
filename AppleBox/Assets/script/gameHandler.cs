using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameHandler : MonoBehaviour
{
    public static int Plevel;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerPrefs.HasKey('PlayerLevel'): " + PlayerPrefs.HasKey("PlayerLevel"));

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
