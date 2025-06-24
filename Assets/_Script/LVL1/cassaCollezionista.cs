using System;
using UnityEngine;

public class CassaCollezionista : MonoBehaviour
{
    public static event Action DeCollected;
    public static int count;

    private bool _playerInTrigger;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject porta;
    [SerializeField] private GameObject portaAperta;
    [SerializeField] private Animator animator;
    
    private void Start()
    {
        text.SetActive(false);
        _playerInTrigger = false;
        Debug.Log("Livello: " + GameHandler.Plevel);
    }
    
    private void Update()
    {
        count = CollectiblesCount.passaggioDiLivello;
        
        if (_playerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && CollectiblesCount.counterOggetti > 0)
            {
                DeCollected?.Invoke();
                animator.SetTrigger("StartAnimation"); // Avvia l'animazione
            }
            
            switch (GameHandler.Plevel)
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
                        ApriPorta();
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = true;
        Debug.Log("ci siamo");
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerInTrigger = false;
    }
    
    private void ApriPorta()
    {
        portaAperta.SetActive(true);
        porta.SetActive(false);
    }
}
