using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionDoor : MonoBehaviour
{
    public GameObject porta;
    public GameObject porta_aperta;
    public GameObject text;
    public GameObject text2;
    public int counter;
    public bool playerInTrigger;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        text2.SetActive(false);
        porta.SetActive(true);
        porta_aperta.SetActive(false);
        playerInTrigger = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTrigger == true && Input.GetKeyDown("e"))
        {
            text.SetActive(true);
            counter++;
            if (counter == 4)
            {
                text.SetActive(false);
                text2.SetActive(true);
                apriPorta();
            }
        }

        if(cassaCollezionista.count == 5)
        {
            apriPorta();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("diocane");
            playerInTrigger=true;
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInTrigger=false;
            text.SetActive(false);
            text2.SetActive(false);
        }
    }

    public void apriPorta()
    {
        porta_aperta.SetActive(true);
        porta.SetActive(false);
        playerInTrigger = false;
    }
}
