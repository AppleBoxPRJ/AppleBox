using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectApple : MonoBehaviour, IInteractable
{
    public static event Action OnCollected;
    public GameObject mela;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Interact()
    {
        //Debug.Log("mela raccolta");
        OnCollected?.Invoke();
        Destroy(mela);
    }
}