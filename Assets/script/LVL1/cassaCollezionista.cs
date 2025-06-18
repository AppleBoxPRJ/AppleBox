using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class cassaCollezionista : MonoBehaviour
{
    public static event Action DeCollected;
    public static int count;
    public bool playerInTrigger;
    public GameObject text;
    public int livello;
    public GameObject porta;
    public GameObject porta_aperta;
    public Animator animator; // Riferimento all'Animator

    void Start()
    {
        playerInTrigger = false;
        text.SetActive(false);
        count = 0;
        livello = gameHandler.Plevel;
        Debug.Log("livello: " + livello);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ci siamo");
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }

    void Update()
    {
        count = collectiblesCount.passaggioDiLivello;
        if (playerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DeCollected?.Invoke();
                animator.SetTrigger("StartAnimation"); // Avvia l'animazione
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
                        apriPorta();
                    }
                    break;
                default:
                    Debug.Log("vabbe");
                    break;
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    public void apriPorta()
    {
        porta_aperta.SetActive(true);
        porta.SetActive(false);
        playerInTrigger = false;
    }
}
