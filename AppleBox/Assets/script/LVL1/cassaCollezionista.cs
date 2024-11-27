using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class cassaCollezionista : MonoBehaviour
{
    public static event Action DeCollected;
    //public GameObject muro;
    public static int count;
    public bool playerInTrigger;
    public GameObject text;
<<<<<<< Updated upstream
    
    public int livello = gameHandler.Plevel;
=======

    public int livello;
>>>>>>> Stashed changes


    //all'inizio dell'esecuzione nasconde il testo
    public void Start()
    { 
        playerInTrigger = false;
        text.SetActive(false);
        count = 0;
        livello = gameHandler.Plevel;
        Debug.Log("livello: " + livello);
    }

    //quando entra il trigger mostra la scritta
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ci siamo");
            playerInTrigger = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    public void Update()
    {
        count = collectiblesCount.passaggioDiLivello;
        if (playerInTrigger == true)
        {
            if (Input.GetKeyDown("e"))
            {
                DeCollected?.Invoke();
            }
            switch (livello)
            {
                case 1:
                    if (count == 5)
                    {
                        text.gameObject.SetActive(true);
                    }
                    break;
                case 2:
                    if (count == 8)
                    {
                        text.gameObject.SetActive(true);
                    }
                    break;
                default:
                    Debug.Log("vabbe");
                    break;
            }

            
        } 
        else
        {
            text.SetActive (false);
        }

        //text.gameObject.SetActive(false);
    }
}
