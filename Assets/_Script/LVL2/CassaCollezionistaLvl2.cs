using System;
using UnityEngine;

public class CassaCollezionistaLvl2 : MonoBehaviour
{
    public static event Action DeCollected;
    //public GameObject muro;
    public static int count;
    public bool playerInTrigger;
    public GameObject text;


    // All'inizio dell'esecuzione nasconde il testo
    void Start()
    {
        playerInTrigger = false;
        text.SetActive(false);
    }

    void Update()
    {
        count = CollectiblesCount.passaggioDiLivello;
        if (!playerInTrigger) return;
        
        if (Input.GetKeyDown("e"))
        {
            DeCollected?.Invoke();
            Debug.Log("metti le cazzo di mele");
        }

        if (count == 5)
        {
            text.gameObject.SetActive(true);
        }
    }
    
    // Quando entra il trigger mostra la scritta
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger = true;
        Debug.Log("ci siamo");
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerInTrigger = false;
    }
}
