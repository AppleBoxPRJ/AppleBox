using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class cassaCollezionista_LVL2 : MonoBehaviour
{
    public static event Action DeCollected;
    //public GameObject muro;
    public static int count;
    public bool playerInTrigger;
    //public GameObject text;


    //all'inizio dell'esecuzione nasconde il testo
    public void Start()
    {
        playerInTrigger = false;
        //text.SetActive(false);
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

            if (count == 5)
            {
                //text.gameObject.SetActive(true);
            }
            
        } 
        else
        {
            //text.SetActive (false);
        }

        //text.gameObject.SetActive(false);
    }
}
