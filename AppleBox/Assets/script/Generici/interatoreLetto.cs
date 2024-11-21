using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class interatoreLetto : MonoBehaviour
{
    bool playerInTrigger;
    // Start is called before the first frame update
    public void Start()
    {
        playerInTrigger = false;
        Debug.Log(gameHandler.Plevel);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ci siamo");
            playerInTrigger = true;

        }
    }
    // Update is called once per frame
    public void Update()
    {
        if (playerInTrigger == true)
        {
            if (Input.GetKeyDown("e"))
            {
                PlayerPrefs.SetInt("PlayerLevel", gameHandler.Plevel + 1);
                gameHandler.Plevel = gameHandler.Plevel + 1;
                Debug.Log(gameHandler.Plevel);
                SceneManager.LoadScene("Livello" + gameHandler.Plevel);
            }
        }
    }
}
