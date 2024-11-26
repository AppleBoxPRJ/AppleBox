using System;
using UnityEngine;

public class messaggioUscitaCasa : MonoBehaviour
{
    public GameObject messaggio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messaggio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            messaggio.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
            messaggio.SetActive(false);
            Destroy(gameObject);
        
    }
}
