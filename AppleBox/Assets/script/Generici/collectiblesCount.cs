using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblesCount : MonoBehaviour
{
    public static int passaggioDiLivello;
    public static int counterOggetti;

    public void Awake()
    {
        counterOggetti = 0;
        passaggioDiLivello = 0;
    }


    public static int Incrementa()
    {
        counterOggetti++;
        Debug.Log(counterOggetti);
        return counterOggetti;
    }

    public static int Decrementa()
    {
        
        if(counterOggetti == 0)
        {
            return counterOggetti;
        }
        else
        {
            counterOggetti--;
            passaggioDiLivello++;
            Debug.Log(passaggioDiLivello);
        }
        return counterOggetti;

        
    }

    //utilizza la funzione OnCollected creata nel file collectApple
    void OnEnable()
    {
        collectApple.OnCollected += OnCollectiblesCollected;
    }
    void OnDisable() => collectApple.OnCollected -= OnCollectiblesCollected;

    void OnCollectiblesCollected()
    {
        Incrementa();
    }



}

