using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cassaCollezionista : MonoBehaviour
{
    public static event Action DeCollected;
    //public GameObject muro;
    [SerializeField] int count;
    bool playerInTrigger;


    //all'inizio dell'esecuzione nasconde il testo
    public void Start()
    {
        playerInTrigger = false;
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

    public void Update()
    {
        count = collectiblesCount.passaggioDiLivello;
        if (playerInTrigger == true)
        {
            if (Input.GetKeyDown("e"))
            {
                //Debug.Log("Fino a qui ci arriviamo");
                DeCollected?.Invoke();
            }

            if (count == 5)
            {
                //Debug.Log("Apriamo la porta alla zona successiva");
            }
        }
    }
    //quando esce dal trigger nasconde la scritta
    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //image.SetActive(false);
    //    }
    //}
}
